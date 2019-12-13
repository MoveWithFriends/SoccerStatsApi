using System.Collections.Generic;
using System.Threading.Tasks;
using SoccerStats.Domain;
using SoccerStats.Domain.Entities;

namespace SoccerStats.Data
{
    public interface ISoccerStatsRepository
    {
        void AddPlayer(Player player);
        Task<bool> AddTeam(Team team);
        Task<List<Match>> GetMatchesAsync();
        Task<List<Player>> GetPlayersAsync();
        Task<Team> GetPlayersByTeamAsync(int id);
    }
}