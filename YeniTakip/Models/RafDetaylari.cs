using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YeniTakip.Models
{
    public class RafDetaylari
    {
        public string DepoAdi { get; set; }
        public int Raftoplamalan { get; set; }
        public int Rafkaplananalan { get; set; }

        public int Rafkalanalan { get; set; }
    }
}