using Microsoft.AspNetCore.Mvc;
using CustomerServiceDemo;
using Microsoft.AspNetCore.Authorization;
using HabitTracker.Service.ServiceInterface;
using CustomerServiceApi.Models;
using System.Security.Claims;

namespace CustomerServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerServiceController : ControllerBase
    {
        

        private readonly ILogger<CustomerServiceController> _logger;
        private readonly IWhoAreUService _whoAreUService;


        public CustomerServiceController(ILogger<CustomerServiceController> logger, IWhoAreUService whoAreUService)
        {
            _logger = logger;
            _whoAreUService = whoAreUService;

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _whoAreUService.CheckUser(model.UserName, model.Password);
            if (user == null)
                return BadRequest("Uneti pogrešni podaci");

            var token = _whoAreUService.GenerateJwtToken(user.UserName, user.UserID);

            return Ok(token);
        }


        [HttpGet("getCustomerData")]
        public async Task<IActionResult> GetDataAsync([FromQuery] string id)
        {
            try
            {
                using (var client = new SOAPDemoSoapClient())
                {
                    var person = await client.FindPersonAsync(id);

                    if (person != null)
                    {
                        return Ok(person);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
      


    }
}
