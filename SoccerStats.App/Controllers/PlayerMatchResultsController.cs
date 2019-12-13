using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStats.Data;
using SoccerStats.Domain.Entities;

namespace SoccerStats.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerMatchResultsController : ControllerBase
    {
        private readonly SoccerStatsContext _context;

        public PlayerMatchResultsController(SoccerStatsContext context)
        {
            _context = context;
        }

        // GET: api/PlayerMatchResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerMatchResult>>> GetPlayerMatchResults()
        {
            return await _context.PlayerMatchResults.ToListAsync();
        }

        // GET: api/PlayerMatchResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerMatchResult>> GetPlayerMatchResult(int id)
        {
            var playerMatchResult = await _context.PlayerMatchResults.FindAsync(id);

            if (playerMatchResult == null)
            {
                return NotFound();
            }

            return playerMatchResult;
        }

        // PUT: api/PlayerMatchResults/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerMatchResult(int id, PlayerMatchResult playerMatchResult)
        {
            if (id != playerMatchResult.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerMatchResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerMatchResultExists(id))
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

        // POST: api/PlayerMatchResults
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlayerMatchResult>> PostPlayerMatchResult(PlayerMatchResult playerMatchResult)
        {
            _context.PlayerMatchResults.Add(playerMatchResult);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerMatchResultExists( playerMatchResult.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerMatchResult", new { id = playerMatchResult.PlayerId }, playerMatchResult);
        }

        private bool PlayerMatchResultExists(int? playerId)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/PlayerMatchResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerMatchResult>> DeletePlayerMatchResult(int id)
        {
            var playerMatchResult = await _context.PlayerMatchResults.FindAsync(id);
            if (playerMatchResult == null)
            {
                return NotFound();
            }

            _context.PlayerMatchResults.Remove(playerMatchResult);
            await _context.SaveChangesAsync();

            return playerMatchResult;
        }

        private bool PlayerMatchResultExists(int id)
        {
            return _context.PlayerMatchResults.Any(e => e.PlayerId == id);
        }
    }
}
