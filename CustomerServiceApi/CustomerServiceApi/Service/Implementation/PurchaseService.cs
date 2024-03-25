
using CustomerServiceApi.Models;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Service.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public Task<IEnumerable<Purchase>> SavePurchases(IEnumerable<Purchase> purchases)
        {
            return _purchaseRepository.SavePurchases(purchases);
        }
    }
}
