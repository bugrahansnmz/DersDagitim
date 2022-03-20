using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Controllers
{
    public class SinifController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var sorgu = c.Sinifs.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult YeniSinif()
        {
            List<SelectListItem> deger1 = (from x in c.Ogretmens.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.OgretmenAd,
                                               Value = x.OgretmenID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
           
            return View();
        }
        [HttpPost]
        public IActionResult YeniSinif(Sinif sinif)
        {

            c.Sinifs.Add(sinif);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SinifSil(int id)
        {
            var cr = c.Sinifs.Find(id);
            c.Sinifs.Remove(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SinifDetay(int id)
        {

            //var deger = c.DersPrograms.Where(x => x.Sinifid == id).ToList();
            var deger = c.DersPrograms.Include("Sinif").Include("Ders").Include("Saat").Include("Gun").Where(x=>x.Sinifid ==id).ToList();
            
            var dp = c.Sinifs.Where(x => x.SinifID == id).Select(y => y.SinifNo).FirstOrDefault();
            ViewBag.d = dp;
            var dp1 = c.Sinifs.Where(x => x.SinifID == id).Select(y => y.SinifSube).FirstOrDefault();
            ViewBag.d1 = dp1;
            return View(deger);
        }
    }
}
