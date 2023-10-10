using SOL.Domain.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Enrollments
{

    public interface IEnrollmentRepository
    {
        Task<IEnumerable<ENROLLMENTS>> GetAll();
        Task<IEnumerable<ENROLLMENTS>> GetAllInfoEnrollment();
        Task CancelEnrollment(int EnrollmentId);
        Task<ENROLLMENTS> GetById(int ProductId);
        Task<int> Create(ENROLLMENTS product);
        void Update(ENROLLMENTS product);
        void Remove(ENROLLMENTS product);
    }
}
