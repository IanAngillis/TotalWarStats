using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TotalWarStats.Business.Interfaces;
using TotalWarStats.Business.Repositories;
using TotalWarStats.Model.Entities;

namespace TotalWarStats.Business.Services
{
    public class MatchService : IMatchService
    {
        private readonly MatchRepository _repository;

        public MatchService()
        {
            _repository = new MatchRepository();
        }

        public async Task<Match> AddMatchAsync(Match match)
        {
            return await _repository.AddAsync(match);
        }

        public async Task DeleteMatchAsync(string matchId)
        {
            await _repository.DeleteAsync(matchId);
        }

        public async Task<IList<Match>> GetAllMatchesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
