using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DateCreation", "DateResolution", "Description", "OsId", "Resolution", "Statut", "VersionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "L'application se ferme brutalement lors de la tentative d'importation des activités depuis des montres connectées Garmin sur les appareils iOS 17.4 et supérieurs. Les utilisateurs ne peuvent pas intégrer leurs données d'entraînement existantes.", 5, "Actuellement en investigation. L'analyse préliminaire suggère un conflit avec la nouvelle politique de sécurité iOS concernant les connexions Bluetooth. L'équipe travaille sur une solution qui maintient la compatibilité tout en respectant les nouvelles restrictions d'Apple.", "En cours", 9 },
                    { 2, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les rappels d'entraînement programmés ne déclenchent pas de vibration sur les appareils Windows Mobile, uniquement une notification visuelle facilement manquée.", 6, "Correction de l'implémentation des notifications pour utiliser correctement l'API de vibration de Windows Mobile. Ajout d'un paramètre permettant à l'utilisateur de personnaliser l'intensité et la durée des vibrations. Implémentation d'un mode \"ne pas déranger\" configurable par plages horaires.", "Résolu", 9 },
                    { 3, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuite de mémoire critique identifiée lors de l'utilisation prolongée. L'application peut consommer jusqu'à 8 Go de RAM après quelques heures d'utilisation, ralentissant considérablement le système.", 3, "Analyse en cours avec des outils de profilage mémoire. Plusieurs sources potentielles identifiées dans le gestionnaire de modèles 3D pour la visualisation des exercices. Un correctif temporaire est en développement pour libérer périodiquement la mémoire, tandis qu'une solution permanente nécessite une refonte plus importante de l'architecture.", "En cours", 10 },
                    { 4, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incompatibilité avec les pilotes graphiques NVIDIA récents (série 550 et supérieure). Artefacts visuels et flickering lors de l'affichage des modèles d'exercices en 3D.", 2, "Mise à jour du moteur de rendu 3D pour contourner un bug dans les pilotes NVIDIA. Implémentation d'une solution de repli utilisant DirectX 11 au lieu de DirectX 12 lorsque des problèmes sont détectés. Collaboration avec l'équipe NVIDIA pour résoudre le problème de manière permanente dans les futures mises à jour des pilotes.", "Résolu", 10 },
                    { 5, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disparition aléatoire des données historiques d'entraînement sur certains appareils Android 13. Les utilisateurs perdent leur historique sans action spécifique de leur part.", 4, "Problème complexe en cours d'investigation. Les tests initiaux suggèrent une interaction problématique entre le système de stockage de l'application et le gestionnaire de stockage scoped d'Android 13. Une solution de contournement temporaire a été mise en place via une sauvegarde cloud automatique, mais la résolution définitive nécessite des modifications architecturales importantes.", "En cours", 10 },
                    { 6, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le suivi GPS des activités en extérieur est inexact sur iOS, avec des écarts de distance pouvant atteindre 30% par rapport aux mesures réelles ou à d'autres applications.", 5, "Refonte complète du module de suivi GPS avec implémentation d'algorithmes de filtrage plus sophistiqués. Optimisation de la fréquence d'échantillonnage pour équilibrer précision et consommation de batterie. Ajout d'une calibration automatique basée sur les habitudes de course de l'utilisateur. Les tests montrent une amélioration de la précision à moins de 3% d'écart.", "Résolu", 10 },
                    { 7, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Les enregistrements audio des exercices de relaxation sont systématiquement corrompus après installation sur Windows 11. L'audio est saccadé et inintelligible.", 2, "Investigation en cours sur un conflit potentiel avec le nouveau codec audio de Windows 11. Tests en cours avec des formats audio alternatifs et différentes méthodes de lecture. Une version bêta avec solution temporaire est disponible pour les utilisateurs affectés, utilisant un moteur audio tiers au lieu des API système.", "En cours", 11 },
                    { 8, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les exercices de méditation guidée sont interrompus par les notifications système malgré l'activation du mode \"Ne pas déranger\" dans l'application.", 4, "Implémentation d'une intégration directe avec l'API \"Ne pas déranger\" d'Android pour activer automatiquement le mode système lors des sessions. Ajout d'options de personnalisation permettant de filtrer certaines notifications prioritaires. Optimisation de la reprise des exercices en cas d'interruption inévitable.", "Résolu", 11 },
                    { 9, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vulnérabilité de sécurité critique : les journaux personnels des utilisateurs sont stockés en texte clair et accessibles sans authentification si l'on accède physiquement à l'appareil.", 3, "En cours de correction prioritaire. Développement d'un système de chiffrement transparent des données sensibles avec authentification biométrique ou par mot de passe. Migration des données existantes vers le nouveau format sécurisé. Un audit de sécurité externe a été commandé pour valider la solution avant déploiement.", "En cours", 12 },
                    { 10, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les rappels pour les exercices programmés n'apparaissent pas dans le Centre de notifications Windows, rendant l'application moins efficace pour la formation aux habitudes quotidiennes.", 2, "Refonte complète du système de notification pour utiliser l'API Windows Toast moderne au lieu de l'ancien système. Ajout d'options de personnalisation avancées pour l'apparence et le comportement des notifications. Implémentation d'un système de rappels progressifs dont l'insistance augmente si les exercices sont régulièrement ignorés.", "Résolu", 12 },
                    { 11, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Problème de sécurité : les mots de passe sont stockés en clair dans un fichier de configuration accessible. Risque de compromission des comptes utilisateurs.", 1, "Analyse en cours. Solution planifiée pour implémenter un stockage sécurisé avec chiffrement AES-256. Mise en place d'un mécanisme de migration automatique des identifiants existants vers le nouveau système sécurisé. La correction est en phase finale de tests et sera déployée après l'audit de sécurité externe.", "En cours", 1 },
                    { 12, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dégradation progressive des performances sur iPad : l'application devient de plus en plus lente à chaque session jusqu'à devenir inutilisable, nécessitant une réinstallation.", 5, "Correction d'un problème dans le système de cache qui accumulait des données sans jamais les purger. Implémentation d'un mécanisme intelligent de gestion de cache avec limite de taille configurable et nettoyage automatique lors de la fermeture de l'application. Ajout d'une option dans les paramètres permettant à l'utilisateur de vider manuellement le cache.", "Résolu", 5 },
                    { 13, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Les utilisateurs signalent l'apparition de publicités intrusives malgré l'achat de la version premium sans publicité. Les annonces apparaissent aléatoirement pendant les exercices de méditation.", 5, "Problème prioritaire en cours d'investigation. L'analyse préliminaire suggère un conflit avec la dernière mise à jour du framework publicitaire tiers. Une solution temporaire consiste à désactiver complètement le module publicitaire en attendant une correction permanente. L'équipe développe actuellement un correctif d'urgence qui sera déployé d'ici 7 jours.", "En cours", 12 },
                    { 14, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arrêts inattendus de l'application lors de l'ouverture simultanée de plus de trois graphiques de tendance. Message d'erreur indiquant \"Ressources insuffisantes\".", 2, "Optimisation majeure de la gestion des ressources graphiques avec mise en place d'un système de mise en cache intelligente. Implémentation d'un mécanisme de rendu adaptatif qui ajuste automatiquement la qualité et la fréquence de rafraîchissement des graphiques en fonction des capacités matérielles détectées. Amélioration de 70% de l'utilisation mémoire et réduction de 60% de l'utilisation CPU.", "Résolu", 3 },
                    { 15, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Synchronisation défectueuse entre appareils : les modifications du portefeuille effectuées sur Android ne sont pas reflétées sur les autres plateformes (iOS, Web) malgré une connexion internet stable.", 4, "Investigation en cours. Les journaux serveur montrent des incohérences dans les jetons d'authentification entre plateformes, entraînant des rejets de synchronisation. L'équipe backend travaille sur une refonte du système de synchronisation multi-appareils avec un nouveau protocole de validation et résolution de conflits. Une version test est en cours de déploiement pour validation interne.", "En cours", 7 },
                    { 16, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Échec du démarrage de l'application sur les distributions Linux basées sur Fedora 39. L'application affiche un message d'erreur concernant des bibliothèques Qt incompatibles avant de se fermer.", 1, "Investigation en cours. Tests préliminaires indiquent une incompatibilité avec la nouvelle version de la bibliothèque Qt 6.6 incluse dans Fedora 39. L'équipe travaille sur deux approches parallèles : une solution de compatibilité pour Qt 6.6 et un package contenant toutes les dépendances nécessaires en version compatible, à distribuer avec l'application.", "En cours", 2 },
                    { 17, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les utilisateurs de MacBook Pro M2 signalent une surchauffe excessive lors de l'utilisation intensive de l'application. La température du CPU peut atteindre 95°C, déclenchant les ventilateurs à pleine vitesse et réduisant l'autonomie de la batterie.", 3, "Optimisation majeure du code de rendu graphique pour les architectures ARM. Implémentation d'un mécanisme de limitation de fréquence d'images adaptatif qui réduit la charge CPU lorsque l'application n'est pas en premier plan ou lors d'une inactivité utilisateur. Ajout d'un mode économie d'énergie optionnel qui privilégie l'autonomie à la fluidité des animations. Tests montrent une réduction de 40% de la consommation CPU et une diminution de température moyenne de 15°C.", "Résolu", 3 },
                    { 18, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Faille de sécurité critique identifiée : l'intégration avec le navigateur web stocke temporairement les données des transactions dans un fichier non chiffré accessible par d'autres applications. Risque d'extraction de données sensibles par des logiciels malveillants.", 2, "Équipe de sécurité mobilisée en priorité. Développement d'un correctif d'urgence qui implémente un stockage temporaire en mémoire encryptée au lieu d'utiliser le système de fichiers. Audit de sécurité complet en cours sur toutes les fonctionnalités impliquant des données sensibles. Publication d'un avertissement de sécurité et recommandations temporaires aux utilisateurs en attendant le déploiement de la mise à jour.", "En cours", 4 },
                    { 19, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Support incomplet des fonctionnalités d'accessibilité MacOS. Les utilisateurs de VoiceOver ne peuvent pas naviguer efficacement dans l'interface ou accéder à certaines fonctionnalités essentielles comme la configuration des alertes de prix.", 3, "Refonte complète de l'interface utilisateur avec implémentation des contrôles d'accessibilité d'Apple. Ajout de descriptions détaillées pour tous les éléments d'interface et de raccourcis clavier alternatifs pour les actions principales. Optimisation des flux de navigation pour VoiceOver. Tests d'accessibilité réalisés avec des utilisateurs malvoyants pour valider les améliorations. Mise en place d'un processus de validation d'accessibilité pour toutes les futures fonctionnalités.", "Résolu", 5 },
                    { 20, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "La fonctionnalité de capture d'écran et partage sur réseaux sociaux échoue sur Android 14. L'application affiche une erreur \"Accès refusé\" malgré les autorisations accordées.", 4, "Adaptation de la fonctionnalité de capture et partage aux nouvelles restrictions de sécurité d'Android 14 concernant l'accès au contenu de l'écran. Mise à jour de la méthode de demande d'autorisation avec utilisation du nouveau framework de permissions granulaires. Ajout d'un mode de partage alternatif qui génère une image à partir des données internes plutôt que de capturer l'écran. Amélioration des messages d'erreur avec instructions spécifiques pour chaque version d'Android.", "Résolu", 6 },
                    { 21, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Multiples erreurs d'affichage sur les configurations multi-écrans. Les fenêtres flottantes d'analyse apparaissent au mauvais endroit ou sont partiellement visibles lorsqu'elles sont déplacées entre écrans avec des résolutions différentes.", 2, "Investigation en cours sur les problèmes de gestion de fenêtres dans des configurations d'affichage complexes. Tests réalisés avec diverses combinaisons de résolutions et échelles DPI. Solution envisagée implique une refonte du système de positionnement des fenêtres avec détection et ajustement automatique aux caractéristiques de chaque écran. Développement d'un mode de test permettant de simuler diverses configurations d'affichage.", "En cours", 7 },
                    { 22, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "L'application n'utilise pas les thèmes système sous GNOME et KDE, générant un contraste insuffisant en mode sombre et des problèmes de lisibilité des graphiques d'évolution des performances.", 1, "Implémentation de la détection automatique du thème système sur les environnements de bureau Linux. Adaptation dynamique des palettes de couleurs pour maintenir un contraste optimal quel que soit le thème. Refonte des graphiques avec des couleurs adaptatives qui s'ajustent automatiquement aux préférences d'affichage de l'utilisateur. Ajout de préréglages de couleurs alternatifs pour les utilisateurs daltoniennes ou ayant des besoins visuels spécifiques.", "Résolu", 8 },
                    { 23, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Consommation excessive de batterie en raison de l'utilisation continue du GPS même lorsque l'utilisateur n'est pas en activité. Certains utilisateurs rapportent jusqu'à 40% de batterie consommée en une journée par l'application en arrière-plan.", 4, "Analyse approfondie en cours du cycle de vie de l'application et de la gestion des capteurs. Développement d'un système intelligent de détection d'activité qui n'active le GPS que lorsque nécessaire. Implémentation d'un algorithme de prédiction qui anticipe les périodes d'entraînement basées sur les habitudes de l'utilisateur. Tests en cours avec diverses intensités d'utilisation pour mesurer l'impact des optimisations. Première version bêta du correctif disponible pour les testeurs volontaires.", "En cours", 9 },
                    { 24, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Échec des enregistrements audio dans le journal des émotions sur les appareils Samsung utilisant One UI 6. L'application se fige pendant plusieurs secondes avant d'afficher une erreur \"Périphérique audio non disponible\".", 4, "Correction d'un problème d'incompatibilité avec l'API d'enregistrement audio modifiée dans One UI 6. Implémentation d'une détection automatique de la version de l'interface Samsung et utilisation de l'API appropriée selon le système. Ajout d'un mécanisme de secours qui bascule sur une méthode d'enregistrement alternative en cas d'échec de la méthode principale. Amélioration des messages d'erreur avec suggestions de résolution spécifiques pour chaque modèle d'appareil.", "Résolu", 11 },
                    { 25, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disparition des données après restauration de l'appareil ou transfert vers un nouvel iPhone. La sauvegarde iCloud ne semble pas préserver correctement les journaux personnels et les statistiques d'évolution.", 5, "Investigation en cours sur l'implémentation de CloudKit. Identification préliminaire d'erreurs dans la structure des données stockées qui empêchent la restauration correcte. Développement d'un utilitaire de récupération qui peut extraire les données des sauvegardes iCloud même en cas de structure incompatible. Refonte du système de stockage cloud avec validation plus stricte des données avant synchronisation et mécanismes de récupération robustes. Beta planifiée pour la semaine prochaine avec les utilisateurs affectés.", "En cours", 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25);
        }
    }
}
