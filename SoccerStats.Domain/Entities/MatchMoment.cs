using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Domain.Entities
{
    public class MatchMoment : BaseEntity
    {
        public Match Match { get; set; }

        [Required]
        public int MatchId { get; set; }

        public Player Player { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public MomentsEnum Moment { get; set; }

        [Required]
        public int TimeStamp { get; set; }
    }
}
