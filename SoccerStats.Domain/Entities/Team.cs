using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerStats.Domain.Entities
{
    public class Team : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }

        public List<Match> Matches { get; set; }

        public List<Player> Players { get; set; }
    }
}
