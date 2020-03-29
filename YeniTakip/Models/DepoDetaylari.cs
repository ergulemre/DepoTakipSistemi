using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YeniTakip.Models
{
    public class DepoDetaylari
    {
        public string DepoAdi { get; set; }

        public int ToplamAlan { get; set; }
        public int KapladigiAlan { get; set; }

        public int KalanAlan { get; set; }
    }
}