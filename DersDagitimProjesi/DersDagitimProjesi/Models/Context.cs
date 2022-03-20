using DersDagitimProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Models
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Server=localhost;Port=5432;Database=DersDagitim;Integrated Security=true;Pooling=true;");
        }
        public DbSet<Ders>? Derss { get; set; }
        public DbSet<Ogrenci>? Ogrencis { get; set; }
        public DbSet<Ogretmen>? Ogretmens { get; set; }
        public DbSet<Sinif>? Sinifs { get; set; }
        public DbSet<SabitBilgi>? SabitBilgis { get; set; }
        public DbSet<Gun>? Guns { get; set; }
        public DbSet<Saat>? Saats { get; set; }
        public DbSet<DersProgram>? DersPrograms { get; set; }
        public DbSet<Okul>? Okuls { get; set; }
        public DbSet<Yonetici>? Yoneticis { get; set; }
        public DbSet<Admin>? Admins { get; set; }
    }
}
