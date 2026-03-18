using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.Models;

namespace MyAcademyMediatorProject.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Banner> Banners { get; set; }

    }
}
