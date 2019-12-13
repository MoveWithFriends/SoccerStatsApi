using Microsoft.EntityFrameworkCore;
using SoccerStats.Domain;
using SoccerStats.Domain.DTO;
using SoccerStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Data
{
    public class SoccerStatsRepository : ISoccerStatsRepository
    {
        private readonly SoccerStatsContext _context;

        public SoccerStatsRepository(SoccerStatsContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _context.Players
                .AsNoTracking()
                .Include(x => x.MatchResults)
                .Include(x => x.Team)
                .ToListAsync();
        }
        public async Task<Team> GetPlayersByTeamAsync(int id)
        {
            IQueryable<Team> query = _context.Teams
                .Include(p => p.Players);

            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Match>> GetMatchesAsync()
        {
            return await _context.Matches
            .AsNoTracking()
            .Include(x => x.PlayerMatchResults)
            .Include(x => x.MatchMoments)
            .ToListAsync();
        }
        //public async Task<TeamPlayerDto> GetTeamPlayersAsync(int teamId)
        //{
        //    var query = _context.Players
        //        .Where(t => t.TeamId == teamId);

        //    return await query.FirstOrDefaultAsync();
        //}

        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Players.Add(player);
        }
        public async Task<bool> AddTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            _context.Teams.Add(team);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
