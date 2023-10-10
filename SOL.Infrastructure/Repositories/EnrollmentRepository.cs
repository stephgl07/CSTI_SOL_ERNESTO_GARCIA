using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.Exceptions;
using SOL.Domain.Services.Enrollments;
using SOL.Infrastructure.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DBSolContext _context;
        protected readonly DbSet<ENROLLMENTS> _entities;
        public EnrollmentRepository(DBSolContext context)
        {
            var conn = context.Database.Connection;
            _context = context;
            _entities = context.Set<ENROLLMENTS>();
        }
        public async Task<int> Create(ENROLLMENTS enrollment)
        {
            try
            {
                decimal nextId = await _context.Database.SqlQuery<decimal>("SELECT ENROLLMENT_SEQ.NEXTVAL FROM DUAL").FirstOrDefaultAsync();
                enrollment.ENROLLMENTID = nextId;

                _entities.Add(enrollment);
                return (int)nextId;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ENROLLMENTS>> GetAll()
        {
            var res = await _entities
                    .ToListAsync();
            return res;
        }

        public async Task<IEnumerable<ENROLLMENTS>> GetAllInfoEnrollment()
        {
            var entity = await _entities
                .Include(c => c.COURSES)
                .Include(st => st.STUDENTS)
                .Include(se => se.SECTIONS)
                .ToListAsync();
            return entity;
        }

        public Task<ENROLLMENTS> GetById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public void Remove(ENROLLMENTS product)
        {
            throw new NotImplementedException();
        }

        public void Update(ENROLLMENTS product)
        {
            throw new NotImplementedException();
        }

        public async Task CancelEnrollment(int EnrollmentId)
        {
            var entity = await _entities.FindAsync(EnrollmentId);
            if (entity is null) throw new BusinessException(message:"No se pudo encontrar la Matricula");

            entity.CANCELLATIONDATE = DateTime.Now;
            entity.STATUS = false;
        }
    }
}
