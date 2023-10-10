using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.Exceptions;
using SOL.Domain.Services.CourseSectionVacancies;
using SOL.Infrastructure.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Infrastructure.Repositories
{
    public class CourseSectionVacanciesRepository : ICourseSectionVacanciesRepository
    {
        private readonly DBSolContext _context;
        protected readonly DbSet<COURSESECTIONVACANCIES> _entities;
        public CourseSectionVacanciesRepository(DBSolContext context)
        {
            var conn = context.Database.Connection;
            _context = context;
            _entities = context.Set<COURSESECTIONVACANCIES>();
        }

        public async Task<COURSESECTIONVACANCIES> GetByCourseSection(int CourseId, int SectionId)
        {
            var entity = await _entities.FindAsync(CourseId, SectionId);
            if(entity is null) throw new BusinessException(message: "No se encontró registro en CourseSectionVacancy");
            return entity;
        }
    }
}
