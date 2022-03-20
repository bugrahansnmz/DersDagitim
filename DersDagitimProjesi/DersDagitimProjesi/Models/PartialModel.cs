namespace DersDagitimProjesi.Models
{
    public class PartialModel
    {
        public IEnumerable<Ogrenci> Ogr { get; set; }
        public IEnumerable<Ogretmen> Ogrtmn { get; set; } 
        public IEnumerable<Sinif> Snf { get; set; }
        public IEnumerable<Yonetici> Ynt { get; set; }
        public IEnumerable<Okul> Ok { get; set; }
        public string Okl { get; set; }
        public string Yntc { get; set; }
    }
}
