using Microsoft.AspNetCore.Mvc;
using SOL.Application.Handlers;
using SOL.Domain.Services.Courses;
using SOL.Domain.Services.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SOL.Api.Controllers
{

    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private readonly IApiResponseHandler _apiResponseHandler;
        private readonly ICourseService _courseService;
        public CourseController(IApiResponseHandler apiResponseHandler, ICourseService studentService)
        {
            _apiResponseHandler = apiResponseHandler;
            _courseService = studentService;
        }
        //GET
        public async Task<IHttpActionResult> GetAllStudents()
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_courseService.GetAll()), "Lista de Estudiantes obtenida exitosamente", "Error al buscar la lista de Estudiantes");
        }
    }
}