using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DersDagitimProjesi.Controllers
{
    public class DersController : Controller
    {
        Context c = new Context();
        
        public IActionResult Index()
        {
            var sorgu = c.Derss.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniDers(Ders ders)
        {
            c.Derss.Add(ders);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DersSil(int id)
        {
            var cr = c.Derss.Find(id);
            c.Derss.Remove(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
