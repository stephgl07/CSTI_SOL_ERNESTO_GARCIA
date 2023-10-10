using SOL.Application.Handlers;
using SOL.Application.Services;
using SOL.Application.Services.Logger;
using SOL.Domain.Services.Courses;
using SOL.Domain.Services.CourseSectionVacancies;
using SOL.Domain.Services.Enrollments;
using SOL.Domain.Services.Logger;
using SOL.Domain.Services.Sections;
using SOL.Domain.Services.Students;
using SOL.Domain.UnitOfWork;
using SOL.Infrastructure.Repositories;
using SOL.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.AspNet.WebApi;

namespace SOL.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //DEPENDENCY INJECTION MANAGEMENT

            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Configurate UnityContainer for DI
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IApiResponseHandler, ApiResponseHandler>();

            // Services
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IEnrollmentService, EnrollmentService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<ISectionService, SectionService>();

            // Repositories
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IEnrollmentRepository, EnrollmentRepository>();
            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<ISectionRepository, SectionRepository>();
            container.RegisterType<ICourseSectionVacanciesRepository, CourseSectionVacanciesRepository>();

            // Logger
            container.RegisterType<ILoggerService, LoggerService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}
