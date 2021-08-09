using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema,bool incluirPalestrante);

        Task<Evento[]> GetAllEventoAsync(bool incluirPalestrante);

       Task<Evento> GetEventoIdAsync(int eventoId, bool incluirPalestrante);

    }
}
