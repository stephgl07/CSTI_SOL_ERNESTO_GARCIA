using SOL.Application.Mappers;
using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.DataTransferObjects.Sections.Response;
using SOL.Domain.Services.Sections;
using SOL.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Services
{
    public class SectionService : ISectionService
    {
        private readonly SectionMapper _sectionMapper;
        private readonly IUnitOfWork _unitOfWork;

        public SectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _sectionMapper = new SectionMapper();
        }
        public async Task<IEnumerable<GetAllSectionsDTO>> GetActives()
        {
            IEnumerable<SECTIONS> listStudents = await _unitOfWork.Section.GetActives();
            var responseMapped = _sectionMapper.MapGetAllSections(listStudents);
            return responseMapped;
        }
    }
}
