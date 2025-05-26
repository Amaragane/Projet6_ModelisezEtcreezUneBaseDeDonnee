namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Models
{
    /// <summary>
    /// Modèle de vue pour la gestion des erreurs
    /// Utilisé pour afficher les informations d'erreur dans l'interface utilisateur
    /// </summary>
    public class ErrorViewModel
    {
        // Propriété scalaire - Identifiant de la requête ayant généré l'erreur (nullable)
        public string? RequestId { get; set; }

        // Propriété calculée - Indique si l'ID de requête doit être affiché
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
