using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Domain.DTO
{
    public class TeamPlayerDto
    {
        public string TeamName { get; set; }
        public List<PlayerDto> Players { get; set; }
    }
}
