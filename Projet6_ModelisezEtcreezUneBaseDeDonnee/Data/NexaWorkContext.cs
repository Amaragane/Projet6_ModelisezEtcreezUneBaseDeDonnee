using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Models;
using System.Reflection.Metadata;
using System.Net.Sockets;
namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Data
{
    public class NexaWorksContext : DbContext
    {
        public NexaWorksContext(DbContextOptions<NexaWorksContext> options)
            : base(options)
        {

        }
        public DbSet<ProductModele> Products { get; set; }
        public DbSet<VersionModele> Versions { get; set; }
        public DbSet<OsModele> Os { get; set; }
        public DbSet<TicketModele> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Os Master Data
            modelBuilder.Entity<OsModele>().HasData(
                new OsModele { OsId = 1, OsName = "Linux" },
                new OsModele { OsId = 2, OsName = "Windows" },
                new OsModele { OsId = 3, OsName = "MacOS" },
                new OsModele { OsId = 4, OsName = "Android" },
                new OsModele { OsId = 5, OsName = "iOS" },
                new OsModele { OsId = 6, OsName = "WindowsMobile" }
            );
            // Seed Product Master Data
            modelBuilder.Entity<ProductModele>().HasData(
                new ProductModele { ProductId = 1, ProductName = "Trader en Herbe" },
                new ProductModele { ProductId = 2, ProductName = "Maître des Investissements"},
                new ProductModele { ProductId = 3, ProductName = "Plannificateurs d'entraînements"},
                new ProductModele { ProductId = 4, ProductName = "Planificateur d’Anxiété Sociale" }
            );
            // Seed Version Master Data
            modelBuilder.Entity<VersionModele>().HasData(
                new VersionModele { VersionId = 1, VersionName = 1.0 },
                new VersionModele { VersionId = 2, VersionName = 1.1 },
                new VersionModele { VersionId = 3, VersionName = 1.2 },
                new VersionModele { VersionId = 4, VersionName = 1.3 },
                new VersionModele { VersionId = 5, VersionName = 2.0 },
                new VersionModele { VersionId = 6, VersionName = 2.1 }
            );
            modelBuilder.Entity<VersionModele>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Versions)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configuration des relations pour Ticket
            modelBuilder.Entity<TicketModele>()
                .HasOne(t => t.Version)
                .WithMany(v => v.Tickets)
                .HasForeignKey(t => t.VersionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketModele>()
                .HasOne(t => t.Os)
                .WithMany(os => os.Tickets)
                .HasForeignKey(t => t.OsId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
