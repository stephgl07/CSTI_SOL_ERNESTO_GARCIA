using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; set; }
        public string Details { get; set; }

        public BusinessException(string code = null, string message = null, string details = null,
                                 Exception innerException = null)
            : base(message, innerException) { Code = code; Details = details; }
    }
}
