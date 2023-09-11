using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Controllers
{
    public class DevreController : Controller
    {
        private readonly IBulutRepository _bulutRepository;
        private readonly IDevreRepository _devreRepository;
        private readonly IListRepository _listRepository;
        public DevreController(IDevreRepository devreRepository, 
            IListRepository listRepository,
            IBulutRepository bulutRepository)
        {
            _devreRepository = devreRepository;
            _listRepository = listRepository;
            _bulutRepository = bulutRepository;
        }

        public async Task<IActionResult> DevreListe()
        {
            var devreler = await _devreRepository.TumunuGetirInclude();
            List<DevreVM> devreListe = devreler.Select(x => new DevreVM()
            {
                Aciklama = x.Aciklama,
                Adi = x.Adi,
                AnaDevreNo = x.bulutlar.AnaDevreNo,
                BulutAdi = x.bulutlar.Adi,
                Bolge = x.bolgeler.Adi,
                BulutNo = x.bulutlar.BulutNo,
                Durumu = x.Durumu,
                EkleyenKullanici = x.kullanicilar.Adi,
                IpBlogu = x.IpBlogu,
                Koordinati = x.Koordinat,
                Mahsup = x.Mahsup?"Var":"Yok",
                Nosu = x.No,
                id = x.id
            }).ToList();

            return View(devreListe);
        }

        public async Task<IActionResult> DevreEkle(int id = 0)
        {
            DevreEkleDüzenleVM devreEkleDüzenleVM = new DevreEkleDüzenleVM();
            List<Liste> BulutList = await _listRepository.BulutListesiGetir();
            devreEkleDüzenleVM.BulutList = BulutList;
            List<Liste> BolgeList = await _listRepository.BolgeListesiGetir();
            devreEkleDüzenleVM.BolgeList = BolgeList;
            if (id != 0)
            {
                var devre = await _devreRepository.Getir(id);
                if (devre == null)
                {
                    RedirectToAction("EkledigimDevreler");
                }
                devreEkleDüzenleVM = new DevreEkleDüzenleVM
                {
                    Aciklama = devre.Aciklama,
                    Adi = devre.Adi,
                    AnaDevreNo = devre.bulutlar.AnaDevreNo,
                    BulutAdi = devre.bulutlar.Adi,
                    BolgeId = devre.BolgeId,
                    BulutNo = devre.bulutlar.BulutNo,
                    BulutId= devre.BulutID,
                    DevreNo = devre.No,
                    Durum = devre.Durumu,
                    Koordinat = devre.Koordinat,
                    Mahsup = devre.Mahsup,
                    IpBlogu = devre.IpBlogu,

                };
                devreEkleDüzenleVM.BulutList = BulutList;
                devreEkleDüzenleVM.BolgeList = BolgeList;
            }
            return View(devreEkleDüzenleVM);
        }

        [HttpPost]
        public async Task<IActionResult> DevreEkle(DevreEkleDüzenleVM devreEkleDuzenleVM)
        {
            try
            {
                if (devreEkleDuzenleVM.id == 0)
                {
                    var eklenenDevre = await _devreRepository.Ekle(new Devreler
                    {
                        Aciklama = devreEkleDuzenleVM.Aciklama,
                        Adi = devreEkleDuzenleVM.Adi,
                        EkleyenID = 1,
                        Durumu = devreEkleDuzenleVM.Durum,
                        Koordinat = devreEkleDuzenleVM.Koordinat,
                        Mahsup = devreEkleDuzenleVM.Mahsup,
                        IpBlogu = devreEkleDuzenleVM.IpBlogu,
                        BulutID = devreEkleDuzenleVM.BulutId,
                        BolgeId = devreEkleDuzenleVM.BolgeId,
                        No= devreEkleDuzenleVM.DevreNo,
                        id = devreEkleDuzenleVM.id
                    });
                    RedirectToAction("EkledigimDevreler");
                }
                else
                {
                    var mevcutdevre = await _devreRepository.GetirInclude(devreEkleDuzenleVM.id);
                    if (mevcutdevre == null)
                    {
                        RedirectToAction("EkledigimDevreler");
                    }
                    else
                    {
                        mevcutdevre.Aciklama = devreEkleDuzenleVM.Aciklama;
                        mevcutdevre.Adi = devreEkleDuzenleVM.Adi;
                        mevcutdevre.Durumu = devreEkleDuzenleVM.Durum;
                        mevcutdevre.Koordinat = devreEkleDuzenleVM.Koordinat;
                        mevcutdevre.Mahsup = devreEkleDuzenleVM.Mahsup;
                        mevcutdevre.IpBlogu = devreEkleDuzenleVM.IpBlogu;
                        mevcutdevre.BulutID = devreEkleDuzenleVM.BulutId;
                        mevcutdevre.BolgeId = devreEkleDuzenleVM.BolgeId;
                        mevcutdevre.No = devreEkleDuzenleVM.DevreNo;
                        await _devreRepository.Guncelle(mevcutdevre);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("EkledigimDevreler");
        }

        public async Task<IActionResult> EkledigimDevreler()
        {
            var devreler = await _devreRepository.TumunuGetirInclude();
            List<DevreVM> devreListe = devreler.Select(x => new DevreVM()
            {
                Aciklama = x.Aciklama,
                Adi = x.Adi,
                AnaDevreNo = x.bulutlar.AnaDevreNo,
                BulutAdi = x.bulutlar.Adi,
                Bolge = x.bolgeler.Adi,
                BulutNo = x.bulutlar.BulutNo,
                Durumu = x.Durumu,
                EkleyenKullanici = x.kullanicilar.Adi,
                IpBlogu = x.IpBlogu,
                Koordinati = x.Koordinat,
                Mahsup = x.Mahsup?"Var":"Yok",
                Nosu = x.No,
                id = x.id
            }).ToList();

            return View(devreListe);
        }

        public async Task<IActionResult> BulutListe()
        {
            var bulutlar = await _bulutRepository.TumunuGetir();
            List<DevrePanelVM> bulutListVM = bulutlar.Select(x => new DevrePanelVM()
            {
                id = x.id,
                AnaDevreNo=x.AnaDevreNo,
                BulutAdi=x.Adi,
                BulutNo=x.BulutNo
            }).ToList();
            return View(bulutListVM);
        }

        [HttpPost]
        public async Task<JsonResult?> BulutEkleDuzenle( DevrePanelVM devrePanelVM)
        {
            string mesaj = "";
            Bulutlar? bulutEntity;
            if (devrePanelVM.id==0)
            {
                mesaj = await _bulutRepository.BulutKontrolMesaji(devrePanelVM.BulutNo, devrePanelVM.BulutAdi, devrePanelVM.AnaDevreNo);
                if (string.IsNullOrEmpty(mesaj))
                {
                    bulutEntity = new Bulutlar
                    {
                        Adi = devrePanelVM.BulutAdi,
                        AnaDevreNo = devrePanelVM.AnaDevreNo,
                        BulutNo = devrePanelVM.BulutNo
                    };
                    var sonuc = await _bulutRepository.Ekle(bulutEntity);
                    devrePanelVM.Kontrol = true;
                    return Json(devrePanelVM);
                }
                else
                {
                    devrePanelVM.Kontrol = false;
                    devrePanelVM.Mesaj = mesaj;
                    return Json(devrePanelVM);
                }
            }
            else {
                bulutEntity = await _bulutRepository.Getir(devrePanelVM.id);
                if (bulutEntity.BulutNo != devrePanelVM.BulutNo) // Aynı bulut id'sine sahip kayıt var mı?
                {
                    mesaj= await _bulutRepository.BulutNoKontrolMesaji(devrePanelVM.BulutNo);
                    if (string.IsNullOrEmpty(mesaj))
                    {
                        bulutEntity.BulutNo= devrePanelVM.BulutNo;
                        devrePanelVM.Kontrol = true;
                        await _bulutRepository.Guncelle(bulutEntity);
                    }
                    else
                    {
                        devrePanelVM.Kontrol = false;
                        devrePanelVM.Mesaj = mesaj;
                    }
                }
                if(!bulutEntity.Adi.Equals(devrePanelVM.BulutAdi))// Aynı bulut adına sahip kayıt var mı?
                {
                    mesaj += await _bulutRepository.BulutAdiKontrolMesaji(devrePanelVM.BulutAdi);
                    if (string.IsNullOrEmpty(mesaj))
                    {
                        bulutEntity.Adi = devrePanelVM.BulutAdi;
                        devrePanelVM.Kontrol = true;
                        await _bulutRepository.Guncelle(bulutEntity);
                    }
                    else
                    {
                        devrePanelVM.Kontrol = false;
                        devrePanelVM.Mesaj = mesaj;
                        
                    }
                }
                if (!bulutEntity.AnaDevreNo.Equals(devrePanelVM.AnaDevreNo))// Aynı ana devre no'suna sahip kayıt var mı?
                {
                    mesaj += await _bulutRepository.AnaDevreNoKontrolMesaji(devrePanelVM.AnaDevreNo);
                    if (string.IsNullOrEmpty(mesaj))
                    {
                        bulutEntity.AnaDevreNo = devrePanelVM.AnaDevreNo;
                        devrePanelVM.Kontrol = true;
                        await _bulutRepository.Guncelle(bulutEntity);
                    }
                    else
                    {
                        devrePanelVM.Kontrol = false;
                        devrePanelVM.Mesaj = mesaj;
                    }
                }
                return Json(devrePanelVM);
                //if (string.IsNullOrEmpty(mesaj))
                //{
                //    bulutEntity = await _bulutRepository.Getir(devrePanelVM.id);
                //    if (bulutEntity == null)
                //        return null;
                //    bulutEntity.BulutNo = devrePanelVM.BulutNo;
                //    bulutEntity.Adi = devrePanelVM.BulutAdi;
                //    bulutEntity.AnaDevreNo = devrePanelVM.AnaDevreNo;
                //    await _bulutRepository.Guncelle(bulutEntity);
                //    return Json(devrePanelVM);
                //}
                //else
                //{
                //    devrePanelVM.Kontrol = false;
                //    devrePanelVM.Mesaj = mesaj;
                //    return Json(devrePanelVM);
                //}
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
