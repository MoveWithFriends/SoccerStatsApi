using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStats.BusinessLogic.Services;
using SoccerStats.Data;
using SoccerStats.Domain.DTO;
using SoccerStats.Domain.DTO.GetDto;
using SoccerStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerStats.Domain.Services
{
    public class AppService : ControllerBase, IAppService
    {

        private readonly SoccerStatsContext _context;
        private readonly ISoccerStatsRepository _repository;
        private readonly ITransformer _transformer;
        private readonly IHostingEnvironment _environment;

        public AppService(SoccerStatsContext context, ISoccerStatsRepository repository, ITransformer transformer, IHostingEnvironment environment)
        {
            _context = context;
            _repository = repository;
            _transformer = transformer;
            _environment = environment;
        }

        public async Task<ActionResult<GetTeamPlayerDto>> GetTeamPlayers(int id)
        {
            var team = await _repository.GetPlayersByTeamAsync(id);
            //ImageConverter.GetImageFromByteArray(team.);

            if (team == null) return NotFound();

            return _transformer.TransformToGet(team);
        }


        public async Task<int> PostPlayer(PlayerDto player)
        {
            if (player.Image.Length > 0)
            {
                using var ms = new MemoryStream();
                player.Image.CopyTo(ms);

                var entity = new Player
                {
                    FirstName = player.FirstName,
                    Picture = ms.ToArray(),
                    LastName = player.LastName,
                    TeamId = player.TeamId,
                    BackNumber = player.BackNumber
                };

                _context.Players.Add(entity);
                await _context.SaveChangesAsync();
                return entity.TeamId;
            }
            return 0;
        }
        public async Task<int> PostMatchMoment(MatchMomentDto moment)
        {
            if(moment.Moment != null)
            {
                var result = _transformer.Transform(moment);
                _context.MatchMoments.Add(result);
                await _context.SaveChangesAsync();
                return result.Id;
            }
            return 0;
        }


        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        private bool PlayerExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<ActionResult<IEnumerable<Team>>> GetTeam()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

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
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

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
    }
}
