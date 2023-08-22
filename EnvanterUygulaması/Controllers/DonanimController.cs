using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnvanterUygulaması.Controllers
{
    public class DonanimController : Controller
    {
        private readonly IDonanimRepository _donanimRepository;

        public DonanimController(IDonanimRepository donanimRepository)
        {
            _donanimRepository = donanimRepository;
        }
        public IActionResult DonanimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DonanimEkle(Donanimlar donanim)
        {
            if (donanim is null)
            {
                throw new ArgumentNullException(nameof(donanim));
            }
            //_donanimRepository.Add(donanim);
            return RedirectToAction("EkledigimDonanimlar");
        }

        public IActionResult EkledigimDonanimlar()
        {
            return View();
        }

        public IActionResult DonanimListe()
        {

            List<Donanimlar> donanimlar = _donanimRepository.GetAllDonanimlar();
            DonanimViewModel donanimViewModel = new DonanimViewModel
            {
                Donanimlars=donanimlar
            };

            //var donanimList = _donanimRepository.TumunuGetir(
            //    d=> d.DonanimTuru.Adi,
            //    d=>d.DonanimAltTuru,
            //    d=>d.DonanimMarka,
            //    d=>d.UstModel,
            //    d => d.AltModel,
            //    d=>d.Kullanici
            //    );
            //var donanimViewModelList = donanimList.Select(d => new DonanimViewModel
            //{
            //    id = d.id,
            //    Turu = d.DonanimTuru.Adi,
            //    AltTuru = d.DonanimAltTuru.Adi,
            //    Marka = d.DonanimMarka.Adi,
            //    UstModel = d.UstModel.Adi,
            //    AltModel = d.AltModel.Adi,
            //    MacAdresi = d.MacAdresi,
            //    SeriNo = d.SeriNo,
            //    Durumu = d.Durumu,
            //    GarantiSuresi = d.GarantiSuresi,
            //    AlimTarihi = d.AlimTarihi,
            //    Adedi = d.Adedi,
            //    Poe = d.Poe,
            //    BaglantiHizi = d.BaglantiHizi,
            //    Modu = d.Modu,
            //    Tipi = d.Tipi,
            //    EkleyenKullanici = d.Kullanici.Adi,
            //    Birim = d.Birim,
            //    Aciklama = d.Aciklama

            //}).ToList();

            return View(donanimViewModel);
        }
    }
}
