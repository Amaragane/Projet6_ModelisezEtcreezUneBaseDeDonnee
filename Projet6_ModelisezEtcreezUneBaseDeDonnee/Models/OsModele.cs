using System.ComponentModel.DataAnnotations;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Models
{
    public class OsModele
    {
        [Key]
        public int OsId { get; set; }
        [Required(ErrorMessage = "L'OS est requis.")]
        public string OsName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public virtual ICollection<TicketModele> Tickets { get; set; } = new List<TicketModele>();

    }
}
