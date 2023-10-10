using Microsoft.AspNetCore.Mvc;
using SOL.Application.Handlers;
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
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private readonly IApiResponseHandler _apiResponseHandler;
        private readonly IStudentService _studentService;
        public StudentController(IApiResponseHandler apiResponseHandler, IStudentService studentService)
        {
            _apiResponseHandler = apiResponseHandler;
            _studentService = studentService;
        }
        //GET
        public async Task<IHttpActionResult> GetAllStudents()
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_studentService.GetAll()), "Lista de Estudiantes obtenida exitosamente", "Error al buscar la lista de Estudiantes");
        }

        [HttpGet]
        [Route("GetActives")]
        public async Task<IHttpActionResult> GetActives()
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_studentService.GetAll()), "Lista de Estudiantes obtenida exitosamente", "Error al buscar la lista de Estudiantes");
        }
    }
}