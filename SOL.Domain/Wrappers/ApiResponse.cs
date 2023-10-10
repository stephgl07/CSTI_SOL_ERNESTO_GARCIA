using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }
        public ApiResponse(T data, string message = null)
        { Succeeded = true; Message = message; Data = data; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string ErrorDetails { get; set; }
        public T Data { get; set; }
    }
}
