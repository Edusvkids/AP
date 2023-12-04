using HGAPI.Models.EN;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Crypto.ArqLimpia.DAL
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<ProductGames> Cryptocurrencies { get; set; }
        public DbSet<ProductGames> CryptoOrder { get; set; }

        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductGames>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18, 2)"); // Especifica la precisión y la escala de la columna price

            modelBuilder.Entity<ProductGames>()
                .Property(o => o.Total)
                .HasColumnType("decimal(24, 2)"); // Especifica la precisión y la escala de la columna Total

        }
    }
}