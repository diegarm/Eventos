using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);

        Task<Evento> UpdateEventos(int EventoId,Evento model);

        Task<bool> DeleteEvento(int EventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false);

        Task<Evento[]> GetAllEventoAsync(bool incluirPalestrante = false);

        Task<Evento> GetEventoIdAsync(int EventoId, bool incluirPalestrante = false);
    }
}
