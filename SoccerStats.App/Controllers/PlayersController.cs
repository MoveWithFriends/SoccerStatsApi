using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerStats.Domain;
using SoccerStats.Domain.DTO;
using SoccerStats.Domain.DTO.GetDto;
using SoccerStats.Domain.Services;
using System.Threading.Tasks;

namespace SoccerStats.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IAppService _logic;

        public PlayersController(IAppService logic)
        {

            _logic = logic;
        }


        //First Screen: Team Screen

        //Gets: api/Players/2
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTeamPlayerDto>> GetPlayersOnTeam(int id)
        {
            var results = await _logic.GetTeamPlayers(id);
            return results;
        }


        //Post: api/Players 
        [HttpPost]
        public async Task<ActionResult<GetTeamPlayerDto>> PostPlayer([FromForm] PlayerDto player)
        {
            await _logic.PostPlayer(player);
            return StatusCode(201);
        }

        //Put: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            var results = await _logic.PutPlayer(id, player);
            return results;
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var results = await _logic.DeletePlayer(id);
            return results;
        }
    }
}
