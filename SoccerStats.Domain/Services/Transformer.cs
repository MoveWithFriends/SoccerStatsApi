using SoccerStats.Domain.DTO;
using SoccerStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Domain.Services
{
    public class Transformer : ITransformer
    {
        public TeamPlayerDto Transform(Team model)
        {
            var playerModels = model.Players.Select(t => new PlayerDto
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                BackNumber = t.BackNumber
            }).ToList();

            return new TeamPlayerDto
            {
                TeamName = model.TeamName,
                Players = playerModels
            };
        }
    }
}
