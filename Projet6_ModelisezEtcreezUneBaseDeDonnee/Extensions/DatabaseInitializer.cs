using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Data;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Extensions
{
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Initialise la base de données en appliquant les migrations et en chargeant les données de départ
        /// </summary>
        /// <param name="app">L'application web</param>
        /// <returns>L'application web pour permettre le chaînage</returns>
        public static WebApplication InitializeDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<NexaWorksContext>();
                    
                    // Appliquer les migrations en attente
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        Console.WriteLine("Application des migrations en cours...");
                        context.Database.Migrate();
                        Console.WriteLine("Migrations appliquées avec succès !");
                    }
                    
                    // Vérifier si la base de données contient déjà des données
                    if (!context.Products.Any())
                    {
                        Console.WriteLine("Base de données vide détectée. Chargement des données de départ...");
                        // Les données de départ sont déjà configurées dans SeedData et seront appliquées automatiquement
                        Console.WriteLine("Données de départ chargées avec succès !");
                    }
                    else
                    {
                        Console.WriteLine("Base de données déjà initialisée avec des données.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'initialisation de la base de données : {ex.Message}");
                    throw;
                }
            }
            
            return app;
        }

        /// <summary>
        /// Supprime et recrée complètement la base de données (ATTENTION : Perte de données !)
        /// Utilisez uniquement en développement
        /// </summary>
        /// <param name="app">L'application web</param>
        /// <returns>L'application web pour permettre le chaînage</returns>
        public static WebApplication RecreateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<NexaWorksContext>();
                
                Console.WriteLine("ATTENTION : Suppression complète de la base de données...");
                context.Database.EnsureDeleted();
                
                Console.WriteLine("Recréation de la base de données...");
                context.Database.EnsureCreated();
                
                Console.WriteLine("Base de données recréée avec succès avec les données de départ !");
            }
            
            return app;
        }

        /// <summary>
        /// Affiche des statistiques sur le contenu de la base de données
        /// </summary>
        /// <param name="app">L'application web</param>
        /// <returns>L'application web pour permettre le chaînage</returns>
        public static WebApplication DisplayDatabaseStats(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<NexaWorksContext>();
                
                Console.WriteLine("\n=== STATISTIQUES DE LA BASE DE DONNÉES ===");
                Console.WriteLine($"Produits : {context.Products.Count()}");
                Console.WriteLine($"Versions : {context.Versions.Count()}");
                Console.WriteLine($"Systèmes d'exploitation : {context.Os.Count()}");
                Console.WriteLine($"Tickets : {context.Tickets.Count()}");
                
                // Afficher quelques détails
                var ticketsParStatut = context.Tickets
                    .GroupBy(t => t.Statut)
                    .Select(g => new { Statut = g.Key, Nombre = g.Count() })
                    .ToList();
                
                Console.WriteLine("\nTickets par statut :");
                foreach (var item in ticketsParStatut)
                {
                    Console.WriteLine($"  - {item.Statut} : {item.Nombre}");
                }
                Console.WriteLine("==========================================\n");
            }
            
            return app;
        }
    }
}