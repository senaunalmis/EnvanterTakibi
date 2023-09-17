using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

namespace EnvanterUygulaması.Controllers
{
    public class DonanimController : Controller
    {
        private readonly IDonanimRepository _donanimRepository;
        private readonly IListRepository _listRepository;
        private readonly IDonanimMarkaRepository _donanimMarkaRepository;
        private readonly IDonanimTurRepository _donanimTurRepository;
        private readonly IDonanimMarkaTurRepository _donanimMarkaTurRepository;
        private readonly IDonanimAltTurRepository _donanimAltTurRepository;
        private readonly IDonanimUstModelRepository _donanimUstModelRepository;
        private readonly IDonanimAltModelRepository _donanimAltModelRepository;




        public DonanimController(
            IDonanimRepository donanimRepository, 
            IListRepository listRepository, 
            IDonanimMarkaRepository donanimMarkaRepository,
            IDonanimTurRepository donanimTurRepository,
            IDonanimMarkaTurRepository donanimMarkaTurRepository,
            IDonanimAltTurRepository donanimAltTurRepository,
            IDonanimUstModelRepository  donanimUstModelRepository,
            IDonanimAltModelRepository  donanimAltModelRepository
            )
        {
            _listRepository = listRepository;
            _donanimRepository = donanimRepository;
            _donanimMarkaRepository = donanimMarkaRepository;
            _donanimTurRepository= donanimTurRepository;
            _donanimMarkaTurRepository= donanimMarkaTurRepository;
            _donanimAltTurRepository = donanimAltTurRepository;
            _donanimUstModelRepository = donanimUstModelRepository;
            _donanimAltModelRepository = donanimAltModelRepository;
            


        }
        
        public async Task<IActionResult> DonanimListe()
        {
            var donanimlar = await _donanimRepository.TumunuGetirInclude();
            List<DonanimVM> donanimListesi = donanimlar.Select(x => new DonanimVM()
            {
                Turu = x.donanimTurleri.Adi,
                AltTuru = x.donanimAltTurleri != null ? x.donanimAltTurleri.Adi : null,
                Markasi = x.donanimMarkalari.Adi,
                UstModeli=x.ustModeller.Adi,
                AltModeli=x.altModeller.Adi,
                MacAdresi=x.MacAdresi,
                SeriNo=x.SeriNo,
                Durumu=x.Durumu,
                Aciklama=x.Aciklama,
                AlimTarihi=x.AlimTarihi.ToShortDateString(),
                Bolge = x.bolgeler.Adi,
                EkleyenKullanici=x.kullanicilar.Adi,
                GarantiSuresi=x.GarantiSuresi,
                Poe=x.Poe
            }).ToList();

            return View(donanimListesi);
        }

        public async Task<IActionResult> DonanimEkle(int id=0)
        {
            DonanimEkleDuzenleVM donanimEkleDuzenleVM = new DonanimEkleDuzenleVM()
            {
                AlimTarihi = DateTime.Now
            };
    
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
                    SeriNo = donanim.SeriNo,
                    BolgeId = donanim.BolgeId,
                    id=donanim.id
                };
                List<Liste> altTurList = await _listRepository.AltTurListesiGetir(donanim.DonanimTuruID);
                List<Liste> markalist = await _listRepository.DonanimMarkaListesiGetir(donanim.DonanimTuruID);
                List<Liste> ustModelList = await _listRepository.UstModelListesiGetir(donanim.DonanimMarkaID);
                List<Liste> altModelList = await _listRepository.AltModelListesiGetir(donanim.UstModelID);
                donanimEkleDuzenleVM.AltTurList = altTurList;
                donanimEkleDuzenleVM.MarkaList = markalist;
                donanimEkleDuzenleVM.UstModelList = ustModelList;
                donanimEkleDuzenleVM.AltModelList = altModelList;
            }
            List<Liste> turList = await _listRepository.TurListesiGetir();
            donanimEkleDuzenleVM.TurList = turList;
            List<Liste> BolgeList = await _listRepository.BolgeListesiGetir();
            donanimEkleDuzenleVM.BolgeList = BolgeList;

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
                        BolgeId = donanimEkleDuzenleVM.BolgeId,
                        Durumu = donanimEkleDuzenleVM.Durum,
                        GarantiSuresi = donanimEkleDuzenleVM.GarantiSuresi,
                        Gucu = donanimEkleDuzenleVM.Guc,
                        Modu = donanimEkleDuzenleVM.Mod,
                        Poe = donanimEkleDuzenleVM.Poe,
                        SeriNo = donanimEkleDuzenleVM.SeriNo,
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
                        mevcutDonanim.BolgeId = donanimEkleDuzenleVM.BolgeId;
                        mevcutDonanim.Durumu = donanimEkleDuzenleVM.Durum;
                        mevcutDonanim.GarantiSuresi = donanimEkleDuzenleVM.GarantiSuresi;
                        mevcutDonanim.Gucu = donanimEkleDuzenleVM.Guc;
                        mevcutDonanim.Modu = donanimEkleDuzenleVM.Mod;
                        mevcutDonanim.Poe = donanimEkleDuzenleVM.Poe;
                        mevcutDonanim.SeriNo = donanimEkleDuzenleVM.SeriNo;

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
                id = x.id,
                Turu = x.donanimTurleri.Adi,
                AltTuru =x.donanimAltTurleri!=null? x.donanimAltTurleri.Adi:null,
                Markasi = x.donanimMarkalari.Adi,
                UstModeli = x.ustModeller.Adi,
                AltModeli = x.altModeller.Adi,
                MacAdresi = x.MacAdresi,
                SeriNo = x.SeriNo,
                Durumu = x.Durumu,
                Aciklama = x.Aciklama,
                AlimTarihi = x.AlimTarihi.ToShortDateString(),
                Bolge = x.bolgeler.Adi,
                EkleyenKullanici = x.kullanicilar.Adi,
                GarantiSuresi = x.GarantiSuresi,
                Poe = x.Poe
            }).ToList();

            return View(donanimListesi);
        }

        public async Task<IActionResult> DonanimMarkaListe()
        {
            DonanimPanelVM donanimPanelVM = new DonanimPanelVM();
            List<DonanimMarkalari> markaListe = await _donanimMarkaRepository.TumunuGetirInclude();
          // var ls = await _donanimMarkaTurRepository.TumunuGetirInclude();
            //List<Liste> markaListe= ls.Select(x => new Liste()
            //{
            //    id = x.donanimMarkalari.id,
            //    Adi = x.donanimMarkalari.Adi,
            //    TurAdlari=string.Join(", ", x.donanimTurleri.Adi)

            //}).ToList();

            donanimPanelVM.MarkaList= markaListe.Select(x=>new Liste 
            { 
                id=x.id,
                Adi=x.Adi,
                TurAdlari=string.Join(", ",x.donanimMarkaTurleri.Select(dm=>dm.donanimTurleri.Adi).ToArray()),
               TurIdler=string.Join(",", x.donanimMarkaTurleri.Select(dm => dm.donanimTurleri.id).ToArray())
            }).ToList();

            var turler = await _donanimTurRepository.TumunuGetir();
            List<Liste> turList= turler.Select(x => new Liste()
            {
                id = x.id,
                Adi = x.Adi
            }).ToList();

            donanimPanelVM.TurList=turList;
            return View(donanimPanelVM);
        }

        public async Task<JsonResult?> DonanimMarkaEkleDuzenle(DonanimPanelVM donanimPanelVM)
        {
            DonanimMarkalari? markaEntity;
            DonanimMarkaTurleri donanimMarkaTurleri;
            if (donanimPanelVM.id == 0)
            {   
                markaEntity = new DonanimMarkalari { Adi = donanimPanelVM.Adi, Durumu = "Aktif" };
                var markaEkleSonuc = await _donanimMarkaRepository.Ekle(markaEntity);
                List<DonanimMarkaTurleri> turList = new List<DonanimMarkaTurleri>();
                foreach (var turId in donanimPanelVM.TurIdler_chk)
                {
                    var tur= new DonanimMarkaTurleri() { TurId = turId, MarkaId=markaEkleSonuc.id };
                    turList.Add(tur);
                }
                
                
                await _donanimMarkaTurRepository.TopluEkle(turList);
                var marka_turList =await _donanimMarkaTurRepository.GetirInclude(markaEkleSonuc.id);

                return Json(new DonanimPanelVM {
                    Adi= donanimPanelVM.Adi,
                    id= markaEkleSonuc.id,
                    TurAdlari=string.Join(", ", marka_turList.Select(aratbl=>aratbl.donanimTurleri.Adi).ToArray()),
                    TurIdler = string.Join(", ", marka_turList.Select(aratbl => aratbl.donanimTurleri.id).ToArray())
                });
            }
            else
            {//transaction oluştur

                markaEntity = await _donanimMarkaRepository.Getir(donanimPanelVM.id);
                if (markaEntity == null)
                    return null;
                markaEntity.Durumu = "Aktif";
                markaEntity.Adi = donanimPanelVM.Adi;
                await _donanimMarkaRepository.Guncelle(markaEntity);

                var mevcutMarka_turList = await _donanimMarkaTurRepository.GetirInclude(markaEntity.id);
                _donanimMarkaTurRepository.TopluSil(mevcutMarka_turList);

                List<DonanimMarkaTurleri> turList = new List<DonanimMarkaTurleri>();
                foreach (var turId in donanimPanelVM.TurIdler_chk)
                {
                    var tur = new DonanimMarkaTurleri() { TurId = turId, MarkaId = markaEntity.id };
                    turList.Add(tur);
                }
                await _donanimMarkaTurRepository.TopluEkle(turList);
                var marka_turList = await _donanimMarkaTurRepository.GetirInclude(markaEntity.id);


                return Json(new DonanimPanelVM
                {
                    Adi = donanimPanelVM.Adi,
                    id = markaEntity.id,
                    TurAdlari = string.Join(", ", marka_turList.Select(aratbl => aratbl.donanimTurleri.Adi).ToArray()),
                    TurIdler = string.Join(", ", marka_turList.Select(aratbl => aratbl.donanimTurleri.id).ToArray())
                });
            }
        }

        public async Task<IActionResult> DonanimTurListe()
        {
            var turler = await _donanimTurRepository.TumunuGetir();
            List<DonanimPanelVM> turListeVM = turler.Select(x => new DonanimPanelVM()
            {
                id = x.id,
                Adi = x.Adi
            }).ToList();
            return View(turListeVM);
        }

        public async Task<JsonResult?> DonanimTurEkleDuzenle(DonanimPanelVM donanimPanelVM)
        {
            DonanimTurleri? turEntity;
            if (donanimPanelVM.id == 0)
            {
                turEntity = new DonanimTurleri { Adi = donanimPanelVM.Adi, Durumu = "Aktif" };
                var sonuc = await _donanimTurRepository.Ekle(turEntity);
                return Json(sonuc);
            }
            else
            {
                turEntity = await _donanimTurRepository.Getir(donanimPanelVM.id);
                if (turEntity == null)
                    return null;
                turEntity.Durumu = "Aktif";
                turEntity.Adi = donanimPanelVM.Adi;
                await _donanimTurRepository.Guncelle(turEntity);
                return Json(turEntity);
            }
        }
        public async Task<IActionResult?> DonanimAltTurListe()
        {
            var turler = await _donanimTurRepository.TumunuGetir();
            var altTurler = await _donanimAltTurRepository.TumunuGetirInclude();
            DonanimPanelVM donanimPanelVM=new DonanimPanelVM();
            donanimPanelVM.AltTurList=altTurler.Select(x=>new Liste { id=x.id,Adi=x.Adi,TurAdi=x.donanimTurleri.Adi,TurId=x.DonanimTuruID}).ToList();
            donanimPanelVM.TurList=turler.Select(x=>new Liste { Adi=x.Adi,id=x.id}).ToList();   
            return View(donanimPanelVM);

        }

        [HttpPost]
        public async Task<JsonResult?> DonanimAltTurEkleDuzenle(DonanimPanelVM donanimPanelVM)
        {
            DonanimAltTurleri? altTurEntity;
            DonanimAltTurleri donanimAltTurleri;
            if (donanimPanelVM.id == 0)
            {
                donanimAltTurleri = new DonanimAltTurleri() { Adi=donanimPanelVM.Adi, DonanimTuruID=donanimPanelVM.TurId.Value};

                var sonuc = await _donanimAltTurRepository.Ekle(donanimAltTurleri);


                return Json(new DonanimPanelVM { Adi = donanimPanelVM.Adi, id = sonuc.id });
            }
            else
            {
                altTurEntity = await _donanimAltTurRepository.Getir(donanimPanelVM.id);
                if (altTurEntity == null)
                    return null;
                altTurEntity.Durumu = "Aktif";
                altTurEntity.Adi = donanimPanelVM.Adi;

                //donanimMarkaTurleri= await _donanimMarkaTurRepository.GetirInclude(markaId: )
                //await _donanimMarkaRepository.Guncelle(markaEntity);
                return Json(altTurEntity);
            }
        }

        public async Task<IActionResult?> DonanimUstModelListe()
        {
            var modeller = await _donanimMarkaRepository.TumunuGetir();
            var ustModeller = await _donanimUstModelRepository.TumunuGetirInclude();
            DonanimPanelVM donanimPanelVM = new DonanimPanelVM();
            donanimPanelVM.UstModelList = ustModeller.Select(x => new Liste { id = x.id, Adi = x.Adi, MarkaAdi = x.Adi, MarkaId = x.DonanimMarkaId }).ToList();
            donanimPanelVM.MarkaList = modeller.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return View(donanimPanelVM);

        }

        [HttpPost]
        public async Task<JsonResult?> DonanimUstModelEkleDuzenle(DonanimPanelVM donanimPanelVM)
        {
            UstModeller? ustModelEntity;
            UstModeller ustModelMarkalari;
            if (donanimPanelVM.id == 0)
            {
                ustModelMarkalari = new UstModeller() { Adi = donanimPanelVM.Adi, DonanimMarkaId = donanimPanelVM.MarkaId.Value };

                var sonuc = await _donanimUstModelRepository.Ekle(ustModelMarkalari);


                return Json(new DonanimPanelVM { Adi = donanimPanelVM.Adi, id = sonuc.id });
            }
            else
            {
                ustModelEntity = await _donanimUstModelRepository.Getir(donanimPanelVM.id);
                if (ustModelEntity == null)
                    return null;

                ustModelEntity.Adi = donanimPanelVM.Adi;

                //donanimMarkaTurleri= await _donanimMarkaTurRepository.GetirInclude(markaId: )
                //await _donanimMarkaRepository.Guncelle(markaEntity);
                return Json(ustModelEntity);
            }
        }

        public async Task<IActionResult?> DonanimAltModelListe()
        {
            var modeller = await _donanimUstModelRepository.TumunuGetir();
            var altModeller = await _donanimAltModelRepository.TumunuGetirInclude();
            DonanimPanelVM donanimPanelVM = new DonanimPanelVM();
            donanimPanelVM.AltModelList = altModeller.Select(x => new Liste { id = x.id, Adi = x.Adi, UstModelAdi = x.Adi, UstModelId = x.UstModelID }).ToList();
            donanimPanelVM.UstModelList = modeller.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return View(donanimPanelVM);

        }

        [HttpPost]
        public async Task<JsonResult?> DonanimAltModelEkleDuzenle(DonanimPanelVM donanimPanelVM)
        {
            AltModeller? altModelEntity;
            AltModeller altModelUstModeli;
            if (donanimPanelVM.id == 0)
            {
                altModelUstModeli = new AltModeller() { Adi = donanimPanelVM.Adi, UstModelID = donanimPanelVM.UstModelId.Value };

                var sonuc = await _donanimAltModelRepository.Ekle(altModelUstModeli);


                return Json(new DonanimPanelVM { Adi = donanimPanelVM.Adi, id = sonuc.id });
            }
            else
            {
                altModelEntity = await _donanimAltModelRepository.Getir(donanimPanelVM.id);
                if (altModelEntity == null)
                    return null;

                altModelEntity.Adi = donanimPanelVM.Adi;

                //donanimMarkaTurleri= await _donanimMarkaTurRepository.GetirInclude(markaId: )
                //await _donanimMarkaRepository.Guncelle(markaEntity);
                return Json(altModelEntity);
            }
        }


    }
}
