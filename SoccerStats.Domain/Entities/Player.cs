using SoccerStats.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerStats.Domain
{
    public class Player : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public int BackNumber { get; set; }

        public List<PlayerMatchResult> MatchResults { get; set; }

        public List<MatchMoment> Moments { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Team Team{ get; set; }
    }
}
