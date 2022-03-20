using System.ComponentModel.DataAnnotations;

namespace DersDagitimProjesi.Models
{
    public class Yonetici
    {
        [Key]
        public int YoneticiID { get; set; }
        public string YoneticiAdSoyad { get; set; }
    }
}
