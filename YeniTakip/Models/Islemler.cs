using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YeniTakip.Models
{
    public class Islemler
    {
        public string UrunKodu { get; set; }
        public int? DepoID { get; set; }
        public DateTime? BaslangicTarihi { get; set; }

        public DateTime? BitisTarihi { get; set; }

    }
}