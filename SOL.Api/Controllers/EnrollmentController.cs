using Microsoft.AspNetCore.Mvc;
using RES = SOL.Domain.Models.DataTransferObjects.Enrollments.Response;
using REQ = SOL.Domain.Models.DataTransferObjects.Enrollments.Request;
using SOL.Application.Handlers;
using SOL.Domain.Services.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SOL.Api.Controllers
{
    [RoutePrefix("api/enrollment")]
    public class EnrollmentController : ApiController
    {
        private readonly IApiResponseHandler _apiResponseHandler;
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IApiResponseHandler apiResponseHandler, IEnrollmentService enrollmentService)
        {
            _apiResponseHandler = apiResponseHandler;
            _enrollmentService = enrollmentService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAllEnrollments()
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_enrollmentService.GetAll()), "Lista de Estudiantes obtenida exitosamente", "Error al buscar la lista de Estudiantes");
        }

        [HttpGet]
        [Route("report")]
        public async Task<IHttpActionResult> GetReport()
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_enrollmentService.GetReport()), "Lista de Estudiantes obtenida exitosamente", "Error al buscar la lista de Estudiantes");
        }

        [HttpPost]
        public async Task<IHttpActionResult> EnrollStudent(REQ.RegisterEnrollmentDTO enrollmentDTO)
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_enrollmentService.EnrollStudent(enrollmentDTO)), "Registro de Matrícula exitoso", "Error al realizar el registro de la Matrícula");
        }

        [HttpPut]
        public async Task<IHttpActionResult> CancelEnrollment(int EnrollmentId)
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_enrollmentService.CancelEnrollment(EnrollmentId)), "Cancelación de Matrícula exitoso", "Error al realizar la cancelación de la Matrícula");
        }
    }
}