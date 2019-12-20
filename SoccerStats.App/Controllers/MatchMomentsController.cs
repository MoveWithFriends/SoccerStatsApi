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
    public class MatchMomentsController : ControllerBase
    {
        private readonly SoccerStatsContext _context;
        private readonly ISoccerStatsRepository _repository;
        private readonly ITransformer _transformer;

        public MatchMomentsController(SoccerStatsContext context, ITransformer transformer, ISoccerStatsRepository repository)
        {
            _context = context;
            _repository = repository;
            _transformer = transformer;
        }

        // GET: api/MatchMoments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchMomentDto>>> GetMatchMoments()
        {
            var moment = await _repository.GetMatchMoments();
            return moment.Select(x => _transformer.Transform(x)).ToList();
        }

        // GET: api/MatchMoments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchMomentDto>> GetMatchMoment(int id)
        {
            var matchMoment = await _context.MatchMoments.FindAsync(id);

            if (matchMoment == null)
            {
                return NotFound();
            }

            return _transformer.Transform(matchMoment);
        }

        // PUT: api/MatchMoments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchMoment(int id, MatchMoment matchMoment)
        {
            if (id != matchMoment.Id)
            {
                return BadRequest();
            }

            _context.Entry(matchMoment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchMomentExists(id))
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

        // POST: api/MatchMoments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MatchMoment>> PostMatchMoment(MatchMoment matchMoment)
        {
            _context.MatchMoments.Add(matchMoment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchMoment", new { id = matchMoment.Id }, matchMoment);
        }

        // DELETE: api/MatchMoments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatchMoment>> DeleteMatchMoment(int id)
        {
            var matchMoment = await _context.MatchMoments.FindAsync(id);
            if (matchMoment == null)
            {
                return NotFound();
            }

            _context.MatchMoments.Remove(matchMoment);
            await _context.SaveChangesAsync();

            return matchMoment;
        }

        private bool MatchMomentExists(int id)
        {
            return _context.MatchMoments.Any(e => e.Id == id);
        }
    }
}
