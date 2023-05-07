using BookStore.Domain.Common;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Persistence
{
    public class BookStoreDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("BookStoreConnectionString"));
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "WebAPI";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "WebAPI";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
