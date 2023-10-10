using SOL.Domain.Models.DataTransferObjects.Courses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<GetAllCoursesDTO>> GetAll();
    }
}
