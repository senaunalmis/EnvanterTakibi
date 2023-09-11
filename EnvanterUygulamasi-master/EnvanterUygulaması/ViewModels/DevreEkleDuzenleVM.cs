﻿using EnvanterUygulaması.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnvanterUygulaması.ViewModels
{
    public class DevreEkleDüzenleVM
    {
        public DevreEkleDüzenleVM()
        {
            BulutList = new List<Liste>();
            BolgeList = new List<Liste>();
        }
        public int id { get; set; }
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public int BolgeId { get; set; }
        public int DevreNo { get; set; }
        public string BulutAdi { get; set; }
        public int BulutNo { get; set; }
        public int BulutId { get; set; }
        public string AnaDevreNo { get; set; }
        public string IpBlogu { get; set; }
        public string Durum { get; set; }
        public string Koordinat { get; set; }
        public bool Mahsup { get; set; }
        public List<Liste> BulutList { get; set; }
        public List<Liste> BolgeList { get; set; }

    }
}
