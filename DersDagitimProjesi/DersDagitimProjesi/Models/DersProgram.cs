using System.ComponentModel.DataAnnotations;

namespace DersDagitimProjesi.Models
{
    public class DersProgram
    {
        [Key]
        public int ProgramID { get; set; }
        
        public int Sinifid { get; set; }
        public virtual Sinif? Sinif { get; set; } 
        public int Gunid { get; set; }
        public virtual Gun? Gun { get; set; } 
        public int Dersid { get; set; }
        public virtual Ders? Ders { get; set; } 
        public int Saatid { get; set; }
        public virtual Saat? Saat { get; set; }
    }
}
