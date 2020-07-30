using System.Collections.Generic;
using System.Threading.Tasks;
using TotalWarStats.Model.Entities;

namespace TotalWarStats.Business.Interfaces
{
    public interface IMatchService
    {
        Task<IList<Match>> GetAllMatchesAsync();
        Task<Match> AddMatchAsync(Match match);
        Task DeleteMatchAsync(string matchId);
    }
}
