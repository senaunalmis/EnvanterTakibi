using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnvanterUygulaması.Controllers
{
    public class YazilimController :Controller
    {
        private readonly IYazılımRepository _yazılımRepository;

        public YazilimController (IYazılımRepository yazılımRepository)
        {
            _yazılımRepository = yazılımRepository;
        }
        public IActionResult YazilimEkle() { return View(); }

        [HttpPost]
        public IActionResult YazilimEkle(Yazilimlar yazilim)
        {
            if (yazilim is null)
            {
                throw new ArgumentNullException(nameof(yazilim));
            }
            return RedirectToAction("Ekledigimyazilimlar");
        }
        public IActionResult EkledigimYazlimlar() { return View(); }
        public IActionResult YazilimListe() {
            List<Yazilimlar> yazilimlar = _yazılımRepository.GetYazilimlars();
            YazilimViewModel yazilimViewModel = new YazilimViewModel { yazilimlars = yazilimlar };
            return View(yazilimViewModel);
        }
    }
}
