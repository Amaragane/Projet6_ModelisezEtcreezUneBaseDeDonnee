using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Models
{
    public class TicketModele
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage ="Date de création requise")]
        public DateTime DateCreation { get; set; }

        public DateTime? DateResolution { get; set; }

        [Required(ErrorMessage = "Statut requis")]
        public string Statut { get; set; } = null!;

        [Required(ErrorMessage = "Description requise")]
        public string Description { get; set; } = null!;

        public string? Resolution { get; set; }

        [Required]
        public int VersionId { get; set; }

        [Required]
        public int OsId { get; set; }

        // Navigations
        [ForeignKey("VersionId")]
        public virtual VersionModele Version { get; set; } = null!;

        [ForeignKey("OsId")]
        public virtual OsModele Os { get; set; } = null!;
    }
}
