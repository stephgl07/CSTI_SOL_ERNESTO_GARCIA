using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.DataTransferObjects.Sections.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Mappers
{
    public class SectionMapper
    {
        public IEnumerable<GetAllSectionsDTO> MapGetAllSections(IEnumerable<SECTIONS> listStudents)
        {
            var listStudentsDTO = listStudents.Select(section =>
            {
                return new GetAllSectionsDTO()
                {
                    SectionId = (int)section.SECTIONID,
                    SectionName = section.SECTIONNAME
                };
            });

            return listStudentsDTO;
        }
    }
}
