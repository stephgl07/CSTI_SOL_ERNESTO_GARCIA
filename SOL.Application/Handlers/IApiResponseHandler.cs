using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SOL.Application.Handlers
{
    public interface IApiResponseHandler
    {
        IHttpActionResult HandleResponse<T>(Task<T> responseTask, string successMessage, string errorMessage);
    }
}
