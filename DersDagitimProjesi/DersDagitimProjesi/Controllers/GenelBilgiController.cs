using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Controllers
{
    public class GenelBilgiController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            PartialModel model = new PartialModel();
            model.Ogrtmn = c.Ogretmens.Include("Ders").ToList();
            model.Snf = c.Sinifs.ToList();
            model.Ogr = c.Ogrencis.Include("Sinif").ToList();
            model.Ok = c.Okuls.ToList();
            model.Ynt = c.Yoneticis.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(PartialModel model)
        {
            Okul okul = new Okul();
            Yonetici yonetici = new Yonetici();
            yonetici.YoneticiAdSoyad = model.Yntc;
            okul.OkulAd = model.Okl;
            c.Okuls.Add(okul);
            c.Yoneticis.Add(yonetici);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}
