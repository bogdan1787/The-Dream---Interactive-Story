using System.Threading.Tasks;
using StoryTeller.Backend.Decisions.Model;

namespace StoryTeller.Backend.Decisions
{
    public interface IDecisionService
    {
        Task InsertDecisionsTaken(DecisionsTakenStatisticsEntity decisionsTaken);
        Task<int> GetDecisionsTakenStatistics(DecisionsTakenStatisticsEntity decisionsTaken);

    }
}
