using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.Exceptions;
using SOL.Domain.Services.Courses;
using SOL.Infrastructure.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DBSolContext _context;
        protected readonly DbSet<COURSES> _entities;
        public CourseRepository(DBSolContext context)
        {
            var conn = context.Database.Connection;
            _context = context;
            _entities = context.Set<COURSES>();
        }
        public async Task<int> GetCredits(int CourseId)
        {
            var entity = await _entities.FindAsync(CourseId);
            if (entity is null) throw new BusinessException(message: "No se encontró el curso");

            return (int)entity.CREDITHOURS;
        }

        public async Task<IEnumerable<COURSES>> GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
