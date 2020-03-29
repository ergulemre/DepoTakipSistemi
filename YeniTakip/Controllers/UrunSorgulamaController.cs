using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YeniTakip.Controllers
{
    public class UrunSorgulamaController : Controller
    {
        // GET: UrunSorgulama
        public ActionResult Sorgula()

        {
            STEmreDBEntities3 db = new STEmreDBEntities3();            
            List<Depolar> adlar = db.Depolar.ToList();
            ViewBag.cantam = adlar;
            return View(new List<GetUrunMevcutListe_Result>());
        }
        [HttpPost]
        public ActionResult Sorgula(string searching)
        {
            STEmreDBEntities3 db = new STEmreDBEntities3();

            var urunler = new List<GetUrunMevcutListe_Result>();
            var depoid = new List<Depolar>();

            if (!String.IsNullOrEmpty(searching))
            {
                urunler = db.GetUrunMevcutListe(searching,null).ToList<GetUrunMevcutListe_Result>();
            }
            List<Depolar> adlar = db.Depolar.ToList();
            ViewBag.cantam = adlar;
            return View(urunler);
        }
        [HttpPost]
        public ActionResult DepoyaGoreSorgula(string depo)
        {
            STEmreDBEntities3 db = new STEmreDBEntities3();
            int? arama = Convert.ToInt32(depo);
            var uruns = new List<GetUrunMevcutListe_Result>();
            uruns = db.GetUrunMevcutListe(null, arama).ToList<GetUrunMevcutListe_Result>();
            ViewBag.canta = uruns;
            List<Depolar> adlar = db.Depolar.ToList();
            ViewBag.cantam = adlar;
            return View("Sorgula");
        }
      
    }
}