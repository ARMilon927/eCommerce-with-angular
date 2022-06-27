using EasyShopping.Core.Model.Product;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Infrastructure.Database
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
