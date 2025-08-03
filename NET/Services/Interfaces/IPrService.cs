using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IPrService
    {
        Task<PRDTO> GetPRByIdAsync(int id);
        Task<IEnumerable<PRDTO>> GetAllPRsAsync();
        Task<PRDTO> CreatePRAsync(CreatePRDTO createPrDto);
        Task<PRDTO> UpdatePRAsync(int id, UpdatePRDTO prDto);
        Task<bool> DeletePRAsync(int id);
    }
}