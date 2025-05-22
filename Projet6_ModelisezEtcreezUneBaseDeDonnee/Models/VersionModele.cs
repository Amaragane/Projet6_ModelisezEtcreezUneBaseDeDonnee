using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Models
{
    public class VersionModele
    {
        // Clé primaire
        [Key]
        public int VersionId { get; set; }

        // Propriété scalaire
        [Required(ErrorMessage ="Un numéro de version est nécéssaire")]
        public double VersionName { get; set; }

        public string Description { get; set; } = null!;

        // Clé étrangère (scalaire)
        [Required(ErrorMessage = "un produit est requis.")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        // Navigation vers l'objet parent - AVEC virtual
        public virtual ProductModele Product { get; set; } = null!;



        // Navigation vers collection - AVEC virtual
        public virtual ICollection<OsModele> SupportedOs { get; set; } = new List<OsModele>();
        public virtual ICollection<TicketModele> Tickets { get; set; } = new List<TicketModele>();

    }
}
