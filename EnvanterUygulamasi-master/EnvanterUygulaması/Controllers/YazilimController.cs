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
        public YazilimController(IYazilimRepository yazilimRepository, IListRepository listRepository)
        {
            _yazilimRepository = yazilimRepository;
            _listRepository = listRepository;
        }

        public async Task<IActionResult> YazilimListe() 
        {
            var yazilimlar = await _yazilimRepository.TumunuGetirInclude();
            List<YazilimVM> yazilimListesi = yazilimlar.Select(x=>new YazilimVM()
            {
                Markasi=x.yazilimMarkalari.Adi,
                Aciklama=x.Aciklama,
                Adi=x.Adi,
                AlimTarihi=x.AlimTarihi,
                CihazSayisi=x.CihazSayisi,
                DestekSuresi=x.DestekSuresi,
                EkleyenKullanici=x.kullanicilar.Adi,
                Turu=x.Turu,
                Versiyonu=x.Versiyon
            }).ToList();
            return View(yazilimListesi);
        }
        public async Task<IActionResult> YazilimEkle(int id=0)
        {
           YazilimEkleDuzenleVM yazilimEkleDuzenleVM =new YazilimEkleDuzenleVM();
           List<Liste> markaList = await _listRepository.YazilimMarkaListesiGetir();
           yazilimEkleDuzenleVM.MarkaList=markaList;
            if(id!=0)
            {
                var yazilim = await _yazilimRepository.Getir(id);
                if(yazilim==null)
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
                    Birimi=yazilim.Birim
                };
            }

            return View(yazilimEkleDuzenleVM);
        }

        [HttpPost]
        public async Task<IActionResult> YazilimEkle(YazilimEkleDuzenleVM yazilimEkleDuzenleVM)
        {
            try
            {
                if(yazilimEkleDuzenleVM.id==0)
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
                        Birim=yazilimEkleDuzenleVM.Birimi

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
                        mevcutyazilim.Birim = yazilimEkleDuzenleVM.Birimi;
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
        public IActionResult EkledigimYazilimlar()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
