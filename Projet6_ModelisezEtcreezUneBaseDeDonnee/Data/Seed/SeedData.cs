using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Models;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Data.Seed
{
    public static class SeedData
    {
        /// <summary>
        /// Configure toutes les données d'amorçage pour la base de données
        /// </summary>
        /// <param name="modelBuilder">Le ModelBuilder à configurer</param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            SeedOs(modelBuilder);
            SeedProducts(modelBuilder);
            SeedVersions(modelBuilder);
            SeedVersionOsSupport(modelBuilder);
        }

        /// <summary>
        /// Amorçage des systèmes d'exploitation
        /// </summary>
        private static void SeedOs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OsModele>().HasData(
                new OsModele 
                { 
                    OsId = 1, 
                    OsName = "Linux", 
                    Description = "Système d'exploitation open source basé sur le noyau Linux" 
                },
                new OsModele 
                { 
                    OsId = 2, 
                    OsName = "Windows", 
                    Description = "Système d'exploitation Microsoft Windows" 
                },
                new OsModele 
                { 
                    OsId = 3, 
                    OsName = "MacOS", 
                    Description = "Système d'exploitation Apple pour ordinateurs Mac" 
                },
                new OsModele 
                { 
                    OsId = 4, 
                    OsName = "Android", 
                    Description = "Système d'exploitation mobile basé sur Linux" 
                },
                new OsModele 
                { 
                    OsId = 5, 
                    OsName = "iOS", 
                    Description = "Système d'exploitation mobile Apple" 
                },
                new OsModele 
                { 
                    OsId = 6, 
                    OsName = "WindowsMobile", 
                    Description = "Système d'exploitation mobile Microsoft" 
                }
            );
        }

        /// <summary>
        /// Amorçage des produits
        /// </summary>
        private static void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModele>().HasData(
                new ProductModele 
                { 
                    ProductId = 1, 
                    ProductName = "Trader en Herbe", 
                    Description = "Application de trading pour débutants avec fonctionnalités d'apprentissage" 
                },
                new ProductModele 
                { 
                    ProductId = 2, 
                    ProductName = "Maître des Investissements", 
                    Description = "Application de trading avancée avec outils d'analyse professionnels" 
                },
                new ProductModele 
                { 
                    ProductId = 3, 
                    ProductName = "Planificateur d'Entraînement", 
                    Description = "Application de planification et suivi d'activités sportives" 
                },
                new ProductModele 
                { 
                    ProductId = 4, 
                    ProductName = "Planificateur d'Anxiété Sociale", 
                    Description = "Application d'aide à la gestion de l'anxiété et du stress social" 
                }
            );
        }

        /// <summary>
        /// Amorçage des versions
        /// </summary>
        private static void SeedVersions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VersionModele>().HasData(
                // Trader en Herbe - ProductId = 1
                new VersionModele 
                { 
                    VersionId = 1, 
                    VersionName = 1.0, 
                    ProductId = 1, 
                    Description = "Version initiale - Trader en Herbe" 
                },
                new VersionModele 
                { 
                    VersionId = 2, 
                    VersionName = 1.1, 
                    ProductId = 1, 
                    Description = "Première mise à jour - Trader en Herbe" 
                },
                new VersionModele 
                { 
                    VersionId = 3, 
                    VersionName = 1.2, 
                    ProductId = 1, 
                    Description = "Deuxième mise à jour - Trader en Herbe" 
                },
                new VersionModele 
                { 
                    VersionId = 4, 
                    VersionName = 1.3, 
                    ProductId = 1, 
                    Description = "Troisième mise à jour - Trader en Herbe" 
                },

                // Maître des Investissements - ProductId = 2
                new VersionModele 
                { 
                    VersionId = 5, 
                    VersionName = 1.0, 
                    ProductId = 2, 
                    Description = "Version initiale - Maître des Investissements" 
                },
                new VersionModele 
                { 
                    VersionId = 6, 
                    VersionName = 2.0, 
                    ProductId = 2, 
                    Description = "Version majeure 2.0 - Maître des Investissements" 
                },
                new VersionModele 
                { 
                    VersionId = 7, 
                    VersionName = 2.1, 
                    ProductId = 2, 
                    Description = "Mise à jour 2.1 - Maître des Investissements" 
                },

                // Planificateur d'Entraînement - ProductId = 3
                new VersionModele 
                { 
                    VersionId = 8, 
                    VersionName = 1.0, 
                    ProductId = 3, 
                    Description = "Version initiale - Planificateur d'Entraînement" 
                },
                new VersionModele 
                { 
                    VersionId = 9, 
                    VersionName = 1.1, 
                    ProductId = 3, 
                    Description = "Première mise à jour - Planificateur d'Entraînement" 
                },
                new VersionModele 
                { 
                    VersionId = 10, 
                    VersionName = 2.0, 
                    ProductId = 3, 
                    Description = "Version majeure 2.0 - Planificateur d'Entraînement" 
                },

                // Planificateur d'Anxiété Sociale - ProductId = 4
                new VersionModele 
                { 
                    VersionId = 11, 
                    VersionName = 1.0, 
                    ProductId = 4, 
                    Description = "Version initiale - Planificateur d'Anxiété Sociale" 
                },
                new VersionModele 
                { 
                    VersionId = 12, 
                    VersionName = 1.1, 
                    ProductId = 4, 
                    Description = "Première mise à jour - Planificateur d'Anxiété Sociale" 
                }
            );
        }

        /// <summary>
        /// Amorçage des relations Version-OS (Many-to-Many)
        /// Basé sur le tableau de compatibilité fourni
        /// </summary>
        private static void SeedVersionOsSupport(ModelBuilder modelBuilder)
        {
            // Utilisation de la syntaxe EF Core pour les relations Many-to-Many automatiques
            // Le nom de la table de jonction sera automatiquement généré : "OsModeleVersionModele"
            modelBuilder.Entity("OsModeleVersionModele").HasData(
                
                // Trader en Herbe 1.0 - Linux, MacOS
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 1 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 1 }, // MacOS
                
                // Trader en Herbe 1.1 - Linux, MacOS, Windows
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 2 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 2 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 2 }, // Windows
                
                // Trader en Herbe 1.2 - Tous les OS
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 3 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 3 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 3 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 3 }, // Android
                new { SupportedOsOsId = 5, SupportedVersionsVersionId = 3 }, // iOS
                new { SupportedOsOsId = 6, SupportedVersionsVersionId = 3 }, // Windows Mobile
                
                // Trader en Herbe 1.3 - Linux, MacOS, Windows, Android
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 4 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 4 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 4 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 4 }, // Android
                
                // Maître des Investissements 1.0 - MacOS, iOS
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 5 }, // MacOS
                new { SupportedOsOsId = 5, SupportedVersionsVersionId = 5 }, // iOS
                
                // Maître des Investissements 2.0 - MacOS, Windows, Android
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 6 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 6 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 6 }, // Android
                
                // Maître des Investissements 2.1 - Linux, MacOS, Windows, Android
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 7 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 7 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 7 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 7 }, // Android
                
                // Planificateur d'Entraînement 1.0 - Linux, MacOS
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 8 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 8 }, // MacOS
                
                // Planificateur d'Entraînement 1.1 - Tous les OS
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 9 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 9 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 9 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 9 }, // Android
                new { SupportedOsOsId = 5, SupportedVersionsVersionId = 9 }, // iOS
                new { SupportedOsOsId = 6, SupportedVersionsVersionId = 9 }, // Windows Mobile
                
                // Planificateur d'Entraînement 2.0 - Linux, MacOS, Windows, Android
                new { SupportedOsOsId = 1, SupportedVersionsVersionId = 10 }, // Linux
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 10 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 10 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 10 }, // Android
                
                // Planificateur d'Anxiété Sociale 1.0 - MacOS, Windows, Android, iOS
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 11 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 11 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 11 }, // Android
                new { SupportedOsOsId = 5, SupportedVersionsVersionId = 11 }, // iOS
                
                // Planificateur d'Anxiété Sociale 1.1 - MacOS, Windows, Android, iOS
                new { SupportedOsOsId = 3, SupportedVersionsVersionId = 12 }, // MacOS
                new { SupportedOsOsId = 2, SupportedVersionsVersionId = 12 }, // Windows
                new { SupportedOsOsId = 4, SupportedVersionsVersionId = 12 }, // Android
                new { SupportedOsOsId = 5, SupportedVersionsVersionId = 12 }  // iOS
            );
        }
        /// <summary>
        /// Amorçage des tickets basé sur les données fournies dans le document
        /// </summary>
        private static void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketModele>().HasData(
                // Ticket 1 - Planificateur d'Entraînement 1.1 - iOS
                new TicketModele
                {
                    TicketId = 1,
                    DateCreation = new DateTime(2024, 3, 3),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "L'application se ferme brutalement lors de la tentative d'importation des activités depuis des montres connectées Garmin sur les appareils iOS 17.4 et supérieurs. Les utilisateurs ne peuvent pas intégrer leurs données d'entraînement existantes.",
                    Resolution = "Actuellement en investigation. L'analyse préliminaire suggère un conflit avec la nouvelle politique de sécurité iOS concernant les connexions Bluetooth. L'équipe travaille sur une solution qui maintient la compatibilité tout en respectant les nouvelles restrictions d'Apple.",
                    VersionId = 9, // Planificateur d'Entraînement 1.1
                    OsId = 5 // iOS
                },

                // Ticket 2 - Planificateur d'Entraînement 1.1 - Windows Mobile
                new TicketModele
                {
                    TicketId = 2,
                    DateCreation = new DateTime(2024, 3, 15),
                    DateResolution = new DateTime(2024, 3, 28),
                    Statut = "Résolu",
                    Description = "Les rappels d'entraînement programmés ne déclenchent pas de vibration sur les appareils Windows Mobile, uniquement une notification visuelle facilement manquée.",
                    Resolution = "Correction de l'implémentation des notifications pour utiliser correctement l'API de vibration de Windows Mobile. Ajout d'un paramètre permettant à l'utilisateur de personnaliser l'intensité et la durée des vibrations. Implémentation d'un mode \"ne pas déranger\" configurable par plages horaires.",
                    VersionId = 9, // Planificateur d'Entraînement 1.1
                    OsId = 6 // Windows Mobile
                },

                // Ticket 3 - Planificateur d'Entraînement 2.0 - MacOS
                new TicketModele
                {
                    TicketId = 3,
                    DateCreation = new DateTime(2024, 4, 5),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Fuite de mémoire critique identifiée lors de l'utilisation prolongée. L'application peut consommer jusqu'à 8 Go de RAM après quelques heures d'utilisation, ralentissant considérablement le système.",
                    Resolution = "Analyse en cours avec des outils de profilage mémoire. Plusieurs sources potentielles identifiées dans le gestionnaire de modèles 3D pour la visualisation des exercices. Un correctif temporaire est en développement pour libérer périodiquement la mémoire, tandis qu'une solution permanente nécessite une refonte plus importante de l'architecture.",
                    VersionId = 10, // Planificateur d'Entraînement 2.0
                    OsId = 3 // MacOS
                },

                // Ticket 4 - Planificateur d'Entraînement 2.0 - Windows
                new TicketModele
                {
                    TicketId = 4,
                    DateCreation = new DateTime(2024, 4, 12),
                    DateResolution = new DateTime(2024, 4, 25),
                    Statut = "Résolu",
                    Description = "Incompatibilité avec les pilotes graphiques NVIDIA récents (série 550 et supérieure). Artefacts visuels et flickering lors de l'affichage des modèles d'exercices en 3D.",
                    Resolution = "Mise à jour du moteur de rendu 3D pour contourner un bug dans les pilotes NVIDIA. Implémentation d'une solution de repli utilisant DirectX 11 au lieu de DirectX 12 lorsque des problèmes sont détectés. Collaboration avec l'équipe NVIDIA pour résoudre le problème de manière permanente dans les futures mises à jour des pilotes.",
                    VersionId = 10, // Planificateur d'Entraînement 2.0
                    OsId = 2 // Windows
                },

                // Ticket 5 - Planificateur d'Entraînement 2.0 - Android
                new TicketModele
                {
                    TicketId = 5,
                    DateCreation = new DateTime(2024, 4, 20),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Disparition aléatoire des données historiques d'entraînement sur certains appareils Android 13. Les utilisateurs perdent leur historique sans action spécifique de leur part.",
                    Resolution = "Problème complexe en cours d'investigation. Les tests initiaux suggèrent une interaction problématique entre le système de stockage de l'application et le gestionnaire de stockage scoped d'Android 13. Une solution de contournement temporaire a été mise en place via une sauvegarde cloud automatique, mais la résolution définitive nécessite des modifications architecturales importantes.",
                    VersionId = 10, // Planificateur d'Entraînement 2.0
                    OsId = 4 // Android
                },

                // Ticket 6 - Planificateur d'Entraînement 2.0 - iOS
                new TicketModele
                {
                    TicketId = 6,
                    DateCreation = new DateTime(2024, 4, 25),
                    DateResolution = new DateTime(2024, 5, 10),
                    Statut = "Résolu",
                    Description = "Le suivi GPS des activités en extérieur est inexact sur iOS, avec des écarts de distance pouvant atteindre 30% par rapport aux mesures réelles ou à d'autres applications.",
                    Resolution = "Refonte complète du module de suivi GPS avec implémentation d'algorithmes de filtrage plus sophistiqués. Optimisation de la fréquence d'échantillonnage pour équilibrer précision et consommation de batterie. Ajout d'une calibration automatique basée sur les habitudes de course de l'utilisateur. Les tests montrent une amélioration de la précision à moins de 3% d'écart.",
                    VersionId = 10, // Planificateur d'Entraînement 2.0
                    OsId = 5 // iOS
                },

                // Ticket 7 - Planificateur d'Anxiété Sociale 1.0 - Windows
                new TicketModele
                {
                    TicketId = 7,
                    DateCreation = new DateTime(2024, 2, 8),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Les enregistrements audio des exercices de relaxation sont systématiquement corrompus après installation sur Windows 11. L'audio est saccadé et inintelligible.",
                    Resolution = "Investigation en cours sur un conflit potentiel avec le nouveau codec audio de Windows 11. Tests en cours avec des formats audio alternatifs et différentes méthodes de lecture. Une version bêta avec solution temporaire est disponible pour les utilisateurs affectés, utilisant un moteur audio tiers au lieu des API système.",
                    VersionId = 11, // Planificateur d'Anxiété Sociale 1.0
                    OsId = 2 // Windows
                },

                // Ticket 8 - Planificateur d'Anxiété Sociale 1.0 - Android
                new TicketModele
                {
                    TicketId = 8,
                    DateCreation = new DateTime(2024, 2, 15),
                    DateResolution = new DateTime(2024, 3, 5),
                    Statut = "Résolu",
                    Description = "Les exercices de méditation guidée sont interrompus par les notifications système malgré l'activation du mode \"Ne pas déranger\" dans l'application.",
                    Resolution = "Implémentation d'une intégration directe avec l'API \"Ne pas déranger\" d'Android pour activer automatiquement le mode système lors des sessions. Ajout d'options de personnalisation permettant de filtrer certaines notifications prioritaires. Optimisation de la reprise des exercices en cas d'interruption inévitable.",
                    VersionId = 11, // Planificateur d'Anxiété Sociale 1.0
                    OsId = 4 // Android
                },

                // Ticket 9 - Planificateur d'Anxiété Sociale 1.1 - MacOS
                new TicketModele
                {
                    TicketId = 9,
                    DateCreation = new DateTime(2024, 3, 10),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Vulnérabilité de sécurité critique : les journaux personnels des utilisateurs sont stockés en texte clair et accessibles sans authentification si l'on accède physiquement à l'appareil.",
                    Resolution = "En cours de correction prioritaire. Développement d'un système de chiffrement transparent des données sensibles avec authentification biométrique ou par mot de passe. Migration des données existantes vers le nouveau format sécurisé. Un audit de sécurité externe a été commandé pour valider la solution avant déploiement.",
                    VersionId = 12, // Planificateur d'Anxiété Sociale 1.1
                    OsId = 3 // MacOS
                },

                // Ticket 10 - Planificateur d'Anxiété Sociale 1.1 - Windows
                new TicketModele
                {
                    TicketId = 10,
                    DateCreation = new DateTime(2024, 3, 15),
                    DateResolution = new DateTime(2024, 3, 30),
                    Statut = "Résolu",
                    Description = "Les rappels pour les exercices programmés n'apparaissent pas dans le Centre de notifications Windows, rendant l'application moins efficace pour la formation aux habitudes quotidiennes.",
                    Resolution = "Refonte complète du système de notification pour utiliser l'API Windows Toast moderne au lieu de l'ancien système. Ajout d'options de personnalisation avancées pour l'apparence et le comportement des notifications. Implémentation d'un système de rappels progressifs dont l'insistance augmente si les exercices sont régulièrement ignorés.",
                    VersionId = 12, // Planificateur d'Anxiété Sociale 1.1
                    OsId = 2 // Windows
                },

                // Ticket 11 - Trader en Herbe 1.0 - Linux
                new TicketModele
                {
                    TicketId = 11,
                    DateCreation = new DateTime(2024, 1, 5),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Problème de sécurité : les mots de passe sont stockés en clair dans un fichier de configuration accessible. Risque de compromission des comptes utilisateurs.",
                    Resolution = "Analyse en cours. Solution planifiée pour implémenter un stockage sécurisé avec chiffrement AES-256. Mise en place d'un mécanisme de migration automatique des identifiants existants vers le nouveau système sécurisé. La correction est en phase finale de tests et sera déployée après l'audit de sécurité externe.",
                    VersionId = 1, // Trader en Herbe 1.0
                    OsId = 1 // Linux
                },

                // Ticket 12 - Maître des Investissements 1.0 - iOS
                new TicketModele
                {
                    TicketId = 12,
                    DateCreation = new DateTime(2024, 1, 15),
                    DateResolution = new DateTime(2024, 2, 2),
                    Statut = "Résolu",
                    Description = "Dégradation progressive des performances sur iPad : l'application devient de plus en plus lente à chaque session jusqu'à devenir inutilisable, nécessitant une réinstallation.",
                    Resolution = "Correction d'un problème dans le système de cache qui accumulait des données sans jamais les purger. Implémentation d'un mécanisme intelligent de gestion de cache avec limite de taille configurable et nettoyage automatique lors de la fermeture de l'application. Ajout d'une option dans les paramètres permettant à l'utilisateur de vider manuellement le cache.",
                    VersionId = 5, // Maître des Investissements 1.0
                    OsId = 5 // iOS
                },

                // Ticket 13 - Planificateur d'Anxiété Sociale 1.1 - iOS
                new TicketModele
                {
                    TicketId = 13,
                    DateCreation = new DateTime(2024, 3, 15),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Les utilisateurs signalent l'apparition de publicités intrusives malgré l'achat de la version premium sans publicité. Les annonces apparaissent aléatoirement pendant les exercices de méditation.",
                    Resolution = "Problème prioritaire en cours d'investigation. L'analyse préliminaire suggère un conflit avec la dernière mise à jour du framework publicitaire tiers. Une solution temporaire consiste à désactiver complètement le module publicitaire en attendant une correction permanente. L'équipe développe actuellement un correctif d'urgence qui sera déployé d'ici 7 jours.",
                    VersionId = 12, // Planificateur d'Anxiété Sociale 1.1
                    OsId = 5 // iOS
                },

                // Ticket 14 - Trader en Herbe 1.2 - Windows
                new TicketModele
                {
                    TicketId = 14,
                    DateCreation = new DateTime(2024, 3, 3),
                    DateResolution = new DateTime(2024, 3, 22),
                    Statut = "Résolu",
                    Description = "Arrêts inattendus de l'application lors de l'ouverture simultanée de plus de trois graphiques de tendance. Message d'erreur indiquant \"Ressources insuffisantes\".",
                    Resolution = "Optimisation majeure de la gestion des ressources graphiques avec mise en place d'un système de mise en cache intelligente. Implémentation d'un mécanisme de rendu adaptatif qui ajuste automatiquement la qualité et la fréquence de rafraîchissement des graphiques en fonction des capacités matérielles détectées. Amélioration de 70% de l'utilisation mémoire et réduction de 60% de l'utilisation CPU.",
                    VersionId = 3, // Trader en Herbe 1.2
                    OsId = 2 // Windows
                },

                // Ticket 15 - Maître des Investissements 2.1 - Android
                new TicketModele
                {
                    TicketId = 15,
                    DateCreation = new DateTime(2024, 4, 12),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Synchronisation défectueuse entre appareils : les modifications du portefeuille effectuées sur Android ne sont pas reflétées sur les autres plateformes (iOS, Web) malgré une connexion internet stable.",
                    Resolution = "Investigation en cours. Les journaux serveur montrent des incohérences dans les jetons d'authentification entre plateformes, entraînant des rejets de synchronisation. L'équipe backend travaille sur une refonte du système de synchronisation multi-appareils avec un nouveau protocole de validation et résolution de conflits. Une version test est en cours de déploiement pour validation interne.",
                    VersionId = 7, // Maître des Investissements 2.1
                    OsId = 4 // Android
                },

                // Ticket 16 - Trader en Herbe 1.1 - Linux
                new TicketModele
                {
                    TicketId = 16,
                    DateCreation = new DateTime(2024, 2, 7),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Échec du démarrage de l'application sur les distributions Linux basées sur Fedora 39. L'application affiche un message d'erreur concernant des bibliothèques Qt incompatibles avant de se fermer.",
                    Resolution = "Investigation en cours. Tests préliminaires indiquent une incompatibilité avec la nouvelle version de la bibliothèque Qt 6.6 incluse dans Fedora 39. L'équipe travaille sur deux approches parallèles : une solution de compatibilité pour Qt 6.6 et un package contenant toutes les dépendances nécessaires en version compatible, à distribuer avec l'application.",
                    VersionId = 2, // Trader en Herbe 1.1
                    OsId = 1 // Linux
                },

                // Ticket 17 - Trader en Herbe 1.2 - MacOS
                new TicketModele
                {
                    TicketId = 17,
                    DateCreation = new DateTime(2024, 2, 15),
                    DateResolution = new DateTime(2024, 3, 3),
                    Statut = "Résolu",
                    Description = "Les utilisateurs de MacBook Pro M2 signalent une surchauffe excessive lors de l'utilisation intensive de l'application. La température du CPU peut atteindre 95°C, déclenchant les ventilateurs à pleine vitesse et réduisant l'autonomie de la batterie.",
                    Resolution = "Optimisation majeure du code de rendu graphique pour les architectures ARM. Implémentation d'un mécanisme de limitation de fréquence d'images adaptatif qui réduit la charge CPU lorsque l'application n'est pas en premier plan ou lors d'une inactivité utilisateur. Ajout d'un mode économie d'énergie optionnel qui privilégie l'autonomie à la fluidité des animations. Tests montrent une réduction de 40% de la consommation CPU et une diminution de température moyenne de 15°C.",
                    VersionId = 3, // Trader en Herbe 1.2
                    OsId = 3 // MacOS
                },

                // Ticket 18 - Trader en Herbe 1.3 - Windows
                new TicketModele
                {
                    TicketId = 18,
                    DateCreation = new DateTime(2024, 3, 10),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Faille de sécurité critique identifiée : l'intégration avec le navigateur web stocke temporairement les données des transactions dans un fichier non chiffré accessible par d'autres applications. Risque d'extraction de données sensibles par des logiciels malveillants.",
                    Resolution = "Équipe de sécurité mobilisée en priorité. Développement d'un correctif d'urgence qui implémente un stockage temporaire en mémoire encryptée au lieu d'utiliser le système de fichiers. Audit de sécurité complet en cours sur toutes les fonctionnalités impliquant des données sensibles. Publication d'un avertissement de sécurité et recommandations temporaires aux utilisateurs en attendant le déploiement de la mise à jour.",
                    VersionId = 4, // Trader en Herbe 1.3
                    OsId = 2 // Windows
                },

                // Ticket 19 - Maître des Investissements 1.0 - MacOS
                new TicketModele
                {
                    TicketId = 19,
                    DateCreation = new DateTime(2024, 1, 20),
                    DateResolution = new DateTime(2024, 2, 5),
                    Statut = "Résolu",
                    Description = "Support incomplet des fonctionnalités d'accessibilité MacOS. Les utilisateurs de VoiceOver ne peuvent pas naviguer efficacement dans l'interface ou accéder à certaines fonctionnalités essentielles comme la configuration des alertes de prix.",
                    Resolution = "Refonte complète de l'interface utilisateur avec implémentation des contrôles d'accessibilité d'Apple. Ajout de descriptions détaillées pour tous les éléments d'interface et de raccourcis clavier alternatifs pour les actions principales. Optimisation des flux de navigation pour VoiceOver. Tests d'accessibilité réalisés avec des utilisateurs malvoyants pour valider les améliorations. Mise en place d'un processus de validation d'accessibilité pour toutes les futures fonctionnalités.",
                    VersionId = 5, // Maître des Investissements 1.0
                    OsId = 3 // MacOS
                },

                // Ticket 20 - Maître des Investissements 2.0 - Android
                new TicketModele
                {
                    TicketId = 20,
                    DateCreation = new DateTime(2024, 3, 1),
                    DateResolution = new DateTime(2024, 3, 15),
                    Statut = "Résolu",
                    Description = "La fonctionnalité de capture d'écran et partage sur réseaux sociaux échoue sur Android 14. L'application affiche une erreur \"Accès refusé\" malgré les autorisations accordées.",
                    Resolution = "Adaptation de la fonctionnalité de capture et partage aux nouvelles restrictions de sécurité d'Android 14 concernant l'accès au contenu de l'écran. Mise à jour de la méthode de demande d'autorisation avec utilisation du nouveau framework de permissions granulaires. Ajout d'un mode de partage alternatif qui génère une image à partir des données internes plutôt que de capturer l'écran. Amélioration des messages d'erreur avec instructions spécifiques pour chaque version d'Android.",
                    VersionId = 6, // Maître des Investissements 2.0
                    OsId = 4 // Android
                },

                // Ticket 21 - Maître des Investissements 2.1 - Windows
                new TicketModele
                {
                    TicketId = 21,
                    DateCreation = new DateTime(2024, 3, 17),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Multiples erreurs d'affichage sur les configurations multi-écrans. Les fenêtres flottantes d'analyse apparaissent au mauvais endroit ou sont partiellement visibles lorsqu'elles sont déplacées entre écrans avec des résolutions différentes.",
                    Resolution = "Investigation en cours sur les problèmes de gestion de fenêtres dans des configurations d'affichage complexes. Tests réalisés avec diverses combinaisons de résolutions et échelles DPI. Solution envisagée implique une refonte du système de positionnement des fenêtres avec détection et ajustement automatique aux caractéristiques de chaque écran. Développement d'un mode de test permettant de simuler diverses configurations d'affichage.",
                    VersionId = 7, // Maître des Investissements 2.1
                    OsId = 2 // Windows
                },

                // Ticket 22 - Planificateur d'Entraînement 1.0 - Linux
                new TicketModele
                {
                    TicketId = 22,
                    DateCreation = new DateTime(2024, 1, 25),
                    DateResolution = new DateTime(2024, 2, 8),
                    Statut = "Résolu",
                    Description = "L'application n'utilise pas les thèmes système sous GNOME et KDE, générant un contraste insuffisant en mode sombre et des problèmes de lisibilité des graphiques d'évolution des performances.",
                    Resolution = "Implémentation de la détection automatique du thème système sur les environnements de bureau Linux. Adaptation dynamique des palettes de couleurs pour maintenir un contraste optimal quel que soit le thème. Refonte des graphiques avec des couleurs adaptatives qui s'ajustent automatiquement aux préférences d'affichage de l'utilisateur. Ajout de préréglages de couleurs alternatifs pour les utilisateurs daltoniennes ou ayant des besoins visuels spécifiques.",
                    VersionId = 8, // Planificateur d'Entraînement 1.0
                    OsId = 1 // Linux
                },

                // Ticket 23 - Planificateur d'Entraînement 1.1 - Android
                new TicketModele
                {
                    TicketId = 23,
                    DateCreation = new DateTime(2024, 2, 12),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Consommation excessive de batterie en raison de l'utilisation continue du GPS même lorsque l'utilisateur n'est pas en activité. Certains utilisateurs rapportent jusqu'à 40% de batterie consommée en une journée par l'application en arrière-plan.",
                    Resolution = "Analyse approfondie en cours du cycle de vie de l'application et de la gestion des capteurs. Développement d'un système intelligent de détection d'activité qui n'active le GPS que lorsque nécessaire. Implémentation d'un algorithme de prédiction qui anticipe les périodes d'entraînement basées sur les habitudes de l'utilisateur. Tests en cours avec diverses intensités d'utilisation pour mesurer l'impact des optimisations. Première version bêta du correctif disponible pour les testeurs volontaires.",
                    VersionId = 9, // Planificateur d'Entraînement 1.1
                    OsId = 4 // Android
                },

                // Ticket 24 - Planificateur d'Anxiété Sociale 1.0 - Android
                new TicketModele
                {
                    TicketId = 24,
                    DateCreation = new DateTime(2024, 2, 20),
                    DateResolution = new DateTime(2024, 3, 5),
                    Statut = "Résolu",
                    Description = "Échec des enregistrements audio dans le journal des émotions sur les appareils Samsung utilisant One UI 6. L'application se fige pendant plusieurs secondes avant d'afficher une erreur \"Périphérique audio non disponible\".",
                    Resolution = "Correction d'un problème d'incompatibilité avec l'API d'enregistrement audio modifiée dans One UI 6. Implémentation d'une détection automatique de la version de l'interface Samsung et utilisation de l'API appropriée selon le système. Ajout d'un mécanisme de secours qui bascule sur une méthode d'enregistrement alternative en cas d'échec de la méthode principale. Amélioration des messages d'erreur avec suggestions de résolution spécifiques pour chaque modèle d'appareil.",
                    VersionId = 11, // Planificateur d'Anxiété Sociale 1.0
                    OsId = 4 // Android
                },

                // Ticket 25 - Planificateur d'Anxiété Sociale 1.1 - iOS
                new TicketModele
                {
                    TicketId = 25,
                    DateCreation = new DateTime(2024, 4, 5),
                    DateResolution = null,
                    Statut = "En cours",
                    Description = "Disparition des données après restauration de l'appareil ou transfert vers un nouvel iPhone. La sauvegarde iCloud ne semble pas préserver correctement les journaux personnels et les statistiques d'évolution.",
                    Resolution = "Investigation en cours sur l'implémentation de CloudKit. Identification préliminaire d'erreurs dans la structure des données stockées qui empêchent la restauration correcte. Développement d'un utilitaire de récupération qui peut extraire les données des sauvegardes iCloud même en cas de structure incompatible. Refonte du système de stockage cloud avec validation plus stricte des données avant synchronisation et mécanismes de récupération robustes. Beta planifiée pour la semaine prochaine avec les utilisateurs affectés.",
                    VersionId = 12, // Planificateur d'Anxiété Sociale 1.1
                    OsId = 5 // iOS
                }
            );
        }
    }
}