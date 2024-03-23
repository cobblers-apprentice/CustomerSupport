using CustomerServiceApi.Models;

namespace CustomerServiceApi.Repository.Repository
{
    public interface IAgentRepository
    {
        IEnumerable<Agent> GetAgents();
        Task<int?> GetAgentIdByUserId(int userId);

    }
}
