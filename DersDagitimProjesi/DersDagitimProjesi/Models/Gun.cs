using System.ComponentModel.DataAnnotations;

namespace DersDagitimProjesi.Models
{
    public class Gun
    {
        [Key]
        public int GunID { get; set; }
        public string? GunAdi { get; set; }
        public List<DersProgram>? DersPrograms { get; set; }
    }
}
