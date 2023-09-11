using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnvanterUygulaması.Controllers
{
    public class ListController : Controller
    {
        private readonly IListRepository _listRepository;

        public ListController(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> BulutAlanlariDoldur(int BulutId)
        {
            var bulut = await _listRepository.BulutOzellikleriGetir(BulutId);
            if (bulut != null)
            {
                return Json(new { bulutNo = bulut.BulutNo, anaDevreNo = bulut.AnaDevreNo });
            }
            else
            {
                return Json(new { bulutNo = "", anaDevreNo = "" });
            }
        }
        public async Task<JsonResult> AltTurGetir(int TurId)
        {
            var altTurListe = await _listRepository.AltTurListesiGetir(TurId);
            return Json(altTurListe);
        }

        public async Task<JsonResult> DonanimMarkasiGetir(int TurId)
        {
            var dMarkaListe = await _listRepository.DonanimMarkaListesiGetir(TurId);
            return Json(dMarkaListe);
        }
        public async Task<JsonResult> UstModelGetir(int MarkaId)
        {
            var ustModelListe = await _listRepository.UstModelListesiGetir(MarkaId);
            return Json(ustModelListe);
        }

        public async Task<JsonResult> AltModelGetir(int UstModelId)
        {
            var altModelListe = await _listRepository.AltModelListesiGetir(UstModelId);
            return Json(altModelListe);
        }
    }
}
