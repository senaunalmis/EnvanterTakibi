﻿ using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class DonanimMarkalari
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public ICollection<Donanimlar> donanimlar { get; }=new List<Donanimlar>();
        public ICollection<UstModeller> ustModeller { get; } = new List<UstModeller>();
        public ICollection<DonanimMarkaTurleri> donanimMarkaTurleri { get; set; }
    }
}
