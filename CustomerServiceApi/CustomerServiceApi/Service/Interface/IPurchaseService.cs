
using CustomerServiceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Service.Interface
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> SavePurchases(IEnumerable<Purchase> purchases);
    }
}
