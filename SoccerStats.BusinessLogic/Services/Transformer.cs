using SoccerStats.BusinessLogic.Services;
using SoccerStats.Domain.DTO;
using SoccerStats.Domain.DTO.GetDto;
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
            var playerModel = model.Players.Select(t => new PlayerDto
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                BackNumber = t.BackNumber,
                //Image = ImageConverter.GetImageFromByteArray(t.Picture)
            }).ToList();

            return new TeamPlayerDto
            {
                TeamName = model.TeamName,
                Players = playerModel
            };
        }
        public GetTeamPlayerDto TransformToGet(Team model)
        {
            var playermodel = model.Players.Select(t => new GetPlayerDto
            {
                FirstName = t.FirstName,
                BackNumber = t.BackNumber,
                LastName = t.LastName,
                Image = t.Picture,
                TeamId = t.TeamId
            }).ToList();

            return new GetTeamPlayerDto
            {
                TeamName = model.TeamName,
                Players = playermodel
            };
        }
        public MatchMomentDto Transform(MatchMoment moment)
        {
            return new MatchMomentDto
            {
                MatchId = moment.MatchId,
                PlayerId = moment.PlayerId,
                TimeStamp = moment.TimeStamp,
                Moment = moment.Moment.ToString(),
            };
        }
        public static T Trans<T>(string value)
            where T : struct
        {
            bool enumParseResult = false;
            T resultInputType = default(T);
            enumParseResult = Enum.TryParse<T>(value, out resultInputType);
            return resultInputType;
        }
        public MatchMoment Transform(MatchMomentDto moment)
        {

            return new MatchMoment
            {
                MatchId = moment.MatchId,
                PlayerId = moment.PlayerId,
                TimeStamp = moment.TimeStamp,
                Moment = Trans<MomentsEnum>(moment.Moment)
            };

        }
    }
}
