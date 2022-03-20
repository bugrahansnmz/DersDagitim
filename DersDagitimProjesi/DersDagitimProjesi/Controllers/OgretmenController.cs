using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Controllers
{
    public class OgretmenController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var sorgu = c.Ogretmens.Include("Ders").ToList();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult YeniOgretmen()
        {
            List<SelectListItem> deger = (from x in c.Derss.Where(x=>x.DersAd != "Öğle Arası").ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DersAd,
                                               Value = x.DersID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public IActionResult YeniOgretmen(Ogretmen o)
        {
            c.Ogretmens.Add(o);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult OgretmenSil(int id)
        {
            var cr = c.Ogretmens.Find(id);
            c.Ogretmens.Remove(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
