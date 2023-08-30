using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEvento);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEvento);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEvento);
    }
}