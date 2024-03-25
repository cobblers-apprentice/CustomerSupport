
using CustomerServiceApi.Models;
using CustomerServiceApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost("SavePurchases")]
        public async Task<IActionResult> SavePurchases([FromBody] List<Purchase> purchases)
        {
            var savedPurchases = await _purchaseService.SavePurchases(purchases);
            return Ok(savedPurchases);
        }
    }
}
