using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.DataTransferObjects.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Mappers
{
    public class StudentMapper
    {
        public IEnumerable<GetAllStudentsDTO> MapGetAllStudents(IEnumerable<STUDENTS> listStudents)
        {
            var listStudentsDTO = listStudents.Select(student =>
            {
                return new GetAllStudentsDTO()
                {
                    DNI = (int)student.DNI,
                    FirstNames = student.FIRSTNAMES,
                    LastNames = student.LASTNAMES,
                    Status = student.STATUS,
                    StudentCode = student.STUDENTCODE
                };
            });

            return listStudentsDTO;
        }
    }
}
