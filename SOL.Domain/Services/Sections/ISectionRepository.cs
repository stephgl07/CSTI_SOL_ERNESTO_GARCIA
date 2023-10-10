using SOL.Domain.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Sections
{
    public interface ISectionRepository
    {
        Task<bool> CheckAvailability(int SectionId);
        Task<IEnumerable<SECTIONS>> GetActives();
    }
}
