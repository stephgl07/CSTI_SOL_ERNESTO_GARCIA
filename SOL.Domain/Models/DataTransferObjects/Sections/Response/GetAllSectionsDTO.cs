using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Models.DataTransferObjects.Sections.Response
{
    public class GetAllSectionsDTO
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
    }
}
