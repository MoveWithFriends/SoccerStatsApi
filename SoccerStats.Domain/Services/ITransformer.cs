using SoccerStats.Domain.DTO;
using SoccerStats.Domain.Entities;

namespace SoccerStats.Domain.Services
{
    public interface ITransformer
    {
        TeamPlayerDto Transform(Team model);
    }
}