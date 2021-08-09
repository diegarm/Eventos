using ProEventos.Application.Contratos;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            this._geralPersist = geralPersist;
            this._eventoPersist = eventoPersist;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                    return await _eventoPersist.GetEventoIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no momento de adicionar", ex);
            }
        }

        public async Task<bool> DeleteEvento(int EventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoIdAsync(EventoId, false);
                if (evento == null) throw new Exception("Evento não encontrado");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no momento de deletar", ex);
            }
        }
        public async Task<Evento> UpdateEventos(int EventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoIdAsync(model.Id, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangesAsync())
                    return await _eventoPersist.GetEventoIdAsync(evento.Id, false);

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no momento de adicionar", ex);
            }
        }

        public async Task<Evento[]> GetAllEventoAsync(bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventoAsync(incluirPalestrante);
                return eventos;                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar os Eventos", ex);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema,incluirPalestrante);
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar os Eventos", ex);
            }
        }

        public async Task<Evento> GetEventoIdAsync(int eventoId, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoIdAsync(eventoId, incluirPalestrante);
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar os Eventos", ex);
            }
        }

    }
}
