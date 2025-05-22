using System.ComponentModel.DataAnnotations;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Models
{
    public class ProductModele
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Le nom est requis.")]
        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }
        [Required(ErrorMessage = "Un produit doit avoir au moins une version.")]
        [MinLength(1, ErrorMessage = "Un produit doit avoir au moins une version.")]
        public virtual ICollection<VersionModele> Versions { get; set; } = new List<VersionModele>();
    }
}
