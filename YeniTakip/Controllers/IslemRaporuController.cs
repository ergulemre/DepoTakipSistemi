using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniTakip.Models;
namespace YeniTakip.Controllers
{
    public class IslemRaporuController : Controller
    {
        public ActionResult Rapor()
        {
            Islemler islems = new Islemler();
            STEmreDBEntities3 db = new STEmreDBEntities3();
            List<Depolar> depoids = db.Depolar.ToList();
            ViewBag.depoidleri = depoids;
            return View(islems);

        }

        // GET: İslemRaporu
        [HttpPost]
        public ActionResult Rapor(Islemler islems)
        {
        //    DateTime time = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //    if (islems.BaslangicTarihi == time)
        //    {
        //        islems.BaslangicTarihi = null;
        //    }

            STEmreDBEntities3 db = new STEmreDBEntities3();

            var urunler = new List<GetIslemRaporu_Result>();

            if (!String.IsNullOrEmpty(islems.UrunKodu))
            {
                urunler = db.GetIslemRaporu(islems.DepoID, islems.UrunKodu, islems.BaslangicTarihi, islems.BitisTarihi).ToList<GetIslemRaporu_Result>();
            }
            ViewBag.sonuc = urunler;
          
            List<Depolar> depoids = db.Depolar.ToList();
            ViewBag.depoidleri = depoids;
            return View(new Islemler());

        }
    }
}