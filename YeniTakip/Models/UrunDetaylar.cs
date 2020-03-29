using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YeniTakip.Models
{
    public class UrunDetaylar
    {
        public string UrunKodu { get; set; }
        public int? UrunBoyutu { get; set; } 
      
        public string HareketTurAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string DepoAdi { get; set; }

        public string TedarikciAdi { get; set; }
        public int? UrunAdeti { get; set; }
        public int? HareketTurID { get; set; }
        public int? KullaniciID { get; set; }
        public int? TedarikciID { get; set; }
         
        public int? RafID { get; set; }

        public DateTime? Tarih { get; set; }
        public int? DepoID { get; set; }

    }



}