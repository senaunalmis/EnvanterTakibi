using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EnvanterUygulaması.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IKullanicilarRepository _kullanicilarRepository;
        public SecurityController(IKullanicilarRepository kullanicilarRepository)
        {
            _kullanicilarRepository = kullanicilarRepository;
        }
        
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if(claimUser.Identity != null && claimUser.Identity.IsAuthenticated) { return RedirectToAction("Index", "Home"); }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var kullanici = await _kullanicilarRepository.EpostaylaGetirInclude(model.Eposta);
            if (kullanici == null)
            {
                ViewBag.Mesaj = "Kullanıcı bulunamadı";
                return View();
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,kullanici.Eposta),
                new Claim(ClaimTypes.NameIdentifier,kullanici.id.ToString())
            };

            foreach (var kr in kullanici.kullaniciRolleri)
            {
                claims.Add(new Claim(ClaimTypes.Role, kr.roller.Ad));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Security");
        }
    }
}
