using System;
using System.Collections.Generic;

namespace SoccerStats.Domain.Entities
{
    public class Match : BaseEntity
    {
        public DateTime MatchDate { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } 
        public bool HomeTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public List<MatchMoment> MatchMoments { get; set; }
        public List<PlayerMatchResult> PlayerMatchResults { get; set; }
    }
}
