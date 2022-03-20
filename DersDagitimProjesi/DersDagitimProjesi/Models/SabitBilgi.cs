using System.ComponentModel.DataAnnotations;

namespace DersDagitimProjesi.Models
{
    public class SabitBilgi
    {
        [Key]
        public int SabitID { get; set; }
        public bool OgleArasi { get; set; }
        public int GunlukMaksDers { get; set; }
        public string BaslangicSaati { get; set; }
    }
}
