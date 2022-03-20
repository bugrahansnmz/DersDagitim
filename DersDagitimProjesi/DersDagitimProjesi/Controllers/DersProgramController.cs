using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Controllers
{
    public class DersProgramController : Controller
    {
        Context c = new Context();
        public IActionResult Index(string p)
        {
            var sorgu = from x in c.DersPrograms.Include("Sinif").Include("Ders").Include("Saat").Include("Gun") select x;
            if (!string.IsNullOrEmpty(p))
            {
                sorgu = sorgu.Where(y => y.Gun.GunAdi.Contains(p));
            }
            return View(sorgu);
        }
       
        public IActionResult ProgramSil(int id)
        {
            var cr = c.DersPrograms.Find(id);
            var sin = c.DersPrograms.Where(y => y.Sinifid == cr.Sinifid).Select(x=>x.ProgramID).ToList();
            for (int i = 0; i < sin.Count; i++)
            {
                var sil = c.DersPrograms.Find(sin[i]);
                c.DersPrograms.Remove(sil);
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
