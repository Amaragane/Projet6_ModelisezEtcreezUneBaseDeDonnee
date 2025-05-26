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
            SeedProductVersionOsSupport(modelBuilder);
            SeedStatuts(modelBuilder);
            SeedTickets(modelBuilder);
        }

        /// <summary>
        /// Amorçage des systèmes d'exploitation
        /// </summary>
        private static void SeedOs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OsModel>().HasData(
                new OsModel 
                { 
                    OsId = 1, 
                    OsName = "Linux", 
                },
                new OsModel 
                { 
                    OsId = 2, 
                    OsName = "Windows", 
                },
                new OsModel 
                { 
                    OsId = 3, 
                    OsName = "MacOS", 
                },
                new OsModel 
                { 
                    OsId = 4, 
                    OsName = "Android", 
                },
                new OsModel 
                { 
                    OsId = 5, 
                    OsName = "iOS", 
                },
                new OsModel 
                { 
                    OsId = 6, 
                    OsName = "WindowsMobile", 
                }
            );
        }

        /// <summary>
        /// Amorçage des produits
        /// </summary>
        private static void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel 
                { 
                    ProductId = 1, 
                    ProductName = "Trader en Herbe", 
                },
                new ProductModel 
                { 
                    ProductId = 2, 
                    ProductName = "Maître des Investissements", 
                },
                new ProductModel 
                { 
                    ProductId = 3, 
                    ProductName = "Planificateur d'Entraînement", 
                },
                new ProductModel 
                { 
                    ProductId = 4, 
                    ProductName = "Planificateur d'Anxiété Sociale", 
                }
            );
        }

        /// <summary>
        /// Amorçage des versions
        /// </summary>
        private static void SeedVersions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VersionModel>().HasData(
                new VersionModel
                {
                    VersionId = 1,
                    VersionName = "1.0",
                },
                new VersionModel
                {
                    VersionId = 2,
                    VersionName = "1.1",
                },
                new VersionModel
                {
                    VersionId = 3,
                    VersionName = "1.2",
                },
                new VersionModel
                {
                    VersionId = 4,
                    VersionName = "1.3",
                },
                new VersionModel
                {
                    VersionId = 5,
                    VersionName = "2.0",
                },
                new VersionModel
                {
                    VersionId = 6,
                    VersionName = "2.1",
                }
            );
        }


        /// <summary>
        /// Amorçage de la table de compatibilité Produit/Version/OS
        /// Basé sur le tableau de compatibilité fourni dans la documentation
        /// </summary>
        private static void SeedProductVersionOsSupport(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVersionOsSupport>().HasData(
                // Trader en Herbe 1.0 - Linux, Windows
                new ProductVersionOsSupport { ProductId = 1, VersionId = 1, OsId = 1 }, // Linux
                new ProductVersionOsSupport { ProductId = 1, VersionId = 1, OsId = 2 }, // Windows
                
                // Trader en Herbe 1.1 - Linux, Windows, MacOS
                new ProductVersionOsSupport { ProductId = 1, VersionId = 2, OsId = 1 }, // Linux
                new ProductVersionOsSupport { ProductId = 1, VersionId = 2, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 1, VersionId = 2, OsId = 3 }, // MacOS
                
                // Trader en Herbe 1.2 - Linux, MacOS, Windows, Android, iOS, Windows Mobile
                new ProductVersionOsSupport { ProductId = 1, VersionId = 3, OsId = 1 }, // Linux
                new ProductVersionOsSupport { ProductId = 1, VersionId = 3, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 1, VersionId = 3, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 1, VersionId = 3, OsId = 4 }, // Android
                new ProductVersionOsSupport { ProductId = 1, VersionId = 3, OsId = 5 }, // iOS
                new ProductVersionOsSupport { ProductId = 1, VersionId = 3, OsId = 6 }, // Windows Mobile
                
                // Trader en Herbe 1.3 - Linux, MacOS, Windows, Android
                new ProductVersionOsSupport { ProductId = 1, VersionId = 4, OsId = 1 }, // Linux
                new ProductVersionOsSupport { ProductId = 1, VersionId = 4, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 1, VersionId = 4, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 1, VersionId = 4, OsId = 4 }, // Android
                
                // Maître des Investissements 1.0 - MacOS, iOS
                new ProductVersionOsSupport { ProductId = 2, VersionId = 1, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 2, VersionId = 1, OsId = 5 }, // iOS
                
                // Maître des Investissements 2.0 - MacOS, Windows, Android
                new ProductVersionOsSupport { ProductId = 2, VersionId = 5, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 2, VersionId = 5, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 2, VersionId = 5, OsId = 4 }, // Android
                
                // Maître des Investissements 2.1 - Windows, MacOS, Android, iOS
                new ProductVersionOsSupport { ProductId = 2, VersionId = 6, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 2, VersionId = 6, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 2, VersionId = 6, OsId = 4 }, // Android
                new ProductVersionOsSupport { ProductId = 2, VersionId = 6, OsId = 5 }, // iOS
                
                // Planificateur d'Entraînement 1.0 - Linux, MacOS
                new ProductVersionOsSupport { ProductId = 3, VersionId = 1, OsId = 1 }, // Linux
                new ProductVersionOsSupport { ProductId = 3, VersionId = 1, OsId = 3 }, // MacOS
                
                // Planificateur d'Entraînement 1.1 - Linux, MacOS, Windows, Android, iOS, Windows Mobile
                new ProductVersionOsSupport { ProductId = 3, VersionId = 2, OsId = 1 }, // Linux
                new ProductVersionOsSupport { ProductId = 3, VersionId = 2, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 3, VersionId = 2, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 3, VersionId = 2, OsId = 4 }, // Android
                new ProductVersionOsSupport { ProductId = 3, VersionId = 2, OsId = 5 }, // iOS
                new ProductVersionOsSupport { ProductId = 3, VersionId = 2, OsId = 6 }, // Windows Mobile
                
                // Planificateur d'Entraînement 2.0 - MacOS, Windows, Android, iOS
                new ProductVersionOsSupport { ProductId = 3, VersionId = 5, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 3, VersionId = 5, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 3, VersionId = 5, OsId = 4 }, // Android
                new ProductVersionOsSupport { ProductId = 3, VersionId = 5, OsId = 5 }, // iOS
                
                // Planificateur d'Anxiété Sociale 1.0 - Windows, MacOS, Android, iOS
                new ProductVersionOsSupport { ProductId = 4, VersionId = 1, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 4, VersionId = 1, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 4, VersionId = 1, OsId = 4 }, // Android
                new ProductVersionOsSupport { ProductId = 4, VersionId = 1, OsId = 5 }, // iOS
                
                // Planificateur d'Anxiété Sociale 1.1 - Windows, MacOS, Android, iOS
                new ProductVersionOsSupport { ProductId = 4, VersionId = 2, OsId = 2 }, // Windows
                new ProductVersionOsSupport { ProductId = 4, VersionId = 2, OsId = 3 }, // MacOS
                new ProductVersionOsSupport { ProductId = 4, VersionId = 2, OsId = 4 }, // Android
                new ProductVersionOsSupport { ProductId = 4, VersionId = 2, OsId = 5 }  // iOS
            );
        }

        /// <summary>
        /// Amorçage des statuts des tickets
        /// </summary>
        private static void SeedStatuts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatutModel>().HasData(
                new StatutModel { StatutId = 1, State = "En cours" },
                new StatutModel { StatutId = 2, State = "Résolu" }
            );
        }

        /// <summary>
        /// Amorçage des tickets basé sur les données fournies dans le document
        /// </summary>

            private static void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketModel>().HasData(
                // Ticket 1 - Planificateur d'Entraînement 1.1 iOS
                new TicketModel
                {
                    TicketId = 1,
                    DateCreation = new DateTime(2024, 3, 3),
                    DateResolution = null,
                    Description = "L'application se ferme brutalement lors de la tentative d'importation des activités depuis des montres connectées Garmin sur les appareils iOS 17.4 et supérieurs. Les utilisateurs ne peuvent pas intégrer leurs données d'entraînement existantes.",
                    Resolution = "Actuellement en investigation. L'analyse préliminaire suggère un conflit avec la nouvelle politique de sécurité iOS concernant les connexions Bluetooth. L'équipe travaille sur une solution qui maintient la compatibilité tout en respectant les nouvelles restrictions d'Apple.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 2, // 1.1
                    OsId = 5,      // iOS
                    StatutId = 1 // En cours
                },

                // Ticket 2 - Planificateur d'Entraînement 1.1 Windows Mobile
                new TicketModel
                {
                    TicketId = 2,
                    DateCreation = new DateTime(2024, 3, 15),
                    DateResolution = new DateTime(2024, 3, 28),
                    Description = "Les rappels d'entraînement programmés ne déclenchent pas de vibration sur les appareils Windows Mobile, uniquement une notification visuelle facilement manquée.",
                    Resolution = "Correction de l'implémentation des notifications pour utiliser correctement l'API de vibration de Windows Mobile. Ajout d'un paramètre permettant à l'utilisateur de personnaliser l'intensité et la durée des vibrations. Implémentation d'un mode \"ne pas déranger\" configurable par plages horaires.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 2, // 1.1
                    OsId = 6,      // Windows Mobile
                    StatutId = 2 // Résolu
                },

                // Ticket 3 - Planificateur d'Entraînement 2.0 MacOS
                new TicketModel
                {
                    TicketId = 3,
                    DateCreation = new DateTime(2024, 4, 5),
                    DateResolution = null,
                    Description = "Fuite de mémoire critique identifiée lors de l'utilisation prolongée. L'application peut consommer jusqu'à 8 Go de RAM après quelques heures d'utilisation, ralentissant considérablement le système.",
                    Resolution = "Analyse en cours avec des outils de profilage mémoire. Plusieurs sources potentielles identifiées dans le gestionnaire de modèles 3D pour la visualisation des exercices. Un correctif temporaire est en développement pour libérer périodiquement la mémoire, tandis qu'une solution permanente nécessite une refonte plus importante de l'architecture.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 5, // 2.0
                    OsId = 3,      // MacOS
                    StatutId = 1 // En cours
                },

                // Ticket 4 - Planificateur d'Entraînement 2.0 Windows
                new TicketModel
                {
                    TicketId = 4,
                    DateCreation = new DateTime(2024, 4, 12),
                    DateResolution = new DateTime(2024, 4, 25),
                    Description = "Incompatibilité avec les pilotes graphiques NVIDIA récents (série 550 et supérieure). Artefacts visuels et flickering lors de l'affichage des modèles d'exercices en 3D.",
                    Resolution = "Mise à jour du moteur de rendu 3D pour contourner un bug dans les pilotes NVIDIA. Implémentation d'une solution de repli utilisant DirectX 11 au lieu de DirectX 12 lorsque des problèmes sont détectés. Collaboration avec l'équipe NVIDIA pour résoudre le problème de manière permanente dans les futures mises à jour des pilotes.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 5, // 2.0
                    OsId = 2,      // Windows
                    StatutId = 2 // Résolu
                },

                // Ticket 5 - Planificateur d'Entraînement 2.0 Android
                new TicketModel
                {
                    TicketId = 5,
                    DateCreation = new DateTime(2024, 4, 20),
                    DateResolution = null,
                    Description = "Disparition aléatoire des données historiques d'entraînement sur certains appareils Android 13. Les utilisateurs perdent leur historique sans action spécifique de leur part.",
                    Resolution = "Problème complexe en cours d'investigation. Les tests initiaux suggèrent une interaction problématique entre le système de stockage de l'application et le gestionnaire de stockage scoped d'Android 13. Une solution de contournement temporaire a été mise en place via une sauvegarde cloud automatique, mais la résolution définitive nécessite des modifications architecturales importantes.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 5, // 2.0
                    OsId = 4,      // Android
                    StatutId = 1 // En cours
                },

                // Ticket 6 - Planificateur d'Entraînement 2.0 iOS
                new TicketModel
                {
                    TicketId = 6,
                    DateCreation = new DateTime(2024, 4, 25),
                    DateResolution = new DateTime(2024, 5, 10),
                    Description = "Le suivi GPS des activités en extérieur est inexact sur iOS, avec des écarts de distance pouvant atteindre 30% par rapport aux mesures réelles ou à d'autres applications.",
                    Resolution = "Refonte complète du module de suivi GPS avec implémentation d'algorithmes de filtrage plus sophistiqués. Optimisation de la fréquence d'échantillonnage pour équilibrer précision et consommation de batterie. Ajout d'une calibration automatique basée sur les habitudes de course de l'utilisateur. Les tests montrent une amélioration de la précision à moins de 3% d'écart.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 5, // 2.0
                    OsId = 5,      // iOS
                    StatutId = 2 // Résolu
                },

                // Ticket 7 - Planificateur d'Anxiété Sociale 1.0 Windows
                new TicketModel
                {
                    TicketId = 7,
                    DateCreation = new DateTime(2024, 2, 8),
                    DateResolution = null,
                    Description = "Les enregistrements audio des exercices de relaxation sont systématiquement corrompus après installation sur Windows 11. L'audio est saccadé et inintelligible.",
                    Resolution = "Investigation en cours sur un conflit potentiel avec le nouveau codec audio de Windows 11. Tests en cours avec des formats audio alternatifs et différentes méthodes de lecture. Une version bêta avec solution temporaire est disponible pour les utilisateurs affectés, utilisant un moteur audio tiers au lieu des API système.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 1, // 1.0
                    OsId = 2,      // Windows
                    StatutId = 1 // En cours
                },

                // Ticket 8 - Planificateur d'Anxiété Sociale 1.0 Android
                new TicketModel
                {
                    TicketId = 8,
                    DateCreation = new DateTime(2024, 2, 15),
                    DateResolution = new DateTime(2024, 3, 5),
                    Description = "Les exercices de méditation guidée sont interrompus par les notifications système malgré l'activation du mode \"Ne pas déranger\" dans l'application.",
                    Resolution = "Implémentation d'une intégration directe avec l'API \"Ne pas déranger\" d'Android pour activer automatiquement le mode système lors des sessions. Ajout d'options de personnalisation permettant de filtrer certaines notifications prioritaires. Optimisation de la reprise des exercices en cas d'interruption inévitable.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 1, // 1.0
                    OsId = 4,      // Android
                    StatutId = 2 // Résolu
                },

                // Ticket 9 - Planificateur d'Anxiété Sociale 1.1 MacOS
                new TicketModel
                {
                    TicketId = 9,
                    DateCreation = new DateTime(2024, 3, 10),
                    DateResolution = null,
                    Description = "Vulnérabilité de sécurité critique : les journaux personnels des utilisateurs sont stockés en texte clair et accessibles sans authentification si l'on accède physiquement à l'appareil.",
                    Resolution = "En cours de correction prioritaire. Développement d'un système de chiffrement transparent des données sensibles avec authentification biométrique ou par mot de passe. Migration des données existantes vers le nouveau format sécurisé. Un audit de sécurité externe a été commandé pour valider la solution avant déploiement.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 2, // 1.1
                    OsId = 3,      // MacOS
                    StatutId = 1 // En cours
                },

                // Ticket 10 - Planificateur d'Anxiété Sociale 1.1 Windows
                new TicketModel
                {
                    TicketId = 10,
                    DateCreation = new DateTime(2024, 3, 15),
                    DateResolution = new DateTime(2024, 3, 30),
                    Description = "Les rappels pour les exercices programmés n'apparaissent pas dans le Centre de notifications Windows, rendant l'application moins efficace pour la formation aux habitudes quotidiennes.",
                    Resolution = "Refonte complète du système de notification pour utiliser l'API Windows Toast moderne au lieu de l'ancien système. Ajout d'options de personnalisation avancées pour l'apparence et le comportement des notifications. Implémentation d'un système de rappels progressifs dont l'insistance augmente si les exercices sont régulièrement ignorés.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 2, // 1.1
                    OsId = 2,      // Windows
                    StatutId = 2 // Résolu
                },

                // Ticket 11 - Trader en Herbe 1.0 Linux
                new TicketModel
                {
                    TicketId = 11,
                    DateCreation = new DateTime(2024, 1, 5),
                    DateResolution = null,
                    Description = "Problème de sécurité : les mots de passe sont stockés en clair dans un fichier de configuration accessible. Risque de compromission des comptes utilisateurs.",
                    Resolution = "Analyse en cours. Solution planifiée pour implémenter un stockage sécurisé avec chiffrement AES-256. Mise en place d'un mécanisme de migration automatique des identifiants existants vers le nouveau système sécurisé. La correction est en phase finale de tests et sera déployée après l'audit de sécurité externe.",
                    ProductId = 1, // Trader en Herbe
                    VersionId = 1, // 1.0
                    OsId = 1,      // Linux
                    StatutId = 1 // En cours
                },

                // Ticket 12 - Maître des Investissements 1.0 iOS
                new TicketModel
                {
                    TicketId = 12,
                    DateCreation = new DateTime(2024, 1, 15),
                    DateResolution = new DateTime(2024, 2, 2),
                    Description = "Dégradation progressive des performances sur iPad : l'application devient de plus en plus lente à chaque session jusqu'à devenir inutilisable, nécessitant une réinstallation.",
                    Resolution = "Correction d'un problème dans le système de cache qui accumulait des données sans jamais les purger. Implémentation d'un mécanisme intelligent de gestion de cache avec limite de taille configurable et nettoyage automatique lors de la fermeture de l'application. Ajout d'une option dans les paramètres permettant à l'utilisateur de vider manuellement le cache.",
                    ProductId = 2, // Maître des Investissements
                    VersionId = 1, // 1.0
                    OsId = 5,      // iOS
                    StatutId = 2 // Résolu
                },

                // Ticket 13 - Planificateur d'Anxiété Sociale 1.1 iOS
                new TicketModel
                {
                    TicketId = 13,
                    DateCreation = new DateTime(2024, 3, 15),
                    DateResolution = null,
                    Description = "Les utilisateurs signalent l'apparition de publicités intrusives malgré l'achat de la version premium sans publicité. Les annonces apparaissent aléatoirement pendant les exercices de méditation.",
                    Resolution = "Problème prioritaire en cours d'investigation. L'analyse préliminaire suggère un conflit avec la dernière mise à jour du framework publicitaire tiers. Une solution temporaire consiste à désactiver complètement le module publicitaire en attendant une correction permanente. L'équipe développe actuellement un correctif d'urgence qui sera déployé d'ici 7 jours.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 2, // 1.1
                    OsId = 5,      // iOS
                    StatutId = 1 // En cours
                },

                // Ticket 14 - Trader en Herbe 1.2 Windows
                new TicketModel
                {
                    TicketId = 14,
                    DateCreation = new DateTime(2024, 3, 3),
                    DateResolution = new DateTime(2024, 3, 22),
                    Description = "Arrêts inattendus de l'application lors de l'ouverture simultanée de plus de trois graphiques de tendance. Message d'erreur indiquant \"Ressources insuffisantes\".",
                    Resolution = "Optimisation majeure de la gestion des ressources graphiques avec mise en place d'un système de mise en cache intelligente. Implémentation d'un mécanisme de rendu adaptatif qui ajuste automatiquement la qualité et la fréquence de rafraîchissement des graphiques en fonction des capacités matérielles détectées. Amélioration de 70% de l'utilisation mémoire et réduction de 60% de l'utilisation CPU.",
                    ProductId = 1, // Trader en Herbe
                    VersionId = 3, // 1.2
                    OsId = 2,      // Windows
                    StatutId = 2 // Résolu
                },

                // Ticket 15 - Maître des Investissements 2.1 Android
                new TicketModel
                {
                    TicketId = 15,
                    DateCreation = new DateTime(2024, 4, 12),
                    DateResolution = null,
                    Description = "Synchronisation défectueuse entre appareils : les modifications du portefeuille effectuées sur Android ne sont pas reflétées sur les autres plateformes (iOS, Web) malgré une connexion internet stable.",
                    Resolution = "Investigation en cours. Les journaux serveur montrent des incohérences dans les jetons d'authentification entre plateformes, entraînant des rejets de synchronisation. L'équipe backend travaille sur une refonte du système de synchronisation multi-appareils avec un nouveau protocole de validation et résolution de conflits. Une version test est en cours de déploiement pour validation interne.",
                    ProductId = 2, // Maître des Investissements
                    VersionId = 6, // 2.1
                    OsId = 4,      // Android
                    StatutId = 1 // En cours
                },

                // Ticket 16 - Trader en Herbe 1.1 Linux
                new TicketModel
                {
                    TicketId = 16,
                    DateCreation = new DateTime(2024, 2, 7),
                    DateResolution = null,
                    Description = "Échec du démarrage de l'application sur les distributions Linux basées sur Fedora 39. L'application affiche un message d'erreur concernant des bibliothèques Qt incompatibles avant de se fermer.",
                    Resolution = "Investigation en cours. Tests préliminaires indiquent une incompatibilité avec la nouvelle version de la bibliothèque Qt 6.6 incluse dans Fedora 39. L'équipe travaille sur deux approches parallèles : une solution de compatibilité pour Qt 6.6 et un package contenant toutes les dépendances nécessaires en version compatible, à distribuer avec l'application.",
                    ProductId = 1, // Trader en Herbe
                    VersionId = 2, // 1.1
                    OsId = 1,      // Linux
                    StatutId = 1 // En cours
                },

                // Ticket 17 - Trader en Herbe 1.2 MacOS
                new TicketModel
                {
                    TicketId = 17,
                    DateCreation = new DateTime(2024, 2, 15),
                    DateResolution = new DateTime(2024, 3, 3),
                    Description = "Les utilisateurs de MacBook Pro M2 signalent une surchauffe excessive lors de l'utilisation intensive de l'application. La température du CPU peut atteindre 95°C, déclenchant les ventilateurs à pleine vitesse et réduisant l'autonomie de la batterie.",
                    Resolution = "Optimisation majeure du code de rendu graphique pour les architectures ARM. Implémentation d'un mécanisme de limitation de fréquence d'images adaptatif qui réduit la charge CPU lorsque l'application n'est pas en premier plan ou lors d'une inactivité utilisateur. Ajout d'un mode économie d'énergie optionnel qui privilégie l'autonomie à la fluidité des animations. Tests montrent une réduction de 40% de la consommation CPU et une diminution de température moyenne de 15°C.",
                    ProductId = 1, // Trader en Herbe
                    VersionId = 3, // 1.2
                    OsId = 3,      // MacOS
                    StatutId = 2 // Résolu
                },

                // Ticket 18 - Trader en Herbe 1.3 Windows
                new TicketModel
                {
                    TicketId = 18,
                    DateCreation = new DateTime(2024, 3, 10),
                    DateResolution = null,
                    Description = "Faille de sécurité critique identifiée : l'intégration avec le navigateur web stocke temporairement les données des transactions dans un fichier non chiffré accessible par d'autres applications. Risque d'extraction de données sensibles par des logiciels malveillants.",
                    Resolution = "Équipe de sécurité mobilisée en priorité. Développement d'un correctif d'urgence qui implémente un stockage temporaire en mémoire encryptée au lieu d'utiliser le système de fichiers. Audit de sécurité complet en cours sur toutes les fonctionnalités impliquant des données sensibles. Publication d'un avertissement de sécurité et recommandations temporaires aux utilisateurs en attendant le déploiement de la mise à jour.",
                    ProductId = 1, // Trader en Herbe
                    VersionId = 4, // 1.3
                    OsId = 2,      // Windows
                    StatutId = 1 // En cours
                },

                // Ticket 19 - Maître des Investissements 1.0 MacOS
                new TicketModel
                {
                    TicketId = 19,
                    DateCreation = new DateTime(2024, 1, 20),
                    DateResolution = new DateTime(2024, 2, 5),
                    Description = "Support incomplet des fonctionnalités d'accessibilité MacOS. Les utilisateurs de VoiceOver ne peuvent pas naviguer efficacement dans l'interface ou accéder à certaines fonctionnalités essentielles comme la configuration des alertes de prix.",
                    Resolution = "Refonte complète de l'interface utilisateur avec implémentation des contrôles d'accessibilité d'Apple. Ajout de descriptions détaillées pour tous les éléments d'interface et de raccourcis clavier alternatifs pour les actions principales. Optimisation des flux de navigation pour VoiceOver. Tests d'accessibilité réalisés avec des utilisateurs malvoyants pour valider les améliorations. Mise en place d'un processus de validation d'accessibilité pour toutes les futures fonctionnalités.",
                    ProductId = 2, // Maître des Investissements
                    VersionId = 1, // 1.0
                    OsId = 3,      // MacOS
                    StatutId = 2 // Résolu
                },

                // Ticket 20 - Maître des Investissements 2.0 Android
                new TicketModel
                {
                    TicketId = 20,
                    DateCreation = new DateTime(2024, 3, 1),
                    DateResolution = new DateTime(2024, 3, 15),
                    Description = "La fonctionnalité de capture d'écran et partage sur réseaux sociaux échoue sur Android 14. L'application affiche une erreur \"Accès refusé\" malgré les autorisations accordées.",
                    Resolution = "Adaptation de la fonctionnalité de capture et partage aux nouvelles restrictions de sécurité d'Android 14 concernant l'accès au contenu de l'écran. Mise à jour de la méthode de demande d'autorisation avec utilisation du nouveau framework de permissions granulaires. Ajout d'un mode de partage alternatif qui génère une image à partir des données internes plutôt que de capturer l'écran. Amélioration des messages d'erreur avec instructions spécifiques pour chaque version d'Android.",
                    ProductId = 2, // Maître des Investissements
                    VersionId = 5, // 2.0
                    OsId = 4,      // Android
                    StatutId = 2 // Résolu
                },

                // Ticket 21 - Maître des Investissements 2.1 Windows
                new TicketModel
                {
                    TicketId = 21,
                    DateCreation = new DateTime(2024, 3, 17),
                    DateResolution = null,
                    Description = "Multiples erreurs d'affichage sur les configurations multi-écrans. Les fenêtres flottantes d'analyse apparaissent au mauvais endroit ou sont partiellement visibles lorsqu'elles sont déplacées entre écrans avec des résolutions différentes.",
                    Resolution = "Investigation en cours sur les problèmes de gestion de fenêtres dans des configurations d'affichage complexes. Tests réalisés avec diverses combinaisons de résolutions et échelles DPI. Solution envisagée implique une refonte du système de positionnement des fenêtres avec détection et ajustement automatique aux caractéristiques de chaque écran. Développement d'un mode de test permettant de simuler diverses configurations d'affichage.",
                    ProductId = 2, // Maître des Investissements
                    VersionId = 6, // 2.1
                    OsId = 2,      // Windows
                    StatutId = 1 // En cours
                },

                // Ticket 22 - Planificateur d'Entraînement 1.0 Linux
                new TicketModel
                {
                    TicketId = 22,
                    DateCreation = new DateTime(2024, 1, 25),
                    DateResolution = new DateTime(2024, 2, 8),
                    Description = "L'application n'utilise pas les thèmes système sous GNOME et KDE, générant un contraste insuffisant en mode sombre et des problèmes de lisibilité des graphiques d'évolution des performances.",
                    Resolution = "Implémentation de la détection automatique du thème système sur les environnements de bureau Linux. Adaptation dynamique des palettes de couleurs pour maintenir un contraste optimal quel que soit le thème. Refonte des graphiques avec des couleurs adaptatives qui s'ajustent automatiquement aux préférences d'affichage de l'utilisateur. Ajout de préréglages de couleurs alternatifs pour les utilisateurs daltoniennes ou ayant des besoins visuels spécifiques.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 1, // 1.0
                    OsId = 1,      // Linux
                    StatutId = 2 // Résolu
                },

                // Ticket 23 - Planificateur d'Entraînement 1.1 Android
                new TicketModel
                {
                    TicketId = 23,
                    DateCreation = new DateTime(2024, 2, 12),
                    DateResolution = null,
                    Description = "Consommation excessive de batterie en raison de l'utilisation continue du GPS même lorsque l'utilisateur n'est pas en activité. Certains utilisateurs rapportent jusqu'à 40% de batterie consommée en une journée par l'application en arrière-plan.",
                    Resolution = "Analyse approfondie en cours du cycle de vie de l'application et de la gestion des capteurs. Développement d'un système intelligent de détection d'activité qui n'active le GPS que lorsque nécessaire. Implémentation d'un algorithme de prédiction qui anticipe les périodes d'entraînement basées sur les habitudes de l'utilisateur. Tests en cours avec diverses intensités d'utilisation pour mesurer l'impact des optimisations. Première version bêta du correctif disponible pour les testeurs volontaires.",
                    ProductId = 3, // Planificateur d'Entraînement
                    VersionId = 2, // 1.1
                    OsId = 4,      // Android
                    StatutId = 1 // En cours
                },

                // Ticket 24 - Planificateur d'Anxiété Sociale 1.0 Android
                new TicketModel
                {
                    TicketId = 24,
                    DateCreation = new DateTime(2024, 2, 20),
                    DateResolution = new DateTime(2024, 3, 5),
                    Description = "Échec des enregistrements audio dans le journal des émotions sur les appareils Samsung utilisant One UI 6. L'application se fige pendant plusieurs secondes avant d'afficher une erreur \"Périphérique audio non disponible\".",
                    Resolution = "Correction d'un problème d'incompatibilité avec l'API d'enregistrement audio modifiée dans One UI 6. Implémentation d'une détection automatique de la version de l'interface Samsung et utilisation de l'API appropriée selon le système. Ajout d'un mécanisme de secours qui bascule sur une méthode d'enregistrement alternative en cas d'échec de la méthode principale. Amélioration des messages d'erreur avec suggestions de résolution spécifiques pour chaque modèle d'appareil.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 1, // 1.0
                    OsId = 4,      // Android
                    StatutId = 2 // Résolu
                },

                // Ticket 25 - Planificateur d'Anxiété Sociale 1.1 iOS
                new TicketModel
                {
                    TicketId = 25,
                    DateCreation = new DateTime(2024, 4, 5),
                    DateResolution = null,
                    Description = "Disparition des données après restauration de l'appareil ou transfert vers un nouvel iPhone. La sauvegarde iCloud ne semble pas préserver correctement les journaux personnels et les statistiques d'évolution.",
                    Resolution = "Investigation en cours sur l'implémentation de CloudKit. Identification préliminaire d'erreurs dans la structure des données stockées qui empêchent la restauration correcte. Développement d'un utilitaire de récupération qui peut extraire les données des sauvegardes iCloud même en cas de structure incompatible. Refonte du système de stockage cloud avec validation plus stricte des données avant synchronisation et mécanismes de récupération robustes. Beta planifiée pour la semaine prochaine avec les utilisateurs affectés.",
                    ProductId = 4, // Planificateur d'Anxiété Sociale
                    VersionId = 2, // 1.1
                    OsId = 5,      // iOS
                    StatutId = 1 // En cours
                }
            );
        }

        // NOTES IMPORTANTES :
        // - StatutId utilise des chaînes : "1" pour "En cours", "2" pour "Résolu"
        // - Les ProductId correspondent aux produits : 1=Trader en Herbe, 2=Maître des Investissements, 3=Planificateur d'Entraînement, 4=Planificateur d'Anxiété Sociale
        // - Les VersionId correspondent aux versions : 1=1.0, 2=1.1, 3=1.2, 4=1.3, 5=2.0, 6=2.1
        // - Les OsId correspondent aux OS : 1=Linux, 2=Windows, 3=MacOS, 4=Android, 5=iOS, 6=Windows Mobile
        // - Toutes les combinaisons Produit/Version/OS utilisées dans ces tickets doivent exister dans la table ProductVersionOsSupport



    }
}
