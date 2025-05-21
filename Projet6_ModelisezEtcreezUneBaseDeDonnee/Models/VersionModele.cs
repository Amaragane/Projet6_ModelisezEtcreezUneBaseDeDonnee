using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Models
{
    public class VersionModele
    {
        [Key]
        public int VersionId { get; set; }
        [Required(ErrorMessage = "La version est requis.")]
        public double VersionName { get; set; }

        public string Description { get; set; } = null!;
        [Required]
        public int ProductId { get; set; }
        
        public int OsId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductModele Product { get; set; } = null!;

        public virtual ICollection<TicketModele> Tickets { get; set; } = new List<TicketModele>();

    }
}
