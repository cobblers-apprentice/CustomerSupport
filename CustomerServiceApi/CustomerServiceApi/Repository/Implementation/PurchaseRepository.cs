
using CustomerServiceApi.Models;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Repository.Implementation
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DbContextData _context;

        public PurchaseRepository(DbContextData context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> SavePurchases(IEnumerable<Purchase> purchases)
        {
            foreach (var purchase in purchases)
            {
                var form = await _context.Forms.FirstOrDefaultAsync(f => f.CustomerId == purchase.CustomerId && f.CreatedDate.Date == purchase.CreatedDate.Date);
                if (form != null)
                {
                    purchase.FormId = form.FormId;
                }

                _context.Purchases.Add(purchase);
            }

            await _context.SaveChangesAsync();
            return purchases;
        }
    }
}
