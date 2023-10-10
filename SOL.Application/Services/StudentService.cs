using SOL.Application.Mappers;
using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.DataTransferObjects.Students;
using SOL.Domain.Services.Students;
using SOL.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentMapper _studentMapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _studentMapper = new StudentMapper();
        }

        public async Task<IEnumerable<GetAllStudentsDTO>> GetAll()
        {
            IEnumerable<STUDENTS> listStudents = await _unitOfWork.Student.GetAll();
            var listStudentsDTO = _studentMapper.MapGetAllStudents(listStudents);
            return listStudentsDTO;
        }

        public async Task<IEnumerable<GetAllStudentsDTO>> GetActives()
        {
            IEnumerable<STUDENTS> listStudents = await _unitOfWork.Student.GetActives();
            var listStudentsDTO = _studentMapper.MapGetAllStudents(listStudents);
            return listStudentsDTO;
        }
    }
}
