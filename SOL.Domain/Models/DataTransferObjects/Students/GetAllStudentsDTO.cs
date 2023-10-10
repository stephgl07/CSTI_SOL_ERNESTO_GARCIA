using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.DataTransferObjects.Students
{
    public class GetAllStudentsDTO
    {
        public int DNI { get; set; }
        public string StudentCode { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string CompleteName { get
            {
                return FirstNames + " " + LastNames;
            }
        }
        public bool? Status { get; set; }
    }
}
