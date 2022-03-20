using Auth0.AspNetCore.Authentication;
using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DersDagitimProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Index(Admin a)
        {
            var query = c.Admins.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi && x.Sifre == a.Sifre);

            if (query != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,a.KullaniciAdi)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "GenelBilgi");
            }
            return View();
        }
        [HttpGet]
        public IActionResult YeniKullanici() { return View(); }
        [HttpPost]
        public IActionResult YeniKullanici(Admin a)
        {
            c.Admins.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
