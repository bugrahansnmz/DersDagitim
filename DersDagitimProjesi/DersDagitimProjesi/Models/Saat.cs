using System.ComponentModel.DataAnnotations;
namespace DersDagitimProjesi.Models
{
    public class Saat
    {
        [Key]
        public int SaatID { get; set; }
        public string? SaatKac { get; set; }
        public List<DersProgram>? DersPrograms { get; set; }
    }
}
