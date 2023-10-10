using SOL.Domain.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Students
{
    public interface IStudentRepository
    {
        Task<IEnumerable<STUDENTS>> GetAll();
        Task<IEnumerable<STUDENTS>> GetActives();
        Task<bool> CheckIfEnrolled(int StudentDNI, int CourseId);
        Task<int> CheckTotalCredits(int StudentDNI);
        Task<STUDENTS> GetById(int ProductId);
        Task Create(STUDENTS product);
        void Update(STUDENTS product);
        void Remove(STUDENTS product);
    }
}
