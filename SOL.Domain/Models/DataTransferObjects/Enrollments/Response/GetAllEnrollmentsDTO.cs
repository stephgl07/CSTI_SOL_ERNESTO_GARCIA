using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.DataTransferObjects.Enrollments.Response
{
    public class GetAllEnrollmentsDTO
    {
        public int EnrollmentId { get; set; }

        public int StudentDNI { get; set; }

        public int CourseId { get; set; }

        public int SectionId { get; set; }

        public string EnrollmentType { get; set; }

        public string EnrollmentDate { get; set; }

        public string CancelationDate { get; set; }

    }
}
