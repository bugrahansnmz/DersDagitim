using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DersDagitimProjesi.Models
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenID { get; set; }
        public string OgretmenAd { get; set; }
        public string OgretmenSoyad { get; set; }
        public int Dersid { get; set; }
        public virtual Ders? Ders { get; set; }
      

    }
}
