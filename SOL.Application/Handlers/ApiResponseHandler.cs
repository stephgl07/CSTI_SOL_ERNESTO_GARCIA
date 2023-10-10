using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SOL.Domain.Models.Exceptions;
using SOL.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace SOL.Application.Handlers
{
    public class ApiResponseHandler : IApiResponseHandler
    {
        public IHttpActionResult HandleResponse<T>(Task<T> responseTask, string successMessage, string errorMessage)
        {
            try
            {
                var response = responseTask.Result;
                var apiResponse = new ApiResponse<T>(response, successMessage);
                return CreateResponse(apiResponse);
            }
            catch (Exception error)
            {
                var apiResponse = new ApiResponse<Exception>() { Succeeded = false, Message = errorMessage, ErrorDetails = error.InnerException.Message};
                return CreateResponse(apiResponse);
            }
        }

        private IHttpActionResult CreateResponse<T>(ApiResponse<T> apiResponse)
        {
            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreNullResolver(), 
                }
            };

            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<ApiResponse<T>>(apiResponse, jsonFormatter)
            };

            return new ResponseMessageResult(httpResponseMessage);
        }
    }
}
