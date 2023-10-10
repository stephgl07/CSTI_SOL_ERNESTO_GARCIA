using SOL.Domain.Models.BusinessEntities;
using RES = SOL.Domain.Models.DataTransferObjects.Enrollments.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Mappers
{
    public class EnrollmentMapper
    {
        public IEnumerable<RES.GetAllEnrollmentsDTO> MapGetAllEnrollments(IEnumerable<ENROLLMENTS> listEnrollments)
        {
            var listEnrollmentsDTO = listEnrollments.Select(enrollment =>
            {
                return new RES.GetAllEnrollmentsDTO()
                {
                   EnrollmentId = (int)enrollment.ENROLLMENTID,
                   StudentDNI = (int)enrollment.STUDENTDNI,
                   CourseId = (int)enrollment.COURSEID,
                   SectionId = (int)enrollment.SECTIONID,
                   EnrollmentType = enrollment.ENROLLMENTTYPE,
                   EnrollmentDate = enrollment.ENROLLMENTDATE?.ToString("O"),
                   CancelationDate = enrollment.CANCELLATIONDATE?.ToString("O"),
                };
            });

            return listEnrollmentsDTO;
        }

        public IEnumerable<RES.GetReportDTO> MapGetReport(IEnumerable<ENROLLMENTS> listEnrollments)
        {
            var report = listEnrollments.Select(enrollment =>
            {
                return new RES.GetReportDTO()
                {
                    EnrollmentId = (int)enrollment.ENROLLMENTID,
                    StudentCode = enrollment.STUDENTS.STUDENTCODE,
                    StudentNames = enrollment.STUDENTS.FIRSTNAMES,
                    StudentLastNames = enrollment.STUDENTS.LASTNAMES,
                    CourseId = (int)enrollment.COURSEID,
                    Status = (bool)enrollment.STATUS,
                    CourseDescription = enrollment.COURSES.COURSEDESCRIPTION,
                    CreditHours = (int)enrollment.COURSES.CREDITHOURS,
                    SectionName = enrollment.SECTIONS.SECTIONNAME,
                    EnrollmentType = enrollment.ENROLLMENTTYPE,
                    EnrollmentDate = enrollment.ENROLLMENTDATE?.ToString("dd/MM/yyyy HH:mm"),
                    EnrollmentCancelationDate = enrollment.CANCELLATIONDATE?.ToString("dd/MM/yyyy HH:mm"),
                };
            });

            return report;
        }

        public RES.RegisterEnrollmentDTO MapRegisterEnrollment(int EnrollmentID)
        {
            return new RES.RegisterEnrollmentDTO()
            {
                EnrollmentID = EnrollmentID
            };
        }
    }
}
