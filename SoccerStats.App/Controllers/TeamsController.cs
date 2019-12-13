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
        private readonly SoccerStatsContext _context;
        private readonly ISoccerStatsRepository _repository;
        private readonly ITransformer _transformer;

        public TeamsController(SoccerStatsContext context, ISoccerStatsRepository repository, ITransformer transformer)
        {
            _context = context;
            _repository = repository;
            _transformer = transformer;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        //// GET: api/Teams/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Team>> GetTeam(int id)
        //{
        //    var team = await _context.Teams.FindAsync(id);

        //    if (team == null)
        //    {
        //        return NotFound();
        //    }

        //    return team;
        //}

        // PUT: api/Teams/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamPlayerDto>> GetPlayersOnTeam(int id)
        {
            var team = await _repository.GetPlayersByTeamAsync(id);

            if (team == null) return NotFound();

            return _transformer.Transform(team);
        }

        // POST: api/Teams
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
