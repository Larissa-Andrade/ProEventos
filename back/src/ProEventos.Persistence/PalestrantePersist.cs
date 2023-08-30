using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.RedeSocial);

            if(includeEvento)
            {
                query = query
                    .Include(p => p.PalestranteEvento)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.RedeSocial);

            if(includeEvento)
            {
                query = query
                    .Include(p => p.PalestranteEvento)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.RedeSocial);

            if(includeEvento)
            {
                query = query
                    .Include(p => p.PalestranteEvento)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}