using SOL.Domain.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Courses
{
    public interface ICourseRepository
    {
        Task<int> GetCredits(int CourseId);
        Task<IEnumerable<COURSES>> GetAll();
    }
}
