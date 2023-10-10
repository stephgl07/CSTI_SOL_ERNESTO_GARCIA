using RES = SOL.Domain.Models.DataTransferObjects.Enrollments.Response;
using REQ = SOL.Domain.Models.DataTransferObjects.Enrollments.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Enrollments
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<RES.GetAllEnrollmentsDTO>> GetAll();
        Task<IEnumerable<RES.GetReportDTO>> GetReport();
        Task<RES.RegisterEnrollmentDTO> EnrollStudent(REQ.RegisterEnrollmentDTO enrollmentDTO);
        Task<int> CancelEnrollment(int EnrollmentId);
    }
}
