using System.ComponentModel.DataAnnotations;

namespace DersDagitimProjesi.Models
{
    public class Okul
    {
        [Key]
        public int OkulID { get; set; }
        public string OkulAd { get; set; }
    }
}
