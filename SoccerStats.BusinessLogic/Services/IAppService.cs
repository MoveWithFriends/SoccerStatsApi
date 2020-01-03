using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerStats.Domain.DTO;
using SoccerStats.Domain.DTO.GetDto;
using SoccerStats.Domain.Entities;

namespace SoccerStats.Domain.Services
{
    public interface IAppService
    {
        Task<ActionResult<GetTeamPlayerDto>> GetTeamPlayers(int id);
        Task<int> PostPlayer(PlayerDto player);
        Task<IActionResult> PutPlayer(int id, Player player);
        Task<ActionResult<Player>> DeletePlayer(int id);
        Task<ActionResult<Team>> PostTeam(Team team);
        Task<IActionResult> PutTeam(int id, Team team);
        Task<ActionResult<Team>> DeleteTeam(int id);
        Task<ActionResult<IEnumerable<Team>>> GetTeam();
        Task<int> PostMatchMoment(MatchMomentDto moment);
    }
}