using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace EnvanterUygulaması.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KullaniciYonetimController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        private readonly IKullanicilarRepository _kullanicilarRepository;
        private readonly IKullaniciRolleriRepository _kullaniciRolleriRepository;
        private readonly IRollerRepository _rollerRepository;

        public KullaniciYonetimController(
            IKullanicilarRepository kullanicilarRepository,
            IKullaniciRolleriRepository kullaniciRolleriRepository,
            IRollerRepository rollerRepository)
        {
            _kullanicilarRepository = kullanicilarRepository;
            _kullaniciRolleriRepository = kullaniciRolleriRepository;
            _rollerRepository = rollerRepository;

        }

        public async Task<IActionResult> Index()
        {
            var kullanicilar = await _kullanicilarRepository.TumunuGetirInclude();
            List<KullaniciListeVM> kullanicilarListesi = kullanicilar.Select(k => new KullaniciListeVM()
            {
                Id = k.id,
                Eposta = k.Eposta,
                Ad = k.Adi,
                Soyad = k.Soyad,
                Roller = string.Join(",", k.kullaniciRolleri.Select(kr => kr.roller.Ad))
            }).ToList();
            return View(kullanicilarListesi);

        }
        public async Task<IActionResult> EkleDuzenle(int id)
        {
            KullaniciEkleDuzenleVM kullaniciEkleDuzenleVM;
            if (id == 0)
            {
                kullaniciEkleDuzenleVM = new KullaniciEkleDuzenleVM();
            }
            else
            {
                Kullanicilar? kullanici = await _kullanicilarRepository.GetirInclude(id);
                if (kullanici == null)
                {
                    //hata mesajı verilebilir
                    RedirectToAction("Index");
                }
                kullaniciEkleDuzenleVM = new KullaniciEkleDuzenleVM
                {
                    Ad = kullanici.Adi,
                    Eposta = kullanici.Eposta,
                    Id = id,
                    Soyad = kullanici.Soyad,
                    RolIdler_chk = kullanici.kullaniciRolleri.Select(x => x.RolID).ToList(),
                };

            }
            kullaniciEkleDuzenleVM.TumRoller = await _rollerRepository.TumunuGetir();

            return View(kullaniciEkleDuzenleVM);
        }

        [HttpPost]
        public async Task<IActionResult> EkleDuzenle(KullaniciEkleDuzenleVM kullaniciEkleDuzenleVM)
        {
            kullaniciEkleDuzenleVM.TumRoller = await _rollerRepository.TumunuGetir();

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        if (kullaniciEkleDuzenleVM.Id == 0)
                        {
                            var mevcutKullanici = await _kullanicilarRepository.EpostaylaGetirInclude(kullaniciEkleDuzenleVM.Eposta);
                            if (mevcutKullanici != null)
                            {
                                scope.Dispose();
                                ViewBag.Mesaj = "Kullanıcı mevcut";
                                return View(kullaniciEkleDuzenleVM);
                            }
                            var eklenenKullanici = await _kullanicilarRepository.Ekle(new Kullanicilar
                            {
                                Adi = kullaniciEkleDuzenleVM.Ad,
                                Soyad = kullaniciEkleDuzenleVM.Soyad,
                                Eposta = kullaniciEkleDuzenleVM.Eposta,
                                EklemeTarihi = DateTime.Now,
                            });

                            List<KullaniciRolleri> kullaniciRoller = new List<KullaniciRolleri>();
                            DateTime eklemeTarih = DateTime.Now;
                            foreach (var rolId in kullaniciEkleDuzenleVM.RolIdler_chk)
                            {
                                kullaniciRoller.Add(new KullaniciRolleri { KullaniciID = eklenenKullanici.id, RolID = rolId, EklemeTarihi = eklemeTarih });
                            }
                            await _kullaniciRolleriRepository.TopluEkle(kullaniciRoller);

                            scope.Complete();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            var mevcutKullanici = await _kullanicilarRepository.GetirInclude(kullaniciEkleDuzenleVM.Id);
                            //kullanıcı yoksa hata mesajı dön  yapılmadı

                            if (mevcutKullanici == null)
                            {
                                scope.Dispose();
                                throw new Exception();
                            }
                            else
                            {
                                //güncelle
                                mevcutKullanici.Adi = kullaniciEkleDuzenleVM.Ad;
                                mevcutKullanici.Soyad = kullaniciEkleDuzenleVM.Soyad;
                                mevcutKullanici.Eposta = kullaniciEkleDuzenleVM.Eposta;

                                List<KullaniciRolleri> kullaniciRoller = new List<KullaniciRolleri>();
                                DateTime eklemeTarih = DateTime.Now;
                                foreach (var rolId in kullaniciEkleDuzenleVM.RolIdler_chk)
                                {
                                    kullaniciRoller.Add(new KullaniciRolleri { KullaniciID = mevcutKullanici.id, RolID = rolId, EklemeTarihi = eklemeTarih });
                                }
                                mevcutKullanici.kullaniciRolleri = kullaniciRoller;

                                await _kullanicilarRepository.Guncelle(mevcutKullanici);

                                //rolleri kontrol etme şimdilik yapılmadı


                                scope.Complete();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");

        }
    }
}