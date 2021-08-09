using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface IPalestrantePersist
    {
        //Palestrante
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos);

        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos);

        Task<Palestrante> GetPalestranteIdAsync(int palestranteId, bool incluirEventos);

    }
}
