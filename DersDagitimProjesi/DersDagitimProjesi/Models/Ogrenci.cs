using System.ComponentModel.DataAnnotations;
namespace DersDagitimProjesi.Models
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciID { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public int Sinifid { get; set; }
        public virtual Sinif? Sinif { get; set; }
    }
}
