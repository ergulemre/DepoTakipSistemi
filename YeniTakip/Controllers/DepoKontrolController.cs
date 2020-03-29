using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniTakip.HelpDesk;
using YeniTakip.Models;
namespace YeniTakip.Controllers
{
    public class DepoKontrolController : Controller
    {
        // GET: DepoKontrol
        public ActionResult Kontrol()
        {
            Helper h = new Helper();
            
            STEmreDBEntities3 db = new STEmreDBEntities3();

            List<Depolar> depos = db.Depolar.ToList();
            List<DepoDetaylari> depodetay = new List<DepoDetaylari>();
            List<Raflar> rafs = db.Raflar.ToList();
            List<RafDetaylari> rafdetay = new List<RafDetaylari>();

            foreach (var item in depos)
            {
                DepoDetaylari dpdt = new DepoDetaylari();
                dpdt.DepoAdi = item.DepoAdi;
                dpdt.ToplamAlan= h.DepoAlanGetir(item.DepoID) ?? 0;
                dpdt.KapladigiAlan = h.KapladigiAlan(item.DepoID) ?? 0;
                dpdt.KalanAlan = dpdt.ToplamAlan - dpdt.KapladigiAlan;
                depodetay.Add(dpdt);
            }

            ViewBag.depodetaylari = depodetay;

            
            //using (db)
            //{
            //    List<RafDetaylari> rafbilgiler = db.Database.SqlQuery<RafDetaylari>(
            //           "SELECT DepoID, KapladigiAlan, Count(KapladigiAlan) as Adeti FROM Raflar GROUP BY KapladigiAlan,DepoID").ToList();

            //ViewBag.rafcantam = rafbilgiler;
            //}



            foreach (var rafitem in rafs)
            {
                RafDetaylari rfdt = new RafDetaylari();
                rfdt.DepoAdi = rafitem.Depolar.DepoAdi;
                rfdt.Raftoplamalan = h.RafAlan(rafitem.RafID) ?? 0;
                rfdt.Rafkaplananalan = h.UrunBoyut(rafitem.RafID) ?? 0;
                rfdt.Rafkalanalan = (rfdt.Raftoplamalan - rfdt.Rafkaplananalan);
                rafdetay.Add(rfdt);
            }

            ViewBag.rafdetaylari = rafdetay;





            return View();
        }
    }
}