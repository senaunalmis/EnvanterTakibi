using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Controllers
{
    public class YazilimController : Controller
    {
        private readonly IYazilimRepository _yazilimRepository;
        private readonly IListRepository _listRepository;
        private readonly IYazilimMarkaRepository _yazilimMarkaRepository;

        public YazilimController(IYazilimRepository yazilimRepository,
            IListRepository listRepository, 
            IYazilimMarkaRepository yazilimMarkaRepository)
        {
            _yazilimRepository = yazilimRepository;
            _listRepository = listRepository;
            _yazilimMarkaRepository = yazilimMarkaRepository;
        }

        public async Task<IActionResult> YazilimListe() 
        {
            var yazilimlar = await _yazilimRepository.TumunuGetirInclude();
            List<YazilimVM> yazilimListesi = yazilimlar.Select(x=>new YazilimVM()
            {
                Markasi=x.yazilimMarkalari.Adi,
                Aciklama=x.Aciklama,
                Adi=x.Adi,
                AlimTarihi=x.AlimTarihi.ToShortDateString(),
                CihazSayisi =x.CihazSayisi,
                DestekSuresi=x.DestekSuresi,
                EkleyenKullanici=x.kullanicilar.Adi,
                Turu=x.Turu,
                Versiyonu=x.Versiyon,
                Bolge = x.bolgeler.Adi         
            }).ToList();
            return View(yazilimListesi);
        }
        public async Task<IActionResult> YazilimEkle(int id = 0)
        {
            YazilimEkleDuzenleVM yazilimEkleDuzenleVM = new YazilimEkleDuzenleVM()
            {
                AlimTarihi = DateTime.Now
            };
            List<Liste> markaList = await _listRepository.YazilimMarkaListesiGetir();
            yazilimEkleDuzenleVM.MarkaList = markaList;
            List<Liste> bolgeList = await _listRepository.BolgeListesiGetir();
            yazilimEkleDuzenleVM.BolgeList = bolgeList;
            if (id != 0)
            {
                var yazilim = await _yazilimRepository.Getir(id);
                if (yazilim == null)
                {
                    RedirectToAction("EkledigimYazilimlar");
                }
                yazilimEkleDuzenleVM = new YazilimEkleDuzenleVM
                {
                    Aciklama = yazilim.Aciklama,
                    Adi = yazilim.Adi,
                    AlimTarihi = yazilim.AlimTarihi,
                    CihazSayisi = yazilim.CihazSayisi,
                    DestekSuresi = yazilim.DestekSuresi,
                    MarkaId = yazilim.YazilimMarkaID,
                    Turu = yazilim.Turu,
                    Versiyonu = yazilim.Versiyon,
                    BolgeId = yazilim.BolgeId,
                    id= yazilim.id
                };
                yazilimEkleDuzenleVM.MarkaList = markaList;
                yazilimEkleDuzenleVM.BolgeList = bolgeList;
            }

            return View(yazilimEkleDuzenleVM);
        }

        [HttpPost]
        public async Task<IActionResult> YazilimEkle(YazilimEkleDuzenleVM yazilimEkleDuzenleVM)
        {
            try
            {
                if (yazilimEkleDuzenleVM.id == 0)
                {
                    var eklenenyazilim = await _yazilimRepository.Ekle(new Yazilimlar
                    {
                        Aciklama = yazilimEkleDuzenleVM.Aciklama,
                        Adi = yazilimEkleDuzenleVM.Adi,
                        AlimTarihi = yazilimEkleDuzenleVM.AlimTarihi,
                        CihazSayisi = yazilimEkleDuzenleVM.CihazSayisi,
                        DestekSuresi = yazilimEkleDuzenleVM.DestekSuresi,
                        EkleyenID = 1,
                        Turu = yazilimEkleDuzenleVM.Turu,
                        Versiyon = yazilimEkleDuzenleVM.Versiyonu,
                        YazilimMarkaID = yazilimEkleDuzenleVM.MarkaId,
                        BolgeId = yazilimEkleDuzenleVM.BolgeId
                    });
                    RedirectToAction("EkledigimYazilimlar");
                }
                else
                {
                    var mevcutyazilim = await _yazilimRepository.GetirInclude(yazilimEkleDuzenleVM.id);
                    if (mevcutyazilim == null)
                    {
                        RedirectToAction("EkledigimYazilimlar");
                    }
                    else
                    {
                        mevcutyazilim.Aciklama = yazilimEkleDuzenleVM.Aciklama;
                        mevcutyazilim.Adi = yazilimEkleDuzenleVM.Adi;
                        mevcutyazilim.AlimTarihi = yazilimEkleDuzenleVM.AlimTarihi;
                        mevcutyazilim.CihazSayisi = yazilimEkleDuzenleVM.CihazSayisi;
                        mevcutyazilim.DestekSuresi = yazilimEkleDuzenleVM.DestekSuresi;
                        mevcutyazilim.Turu = yazilimEkleDuzenleVM.Turu;
                        mevcutyazilim.Versiyon = yazilimEkleDuzenleVM.Versiyonu;
                        mevcutyazilim.YazilimMarkaID = yazilimEkleDuzenleVM.MarkaId;
                        mevcutyazilim.BolgeId = yazilimEkleDuzenleVM.BolgeId;
                       
                        await _yazilimRepository.Guncelle(mevcutyazilim);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("EkledigimYazilimlar");
        }
        public async Task<IActionResult> EkledigimYazilimlar()
        {
            var yazilimlar = await _yazilimRepository.TumunuGetirInclude();
            List<YazilimVM> yazilimListesi = yazilimlar.Select(x => new YazilimVM()
            {
                Markasi = x.yazilimMarkalari.Adi,
                Aciklama = x.Aciklama,
                Adi = x.Adi,
                AlimTarihi = x.AlimTarihi.ToShortDateString(),
                CihazSayisi = x.CihazSayisi,
                DestekSuresi = x.DestekSuresi,
                EkleyenKullanici = x.kullanicilar.Adi,
                Turu = x.Turu,
                Versiyonu = x.Versiyon,
                Bolge = x.bolgeler.Adi,
                id =x.id
            }).ToList();
            return View(yazilimListesi);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> YazilimMarkaListe()
        {
            YazilimPanelVM yazilimPanelVM = new YazilimPanelVM();
            var markalar = await _yazilimMarkaRepository.TumunuGetir();
            List<Liste> liste = markalar.Select(x => new Liste()
            {
                id=x.id,
                Adi=x.Adi,

            }).ToList();

            yazilimPanelVM.MarkaList = liste;
            return View(yazilimPanelVM);
        }

        public async Task<JsonResult?> YazilimMarkaEkleDuzenle(YazilimPanelVM yazilimPanelVM)
        {
            YazilimMarkalari? markaEntity;
            if (yazilimPanelVM.id == 0)
            {
                markaEntity = new YazilimMarkalari { Adi=yazilimPanelVM.Adi, Durumu="Aktif"};
                var sonuc = await _yazilimMarkaRepository.Ekle(markaEntity);
                return Json(sonuc);
            }
            else
            {
                markaEntity = await _yazilimMarkaRepository.Getir(yazilimPanelVM.id);
                if (markaEntity == null)
                    return null;
                markaEntity.Durumu = "Aktif";
                markaEntity.Adi = yazilimPanelVM.Adi;
                await _yazilimMarkaRepository.Guncelle(markaEntity);
                return Json(markaEntity);
            }
        }
    }
}
