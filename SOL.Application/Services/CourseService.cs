using SOL.Application.Mappers;
using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.DataTransferObjects.Courses.Response;
using SOL.Domain.Services.Courses;
using SOL.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseMapper _courseMapper;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseMapper = new CourseMapper();
        }

        public async Task<IEnumerable<GetAllCoursesDTO>> GetAll()
        {
            IEnumerable<COURSES> listStudents = await _unitOfWork.Course.GetAll();
            var responseMapped = _courseMapper.MapGetAllCourses(listStudents);
            return responseMapped;
        }
    }
}
