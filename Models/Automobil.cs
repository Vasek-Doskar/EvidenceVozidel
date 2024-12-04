using System.ComponentModel.DataAnnotations;

namespace EvidenceVozidel.Models
{
    public class Automobil
    {
        [Key]
        public uint Id { get; set; }
        [Display(Name = "Značka"), MinLength(2, ErrorMessage = "Název je příliš krátký")]
        public string Znacka { get; set; }
        public string Model { get; set; }
    }
}
