using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IStatisticsService
    {
        // Task<StatisticsDTO> GetStatisticsByUserId(int id);
        Task<IEnumerable<StatisticsDTO>> GetAllStatisticsAsync();
        Task<StatisticsDTO> CreateStatisticsAsync(CreateStatisticsDTO createStatisticsDto);
        Task<StatisticsDTO> UpdateStatisticsAsync(int id, UpdateStatisticsDTO statisticsDto);
        Task<bool> DeleteStatisticsAsync(int id);
    }
}