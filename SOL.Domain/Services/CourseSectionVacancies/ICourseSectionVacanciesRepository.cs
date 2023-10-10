using SOL.Domain.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.CourseSectionVacancies
{
    public interface ICourseSectionVacanciesRepository
    {
        Task<COURSESECTIONVACANCIES> GetByCourseSection(int CourseId, int SectionId);
    }
}
