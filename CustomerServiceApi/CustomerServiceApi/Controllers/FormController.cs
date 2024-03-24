using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HabitTracker.Service.ServiceInterface;
using CustomerServiceApi.Service.Interface;
using CustomerServiceApi.Models;
using System.Threading.Tasks;
using System.Security.Claims;

namespace CustomerServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;
        private readonly IAgentService _agentService;
        private readonly IFormService _formService;

        public FormController(ILogger<FormController> logger, IFormService formService, IAgentService agentService)
        {
            _logger = logger;
            _formService = formService;
            _agentService = agentService;
        }

        [HttpGet("GetFormsByAgentIdAndDate")]
        public async Task<IActionResult> GetFormsByAgentIdAndDate()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID.");
            }
            var agentId = await _agentService.GetAgentIdByUserId(userId);

            var forms = await _formService.GetFormsByAgentIdAndDate(agentId ?? 0, DateTime.Now);
            return Ok(forms);
        }
        [HttpGet("getAgentId")]
        public async Task<IActionResult> GetAgentId()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID.");
            }
            var agentId = await _agentService.GetAgentIdByUserId(userId);
            
            return Ok(agentId);
        }

        [HttpPost("SaveForm")]
        public async Task<IActionResult> SaveForm([FromBody] Form form)
        {
            var savedForm = await _formService.SaveForm(form);
            return Ok(savedForm);
        }

        [HttpDelete("DeleteForm/{formId}")]
        public async Task<IActionResult> DeleteForm(int formId)
        {
            var result = await _formService.DeleteForm(formId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound($"Form with ID {formId} not found.");
            }
        }
    }
}
