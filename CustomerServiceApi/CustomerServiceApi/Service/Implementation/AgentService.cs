using CustomerServiceApi.Models;
using CustomerServiceApi.Repository.Implementation;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Service.Interface;

namespace CustomerServiceApi.Service.Implementation
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public  IEnumerable<Agent> GetAgents()
        {
            return  _agentRepository.GetAgents();
        }
        public Task<int?> GetAgentIdByUserId(int userId)
        {
            return _agentRepository.GetAgentIdByUserId(userId);
        }
    }
}
