using SOL.Domain.Services.Courses;
using SOL.Domain.Services.CourseSectionVacancies;
using SOL.Domain.Services.Enrollments;
using SOL.Domain.Services.Sections;
using SOL.Domain.Services.Students;
using SOL.Domain.UnitOfWork;
using SOL.Infrastructure.Repositories;
using SOL.Infrastructure.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //DbContext
        private readonly DBSolContext _context;
        private List<Action> _rollbackActions;

        //Repositories
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseSectionVacanciesRepository _courseSectionVacanciesRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly ICourseRepository _coursesRepository;

        public UnitOfWork(DBSolContext context)
        {
            _context = context;
            _rollbackActions = new List<Action>();
            _studentRepository = new StudentRepository(_context);
            _enrollmentRepository = new EnrollmentRepository(_context);
            _sectionRepository = new SectionRepository(_context);
            _coursesRepository = new CourseRepository(_context);
        }

        public IStudentRepository Student => _studentRepository ?? new StudentRepository(_context);
        public IEnrollmentRepository Enrollment => _enrollmentRepository ?? new EnrollmentRepository(_context);
        public ICourseSectionVacanciesRepository CourseSectionVacancy => _courseSectionVacanciesRepository ?? new CourseSectionVacanciesRepository(_context);
        public ISectionRepository Section => _sectionRepository ?? new SectionRepository(_context);
        public ICourseRepository Course => _coursesRepository ?? new CourseRepository(_context);

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            //_context.Database.();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void Rollback()
        {
            foreach (var rollbackAction in _rollbackActions)
            {
                rollbackAction.Invoke();
            }
            //_context.Database.RollbackTransaction();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                _rollbackActions.Clear();
            }
        }

        public void RegisterRollbackAction(Action rollbackAction)
        {
            _rollbackActions.Add(rollbackAction);
        }
    }
}
