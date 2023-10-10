using SOL.Domain.Models.BusinessEntities;
using SOL.Domain.Models.Exceptions;
using SOL.Domain.Services.Sections;
using SOL.Infrastructure.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Infrastructure.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly DBSolContext _context;
        protected readonly DbSet<SECTIONS> _entities;
        public SectionRepository(DBSolContext context)
        {
            var conn = context.Database.Connection;
            _context = context;
            _entities = context.Set<SECTIONS>();
        }
        public async Task<bool> CheckAvailability(int SectionId)
        {
            var entity = await _entities.FindAsync(SectionId);
            if(entity is null) throw new BusinessException(message: "No se encontró Sección con el Id Especificado");
            return (bool)entity.STATUS;
        }

        public async Task<IEnumerable<SECTIONS>> GetActives()
        {
            var res = await _entities
            .Where(s => s.STATUS == true)
            .ToListAsync();
            return res;
        }
    }
}
