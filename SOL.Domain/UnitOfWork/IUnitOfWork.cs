using SOL.Domain.Services.Courses;
using SOL.Domain.Services.CourseSectionVacancies;
using SOL.Domain.Services.Enrollments;
using SOL.Domain.Services.Sections;
using SOL.Domain.Services.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositories
        IStudentRepository Student { get; }
        IEnrollmentRepository Enrollment { get; }
        ISectionRepository Section { get; }
        ICourseRepository Course { get; }
        ICourseSectionVacanciesRepository CourseSectionVacancy { get; }

        //Methods
        void BeginTransaction();
        Task SaveChangesAsync();
        void Rollback();
        void RegisterRollbackAction(Action rollbackAction);
        void Commit();
    }
}
