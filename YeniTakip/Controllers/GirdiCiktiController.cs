using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniTakip.HelpDesk;
using YeniTakip.Models;

namespace YeniTakip.Controllers
{
    public class GirdiCiktiController : Controller
    {
        // GET: GirdiCikti
        static string mesaj = "";
        static string mesaj2 = "";
        static string mesaj3 = "";
        public ActionResult UrunEklemeCikarma()
        {   
            STEmreDBEntities3 db = new STEmreDBEntities3();
            //List<Kullanici> kullanicilar = db.Kullanici.ToList();
            //ViewBag.kullanicibilgileri = kullanicilar;

            //List<HareketTur> adlar = db.HareketTur.ToList();
            //ViewBag.hareketbilgileri = adlar;

            //List<Depolar> depoid = db.Depolar.ToList();
            //ViewBag.depoidleri = depoid;

            //List<Tedarikci> tedarikciler = db.Tedarikci.ToList();
            //ViewBag.tedarikcibilgileri = tedarikciler;

            // List<Raflar> rafIdler = db.Raflar.ToList();
            //ViewBag.rafbilgileri = rafIdler;


            //var urunkodu = new List<Urunler>();

            

            //ViewBag.durum = mesaj;
            //ViewBag.durum2 = mesaj2;
            //ViewBag.durum3 = mesaj3;

            return View();
        }

        //[HttpPost]
        //public ActionResult Kaydet()
        //{
            //STEmreDBEntities3 db = new STEmreDBEntities3();
            //UrunHareket urunhareket = new UrunHareket();
            //Urunler urun = db.Urunler.Where(x => x.UrunKodu == ud.UrunKodu).FirstOrDefault();
            //List<GetUrunMevcutListe_Result> mevcut = db.GetUrunMevcutListe(ud.UrunKodu, ud.DepoID).ToList();
            //Helper h = new Helper();
            //if (urun != null)
            //{
            //    if (ud.HareketTurID == 36)
            //    {
            //        mesaj3 = h.GirisKontrol(ud);
            //    }
            //    else if(ud.HareketTurID == 35)
            //    {
            //        mesaj3 = h.CikisKontrol(ud);
            //    }
            //}
            //else
            //{
            //    mesaj = "Ürün Kaydı Bulunamadı !";
            //}

            //ViewBag.urunss = urun;

            //return RedirectToAction("UrunEklemeCikarma");
        //}

        /*[HttpPost]
        public JsonResult UrunGetir()
        {
            //STEmreDBEntities3 db = new STEmreDBEntities3();
            //db.Configuration.LazyLoadingEnabled = false;
            //Urunler urun = db.Urunler.Where(x => x.UrunKodu == UrunKod).FirstOrDefault();
            //if(urun == null)
            //{
            //    urun = new Urunler();
            }
            return Json();
        }*/
    }
}

