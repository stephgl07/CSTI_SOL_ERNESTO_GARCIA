using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.DataTransferObjects.Courses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Mappers
{
    class CourseMapper
    {
        public IEnumerable<GetAllCoursesDTO> MapGetAllCourses(IEnumerable<COURSES> listStudents)
        {
            var listStudentsDTO = listStudents.Select(section =>
            {
                return new GetAllCoursesDTO()
                {
                    CourseId = (int)section.COURSEID,
                    CourseDescription = section.COURSEDESCRIPTION
                };
            });

            return listStudentsDTO;
        }
    }
}
