using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.Exceptions;
using SOL.Domain.Services.Students;
using SOL.Infrastructure.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DBSolContext _context;
        protected readonly DbSet<STUDENTS> _entities;
        public StudentRepository(DBSolContext context)
        {
            var conn = context.Database.Connection;
            _context = context;
            _entities = context.Set<STUDENTS>();
        }
        public Task Create(STUDENTS product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<STUDENTS>> GetAll()
        {
            try
            {
                var res =  await _entities
                    .ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<STUDENTS>> GetActives()
        {
            var res = await _entities
            .Where(s => s.STATUS == true)
            .ToListAsync();
            return res;
        }

        public Task<STUDENTS> GetById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public void Remove(STUDENTS product)
        {
            throw new NotImplementedException();
        }

        public void Update(STUDENTS product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckIfEnrolled(int StudentDNI, int CourseId)
        {
            var entity = await _entities
                .Include(s => s.ENROLLMENTS)
                .Where(s => s.DNI == StudentDNI)
                .SingleOrDefaultAsync();
            if (entity is null) throw new BusinessException(message: "No se encontró alumno con el DNI brindado");

            return entity.ENROLLMENTS.Any(enrollment => enrollment.COURSEID == CourseId);

        }

        public async Task<int> CheckTotalCredits(int StudentDNI)
        {
            var entity = await _entities
                .Include("ENROLLMENTS.COURSES") // Incluye ENROLLMENTS y luego COURSE
                .Where(s => s.DNI == StudentDNI)
                .SingleOrDefaultAsync();
            if (entity is null) throw new BusinessException(message: "No se encontró alumno con el DNI brindado");

            int totalCredits = 0;
            foreach(var enrollment in entity.ENROLLMENTS)
            {
                totalCredits = (int)enrollment.COURSES.CREDITHOURS;
            }
            return totalCredits;

        }
    }
}
