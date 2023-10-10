using SOL.Application.Handlers;
using SOL.Domain.Services.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SOL.Api.Controllers
{
    [RoutePrefix("api/course")]
    public class SectionController : ApiController
    {
        private readonly IApiResponseHandler _apiResponseHandler;
        private readonly ISectionService _sectionService;
        public SectionController(IApiResponseHandler apiResponseHandler, ISectionService studentService)
        {
            _apiResponseHandler = apiResponseHandler;
            _sectionService = studentService;
        }
        //GET
        public async Task<IHttpActionResult> GetAllStudents()
        {
            return _apiResponseHandler.HandleResponse(await Task.FromResult(_sectionService.GetActives()), "Lista de Estudiantes obtenida exitosamente", "Error al buscar la lista de Estudiantes");
        }
    }
}