using Ecommerce_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Core.Initial
{
    public class EcommerceDbContext:DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AddressEntity>(entity =>
            {
                // Xóa User -> xóa Address
                entity.HasOne(a => a.User)
                      .WithMany(u => u.Addresses)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
    }
}
