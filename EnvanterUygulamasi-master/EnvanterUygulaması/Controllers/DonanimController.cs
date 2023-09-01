using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnvanterUygulaması.Controllers
{
    public class DonanimController : Controller
    {
        private readonly IDonanimRepository _donanimRepository;
        private readonly IListRepository _listRepository;

        public DonanimController(IDonanimRepository donanimRepository, IListRepository listRepository)
        {
            _listRepository = listRepository;
            _donanimRepository = donanimRepository;
        }
        
        public async Task<IActionResult> DonanimListe()
        {
            var donanimlar = await _donanimRepository.TumunuGetirInclude();
            List<DonanimVM> donanimListesi = donanimlar.Select(x => new DonanimVM()
            {
                Turu = x.donanimTurleri.Adi,
                AltTuru=x.donanimAltTurleri.Adi,
                Markasi=x.donanimMarkalari.Adi,
                UstModeli=x.ustModeller.Adi,
                AltModeli=x.altModeller.Adi,
                MacAdresi=x.MacAdresi,
                SeriNo=x.SeriNo,
                Durumu=x.Durumu,
                Aciklama=x.Aciklama,
                AlimTarihi=x.AlimTarihi,
                Birimi=x.Birim,
                EkleyenKullanici=x.kullanicilar.Adi,
                GarantiSuresi=x.GarantiSuresi,
                Poe=x.Poe
            }).ToList();

            return View(donanimListesi);
        }

        public async Task<IActionResult> DonanimEkle(int id=0)
        {
            DonanimEkleDuzenleVM donanimEkleDuzenleVM = new DonanimEkleDuzenleVM();
            List<Liste> turList = await _listRepository.TurListesiGetir();
            donanimEkleDuzenleVM.TurList = turList;
            List<Liste> markaList =await _listRepository.DonanimMarkaListesiGetir();
            donanimEkleDuzenleVM.MarkaList = markaList;

            if (id != 0)
            {
                var donanim = await _donanimRepository.Getir(id);
                if (donanim == null)
                {
                    RedirectToAction("EkledigimDonanimlar");
                }
                donanimEkleDuzenleVM = new DonanimEkleDuzenleVM
                {
                    Aciklama = donanim.Aciklama,
                    AlimTarihi = donanim.AlimTarihi,
                    AltModelId = donanim.AltModelID,
                    AltTurId = donanim.DonanimAltTuruID,
                    UstModelId = donanim.UstModelID,
                    TurId = donanim.DonanimTuruID,
                    BaglantiHizi = donanim.BaglantiHizi,
                    MacAdres = donanim.MacAdresi,
                    GarantiSuresi = donanim.GarantiSuresi,
                    Guc = donanim.Gucu,
                    Mod = donanim.Modu,
                    MarkaId = donanim.DonanimMarkaID,
                    Poe = donanim.Poe,
                    Tip = donanim.Tipi,
                    SeriNo = donanim.SeriNo,
                    Birim = donanim.Birim
                };

            }
            return View(donanimEkleDuzenleVM);
        }
        [HttpPost]
        public async Task<IActionResult> DonanimEkle(DonanimEkleDuzenleVM donanimEkleDuzenleVM)
        {
            try
            {
                if (donanimEkleDuzenleVM.id == 0)
                {
                    var eklenenDonanim = await _donanimRepository.Ekle(new Donanimlar
                    {
                        Aciklama = donanimEkleDuzenleVM.Aciklama,
                        AlimTarihi = donanimEkleDuzenleVM.AlimTarihi,
                        AltModelID = donanimEkleDuzenleVM.AltModelId,
                        UstModelID = donanimEkleDuzenleVM.UstModelId,
                        DonanimTuruID = donanimEkleDuzenleVM.TurId,
                        DonanimAltTuruID = donanimEkleDuzenleVM.AltTurId,
                        DonanimMarkaID = donanimEkleDuzenleVM.MarkaId,
                        MacAdresi = donanimEkleDuzenleVM.MacAdres,
                        BaglantiHizi = donanimEkleDuzenleVM.BaglantiHizi,
                        Birim = donanimEkleDuzenleVM.Birim,
                        Durumu = donanimEkleDuzenleVM.Durum,
                        GarantiSuresi = donanimEkleDuzenleVM.GarantiSuresi,
                        Gucu = donanimEkleDuzenleVM.Guc,
                        Modu = donanimEkleDuzenleVM.Mod,
                        Poe = donanimEkleDuzenleVM.Poe,
                        SeriNo = donanimEkleDuzenleVM.SeriNo,
                        Tipi = donanimEkleDuzenleVM.Tip,
                        EkleyenID=1
                    });
                    return RedirectToAction("EkledigimDonanimlar");
                }
                else
                {
                    var mevcutDonanim = await _donanimRepository.GetirInclude(donanimEkleDuzenleVM.id);
                    if (mevcutDonanim == null)
                    {
                        return RedirectToAction("EkledigimDonanimlar");
                    }
                    else
                    {
                        mevcutDonanim.Aciklama = donanimEkleDuzenleVM.Aciklama;
                        mevcutDonanim.AlimTarihi = donanimEkleDuzenleVM.AlimTarihi;
                        mevcutDonanim.AltModelID = donanimEkleDuzenleVM.AltModelId;
                        mevcutDonanim.UstModelID = donanimEkleDuzenleVM.UstModelId;
                        mevcutDonanim.DonanimTuruID = donanimEkleDuzenleVM.TurId;
                        mevcutDonanim.DonanimAltTuruID = donanimEkleDuzenleVM.AltTurId;
                        mevcutDonanim.DonanimMarkaID = donanimEkleDuzenleVM.MarkaId;
                        mevcutDonanim.MacAdresi = donanimEkleDuzenleVM.MacAdres;
                        mevcutDonanim.BaglantiHizi = donanimEkleDuzenleVM.BaglantiHizi;
                        mevcutDonanim.Birim = donanimEkleDuzenleVM.Birim;
                        mevcutDonanim.Durumu = donanimEkleDuzenleVM.Durum;
                        mevcutDonanim.GarantiSuresi = donanimEkleDuzenleVM.GarantiSuresi;
                        mevcutDonanim.Gucu = donanimEkleDuzenleVM.Guc;
                        mevcutDonanim.Modu = donanimEkleDuzenleVM.Mod;
                        mevcutDonanim.Poe = donanimEkleDuzenleVM.Poe;
                        mevcutDonanim.SeriNo = donanimEkleDuzenleVM.SeriNo;
                        mevcutDonanim.Tipi = donanimEkleDuzenleVM.Tip;

                        await _donanimRepository.Guncelle(mevcutDonanim);
                    }
                }
            }
            catch (Exception ex)
            {

                // hata yakalama ve görüntüleme
                TempData["HataMesaji"] = "Bir hata oluştu: " + ex.Message;
                return View(donanimEkleDuzenleVM);
            }



            return RedirectToAction("EkledigimDonanimlar");
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> EkledigimDonanimlar()
        {
            var donanimlar = await _donanimRepository.TumunuGetirInclude();
            List<DonanimVM> donanimListesi = donanimlar.Select(x => new DonanimVM()
            {
                Turu = x.donanimTurleri.Adi,
                AltTuru =x.donanimAltTurleri!=null? x.donanimAltTurleri.Adi:null,
                Markasi = x.donanimMarkalari.Adi,
                UstModeli = x.ustModeller.Adi,
                AltModeli = x.altModeller.Adi,
                MacAdresi = x.MacAdresi,
                SeriNo = x.SeriNo,
                Durumu = x.Durumu,
                Aciklama = x.Aciklama,
                AlimTarihi = x.AlimTarihi,
                Birimi = x.Birim,
                EkleyenKullanici = x.kullanicilar.Adi,
                GarantiSuresi = x.GarantiSuresi,
                Poe = x.Poe
            }).ToList();

            return View(donanimListesi);
        }
        
    }
}
