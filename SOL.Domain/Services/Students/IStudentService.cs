using SOL.Domain.Models.DataTransferObjects.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<GetAllStudentsDTO>> GetAll();
        Task<IEnumerable<GetAllStudentsDTO>> GetActives();
        //Task<GetAllByIdProductsDTO?> GetAllById(int ProductId);
        //Task<AddEditProductDTO> Create(AddEditProductDTO productDTO);
        //Task<AddEditProductDTO> Update(AddEditProductDTO productDTO);
    }
}
