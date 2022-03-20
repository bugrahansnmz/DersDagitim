using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DersDagitimProjesi.Models
{
    public class Sinif
    {
        [Key]
        public int SinifID { get; set; }
        public int SinifNo { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SinifSube { get; set; }
        public int OgrenciSayisi { get; set; }
        public List<Ders> Derss { get; set; }
        public List<Ogrenci>? Ogrencis { get; set; }
        public List<DersProgram>? DersPrograms { get; set; }
    }
}
