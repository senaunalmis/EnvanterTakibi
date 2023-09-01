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

        public async Task<JsonResult> AltTurGetir(int TurId)
        {
            var altTurListe = await _listRepository.AltTurListesiGetir(TurId);
            return Json(altTurListe);
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
