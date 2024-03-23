using CustomerServiceApi.Models;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Utility;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApi.Repository.Implementation
{
    public class AgentRepository : IAgentRepository
    {
        private readonly DbContextData _context;

        public AgentRepository(DbContextData context)
        {
            _context = context;
        }

        public  IEnumerable<Agent> GetAgents()
        {
            var a = _context.Agents.ToList();
            return a;
        }
        public async Task<int?> GetAgentIdByUserId(int userId)
        {
            var agent = await _context.Users
                .FirstOrDefaultAsync(a => a.UserID == userId);
            return agent?.AgentId;
        }


    }
}
