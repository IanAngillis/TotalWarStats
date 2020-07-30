using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TotalWarStats.Business.Interfaces;
using TotalWarStats.Data.Context;
using TotalWarStats.Model.Entities;

namespace TotalWarStats.Business.Repositories
{
    public class MatchRepository : ICRUDService<Match>, IDisposable
    {
        private readonly TotalWarStatsContext _context;

        public MatchRepository()
        {
            _context = new TotalWarStatsContext();
        }

        public async Task<Match> AddAsync(Match entity)
        {
            await _context.Matches.AddAsync(entity);
            Commit();
            return entity;
        }

        public async Task DeleteAsync(string entityId)
        {
            Match entity = await GetByIdAsync(entityId);

            if (entity is null) return;

            _context.Remove(entity);
            Commit();
        }

        public async Task<IList<Match>> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<IList<Match>> GetByFilterAsync(Expression<Func<Match, bool>> predicate)
        {
            return await _context.Matches.Where(predicate).ToListAsync();
        }

        public async Task<Match> GetByIdAsync(string entityId)
        {
            return await _context.Matches.FirstOrDefaultAsync(m => m.MatchId.Equals(entityId));
        }

        public async Task<Match> UpdateAsync(Match entity)
        {
            Match dbEntity = await GetByIdAsync(entity.MatchId);

            if (dbEntity is null) return entity;

            dbEntity.PlayerFaction = entity.PlayerFaction;
            dbEntity.OpponentFaction = entity.OpponentFaction;
            dbEntity.HasWon = entity.HasWon;
            dbEntity.Date = entity.Date;

            _context.Matches.Update(dbEntity);
            Commit();

            return entity;
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        private async void Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
