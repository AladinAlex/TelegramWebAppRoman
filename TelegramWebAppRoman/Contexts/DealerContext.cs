using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using TelegramWebAppRoman.Contexts.Enums;
using TelegramWebAppRoman.Domain;

namespace TelegramWebAppRoman.Contexts
{
    public class DealerContext : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Item> Items { get; set; }

        public DealerContext(DbContextOptions<DealerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Catalog>(c =>
            {
                c.ToTable(nameof(Catalog), DbSchema.Dealer);
                c.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired().UseSerialColumn();
                c.Property(x => x.Name).HasColumnType("character varying").IsRequired();
                c.Property(x => x.isActive).HasColumnType("boolean").HasDefaultValueSql("true");
            });

            builder.Entity<Item>(c =>
            {
                c.ToTable(nameof(Item), DbSchema.Dealer);
                c.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired().UseSerialColumn();
                c.Property(x => x.Title).HasColumnType("character varying").IsRequired();
                c.Property(x => x.Subtitle).HasColumnType("character varying").IsRequired();
                c.Property(x => x.Price).HasPrecision(10, 2).HasColumnType("decimal").IsRequired();
                c.Property(x => x.Image).HasColumnType("character varying").IsRequired();
                c.Property(x => x.isActive).HasColumnType("boolean").HasDefaultValueSql("true");
            });


            builder.Entity<Item>()
                .HasOne(e => e.Catalog)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.CatalogId)
                .IsRequired();

            builder.Entity<Catalog>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Catalog)
                .HasForeignKey(e => e.CatalogId)
                .IsRequired();

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
