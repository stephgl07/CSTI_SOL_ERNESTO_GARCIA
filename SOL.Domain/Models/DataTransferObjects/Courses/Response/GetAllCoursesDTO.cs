using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.DataTransferObjects.Courses.Response
{
    public class GetAllCoursesDTO
    {
        public int CourseId { get; set; }
        public string CourseDescription { get; set; }
    }
}
