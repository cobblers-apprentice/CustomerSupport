using Microsoft.AspNetCore.Mvc;
using CustomerServiceApi.Service.Interface;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CustomerServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [HttpGet("getAgents")]
        public  IActionResult GetAgents()
        {
            var agents =  _agentService.GetAgents();
            return Ok(agents);
        }

        [HttpGet("GetAgentIdByUserId")]
        public async Task<IActionResult> GetAgentIdByUserId()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID.");
            }

            var agentId = await _agentService.GetAgentIdByUserId(userId);
            if (agentId.HasValue)
            {
                return Ok(agentId.Value);
            }
            else
            {
                return NotFound($"Agent not found for user ID: {userId}");
            }
        }

    }
}
