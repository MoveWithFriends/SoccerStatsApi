using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStats.Data;
using SoccerStats.Domain.DTO;
using SoccerStats.Domain.Entities;
using SoccerStats.Domain.Services;

namespace SoccerStats.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IAppService _logic;

        public TeamsController(IAppService logic)
        {

            _logic = logic;
        }

        //First Screen: Team Screen

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var results = await _logic.GetTeam();
            return results;
        }

        //Put: api/Teams/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            var results = await _logic.PutTeam(id, team);
            return results;
        }


        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var results = await _logic.DeleteTeam(id);
            return results;
        }

























        //Second Screen: Match Screen
    }
}
