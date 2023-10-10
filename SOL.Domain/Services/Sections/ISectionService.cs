using SOL.Domain.Models.DataTransferObjects.Sections.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Sections
{
    public interface ISectionService
    {
        Task<IEnumerable<GetAllSectionsDTO>> GetActives();
    }
}
