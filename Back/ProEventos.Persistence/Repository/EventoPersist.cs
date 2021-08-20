using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext context;

        public EventoPersist(ProEventosContext _context)
        {
            context = _context;
        }
        public async Task<Evento[]> GetAllEventoAsync(bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = context.Eventos
                                                    .AsNoTracking() //Ele não deixa em "transação"
                                                    .Include(e => e.Lotes)
                                                    .Include(e => e.RedesSociais);

            if (incluirPalestrante)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);

            query = query
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
                
        }

        public async Task<Evento> GetEventoIdAsync(int eventoId, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = context.Eventos
                                        .AsNoTracking() //Ele não deixa em "transação"
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);

            if (incluirPalestrante)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);

            query = query
                .OrderBy(e => e.Id)
                .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = context.Eventos
                                        .AsNoTracking() //Ele não deixa em "transação"
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);

            if (incluirPalestrante)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);

            query = query
                .OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }



    }
}
