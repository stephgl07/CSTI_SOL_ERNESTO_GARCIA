using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.DataTransferObjects.Enrollments.Response
{
    public class GetReportDTO
    {
        public int EnrollmentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentNames { get; set; }
        public string StudentLastNames { get; set; }
        public int CourseId { get; set; }
        public string CourseDescription { get; set; }
        public int CreditHours { get; set; }
        public bool Status { get; set; }
        public string SectionName { get; set; }
        public string EnrollmentType { get; set; }
        public string EnrollmentDate { get; set; }
        public string EnrollmentCancelationDate { get; set; }
    }
}
