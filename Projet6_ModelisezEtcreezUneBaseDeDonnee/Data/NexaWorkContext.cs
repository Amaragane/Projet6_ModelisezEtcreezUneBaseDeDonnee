using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Models;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Data.Seed;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Data
{
    public class NexaWorksContext : DbContext
    {
        public NexaWorksContext(DbContextOptions<NexaWorksContext> options)
            : base(options)
        {
        }

        // DbSets pour les entités
        public DbSet<ProductModele> Products { get; set; } = null!;
        public DbSet<VersionModele> Versions { get; set; } = null!;
        public DbSet<OsModele> Os { get; set; } = null!;
        public DbSet<TicketModele> Tickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations
            ConfigureRelationships(modelBuilder);

            // Configuration des indexes et contraintes
            ConfigureIndexesAndConstraints(modelBuilder);

            // Appel de la classe SeedData pour l'amorçage
            SeedData.Configure(modelBuilder);
        }

        /// <summary>
        /// Configure toutes les relations entre les entités
        /// </summary>
        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Relation Product -> Versions (One-to-Many)
            modelBuilder.Entity<VersionModele>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Versions)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation Version <-> OS (Many-to-Many)
            modelBuilder.Entity<VersionModele>()
                .HasMany(v => v.SupportedOs)
                .WithMany(os => os.SupportedVersions)
                .UsingEntity(j => j.ToTable("VersionOsSupport"));

            // Relation Version -> Tickets (One-to-Many)
            modelBuilder.Entity<TicketModele>()
                .HasOne(t => t.Version)
                .WithMany(v => v.Tickets)
                .HasForeignKey(t => t.VersionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation OS -> Tickets (One-to-Many)
            modelBuilder.Entity<TicketModele>()
                .HasOne(t => t.Os)
                .WithMany(os => os.Tickets)
                .HasForeignKey(t => t.OsId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        /// <summary>
        /// Configure les indexes et contraintes pour optimiser les performances et garantir l'intégrité
        /// </summary>
        private static void ConfigureIndexesAndConstraints(ModelBuilder modelBuilder)
        {
            // Index unique pour éviter les doublons Product-Version
            modelBuilder.Entity<VersionModele>()
                .HasIndex(v => new { v.ProductId, v.VersionName })
                .IsUnique()
                .HasDatabaseName("IX_Version_ProductId_VersionName");

            // Index sur les clés étrangères pour améliorer les performances des jointures
            modelBuilder.Entity<TicketModele>()
                .HasIndex(t => t.VersionId)
                .HasDatabaseName("IX_Ticket_VersionId");

            modelBuilder.Entity<TicketModele>()
                .HasIndex(t => t.OsId)
                .HasDatabaseName("IX_Ticket_OsId");

            // Index sur le statut des tickets pour les requêtes de filtrage
            modelBuilder.Entity<TicketModele>()
                .HasIndex(t => t.Statut)
                .HasDatabaseName("IX_Ticket_Statut");

            // Index sur la date de création pour les requêtes de tri chronologique
            modelBuilder.Entity<TicketModele>()
                .HasIndex(t => t.DateCreation)
                .HasDatabaseName("IX_Ticket_DateCreation");
        }
    }
}