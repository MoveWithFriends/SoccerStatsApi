using System.ComponentModel.DataAnnotations;

namespace SoccerStats.Domain.Entities
{
    public class PlayerMatchResult : BaseEntity
    {
        [Required]
        public int MatchId { get; set; }

        public Match Match { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int PlayTime { get; set; }
        public int SubTime { get; set; }
        public int? Goals { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
    }
}
