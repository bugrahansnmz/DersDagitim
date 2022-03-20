using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DersDagitimProjesi.Models
{
    public class Ders
    {
        [Key]
        public int DersID { get; set; }
        public string? DersAd { get; set; } 
        public List<Ogretmen>? Ogretmens { get; set; } 
        public List<Sinif>? Sinifs { get; set; }
        public List<DersProgram>? DersPrograms { get; set; } 
    }
}
