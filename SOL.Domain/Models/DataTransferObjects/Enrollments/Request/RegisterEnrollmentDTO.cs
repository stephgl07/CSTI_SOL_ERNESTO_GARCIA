using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.DataTransferObjects.Enrollments.Request
{
    public class RegisterEnrollmentDTO
    {
        public int StudentDNI { get; set; }
        public int CourseID { get; set; }
        public int SectionID { get; set; }
        public string EnrollmentType { get; set; }
    }
}
