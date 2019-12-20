using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Domain.DTO.GetDto
{
    public class GetTeamPlayerDto
    {
        public string TeamName { get; set; }
        public List<GetPlayerDto> Players { get; set; }
    }
}
