using EnvanterUygulaması.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnvanterUygulaması.ViewModels
{
    public class KullaniciEkleDuzenleVM
    {
        public KullaniciEkleDuzenleVM() 
        {
            TumRoller = new List<Roller>();
            RolIdler_chk =new List<int>();
        }

        public int Id { get; set; }
        public string Eposta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public List<Roller> TumRoller { get; set; }

        [BindProperty]
        public List<int> RolIdler_chk { get; set; }
    }
}
