
using CustomerServiceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Repository.Repository
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> SavePurchases(IEnumerable<Purchase> purchases);
    }
}
