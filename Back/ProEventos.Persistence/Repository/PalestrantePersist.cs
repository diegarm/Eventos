using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext context;

        public PalestrantePersist(ProEventosContext _context)
        {
            context = _context;
        }

        public async Task<Palestrante> GetPalestranteIdAsync(int palestranteId, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                                                .AsNoTracking() //Ele não deixa em "transação"
                                                .Include(e => e.RedeSociais);

            if (incluirEventos)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);

            query = query
                .Where(e => e.Id == palestranteId)
                .OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                                                .AsNoTracking() //Ele não deixa em "transação"
                                                .Include(e => e.RedeSociais);

            if (incluirEventos)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);

            query = query
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                                                .AsNoTracking() //Ele não deixa em "transação"
                                                .Include(e => e.RedeSociais);

            if (incluirEventos)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);

            query = query
                .Where(e => e.Nome == nome)
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }


    }
}
