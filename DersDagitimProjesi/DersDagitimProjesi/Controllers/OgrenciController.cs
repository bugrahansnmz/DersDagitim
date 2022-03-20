using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Controllers
{
    public class OgrenciController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var sorgu = c.Ogrencis.Include("Sinif").ToList();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult YeniOgrenci()
        {
            List<SelectListItem> deger1 = (from x in c.Sinifs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SinifNo + x.SinifSube,
                                               Value = x.SinifID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public IActionResult YeniOgrenci(Ogrenci o)
        {
            c.Ogrencis.Add(o);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult OgrenciSil(int id)
        {
            var cr = c.Ogrencis.Find(id);
            c.Ogrencis.Remove(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
