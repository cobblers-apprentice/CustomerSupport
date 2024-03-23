using CustomerServiceApi.Models;

namespace CustomerServiceApi.Service.Interface
{
    public interface IAgentService
    {
        IEnumerable<Agent> GetAgents();
        Task<int?> GetAgentIdByUserId(int userId);

    }
}
