using SoccerStats.Domain.DTO;
using SoccerStats.Domain.DTO.GetDto;
using SoccerStats.Domain.Entities;

namespace SoccerStats.Domain.Services
{
    public interface ITransformer
    {
        TeamPlayerDto Transform(Team model);
        MatchMomentDto Transform(MatchMoment moment);
        GetTeamPlayerDto TransformToGet(Team model);
    }
}