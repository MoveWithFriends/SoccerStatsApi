using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoccerStats.Domain;
using SoccerStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerStats.Data
{
    public class SoccerStatsContext : DbContext
    {
        public static ILoggerFactory MyConsoleLoggerFactory(Action<ILoggingBuilder> configure)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Name", LogLevel.Information)
                .AddConsole();
            });
            return loggerFactory;
        }


        public SoccerStatsContext(DbContextOptions<SoccerStatsContext> options)
            : base(options)
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerMatchResult> PlayerMatchResults { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchMoment> MatchMoments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerMatchResult>()
                .HasOne(a => a.Player)
                .WithMany(a => a.MatchResults)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayerMatchResult>()
                .HasOne(a => a.Match)
                .WithMany(a => a.PlayerMatchResults)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MatchMoment>()
                .HasOne(a => a.Player)
                .WithMany(a => a.Moments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MatchMoment>()
                .HasOne(a => a.Match)
                .WithMany(a => a.MatchMoments)
                .OnDelete(DeleteBehavior.NoAction);



            var matches = new[]
            {
                new Match{Id = 1, MatchDate = DateTime.Now.AddDays(-7), TeamId = 1, HomeTeam = true, AwayGoals = 0, HomeGoals = 1},
            };

            var players = new[]
            {
                new Player{Id = 1, BackNumber = 7, FirstName = "Nick", LastName = "Sluiters", TeamId = 1},
                new Player{Id = 2, BackNumber = 1, FirstName = "Jurgen", LastName = "Paapen", TeamId = 1},
                new Player{Id = 3, BackNumber = 4, FirstName = "Joost", LastName = "Oomen", TeamId = 1}

            };
            var matchResults = new[]
            {
                new PlayerMatchResult{Id = 1, MatchId = 1, PlayerId = 1, Goals = 1, RedCards = 0, YellowCards = 0},
                new PlayerMatchResult{Id = 2, MatchId = 1, PlayerId = 2, Goals = 0, RedCards = 0, YellowCards = 1},
                new PlayerMatchResult{Id = 3, MatchId = 1, PlayerId = 3, Goals = 0, RedCards = 1, YellowCards = 0}
            };
            var teams = new[]
            {
                new Team {Id = 1, TeamName = "DWO"},
                new Team {Id = 2, TeamName = "Sick"}
            };
            var matchMoments = new[]
            {
                new MatchMoment {Id = 1, PlayerId= 1, MatchId = 1, Moment = MomentsEnum.Goal, TimeStamp = 30},
                new MatchMoment {Id = 2, PlayerId= 2, MatchId = 1, Moment = MomentsEnum.YellowCard, TimeStamp = 40},
                new MatchMoment {Id = 3, PlayerId= 3, MatchId = 1, Moment = MomentsEnum.RedCard, TimeStamp = 60}
            };

            modelBuilder.Entity<Match>().HasData(matches[0]);
            modelBuilder.Entity<Player>().HasData(players[0], players[1], players[2]);
            modelBuilder.Entity<PlayerMatchResult>().HasData(matchResults[0], matchResults[1], matchResults[2]);
            modelBuilder.Entity<Team>().HasData(teams);
            modelBuilder.Entity<MatchMoment>().HasData(matchMoments);

            base.OnModelCreating(modelBuilder);
        }
    }
}
