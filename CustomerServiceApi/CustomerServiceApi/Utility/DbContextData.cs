using CustomerServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApi.Utility

{
    public class DbContextData : DbContext

    {
        public DbContextData(DbContextOptions<DbContextData> options)
             : base(options) { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
