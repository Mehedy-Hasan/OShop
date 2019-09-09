using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;

namespace DatabaseContext
{
    public class CustomerDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbQuery<VWOrderInfo> VwOrderInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(local);Database=Ecommerce; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Query<VWOrderInfo>()
                .ToView("VW_OrderInfo");

        }
    }
}
