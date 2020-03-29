using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YeniTakip.Models;

namespace YeniTakip.HelpDesk
{       
    public class Helper
    {
        
        STEmreDBEntities3 db;
        static string mesaj = "";
        public Helper()
        {
            db = new STEmreDBEntities3();
        }
        public int? DepoAlanGetir(int? id)
        {
            List<Raflar> liste = db.Raflar.Where(x => x.DepoID == id).ToList();
            int? toplam = 0;
            liste.ForEach(x => toplam += x.KapladigiAlan);
            return toplam;
        }

        public int? KapladigiAlan(int? ids)
        {

            List<KaplananAlanDepo_Result> listem = db.KaplananAlanDepo(ids).ToList();
            return listem[0].KaplananAlan;
        }
        public int? RafAlan(int id)
        {
            List<Raflar> rafliste = db.Raflar.Where(x => x.RafID == id).ToList();
            int? toplamalan = 0;
            rafliste.ForEach(x => toplamalan += x.KapladigiAlan);
            return toplamalan;
        }
        public int? UrunBoyut(int id)
        {
            List<Urunler> urunliste = db.Urunler.Where(x => x.RafID == id).ToList();
            int? kapladigiboyut = 0;
            urunliste.ForEach(x => kapladigiboyut += (x.UrunBoyutu*x.UrunAdeti));
            return kapladigiboyut;
        }

        public string GirisKontrol(UrunDetaylar ud)
        {
            string mesaj = "";
            Urunler urun = db.Urunler.Where(x => x.UrunKodu == ud.UrunKodu).FirstOrDefault();
            UrunHareket urunhareket = new UrunHareket();
            int? alan = DepoAlanGetir(ud.DepoID);
            int? alan1 = KapladigiAlan(ud.DepoID);

            int? sonuc = alan - alan1;

            if (urun.UrunBoyutu * ud.UrunAdeti <= sonuc)
            {
                urunhareket.DepoID = ud.DepoID;
                urunhareket.HareketTurID = ud.HareketTurID;
                urunhareket.KullaniciID = ud.KullaniciID;
                urunhareket.TedarikciID = ud.TedarikciID;
                urunhareket.UrunAdeti = ud.UrunAdeti;
                urunhareket.Tarih = ud.Tarih;
                urunhareket.UrunID = urun.UrunID;

                db.UrunHareket.Add(urunhareket);
                db.SaveChanges();

                urun.UrunAdeti += ud.UrunAdeti;
                db.SaveChanges();
                mesaj = "Kayıt Başarılı";

            }
            else
            {
                mesaj = "Yetersiz Alan .";
            }
            return mesaj;
        }

        public string CikisKontrol(UrunDetaylar ud)
        {
            var mesaj = "";
            UrunHareket urunhareket = new UrunHareket();
            Urunler urun = db.Urunler.Where(x => x.UrunKodu == ud.UrunKodu).FirstOrDefault();
            List<GetUrunMevcutListe_Result> mevcut = db.GetUrunMevcutListe(ud.UrunKodu, ud.DepoID).ToList();
            if (mevcut[0]?.Kalan >= ud.UrunAdeti)
            {
                urunhareket.DepoID = ud.DepoID;
                urunhareket.HareketTurID = ud.HareketTurID;
                urunhareket.KullaniciID = ud.KullaniciID;
                urunhareket.TedarikciID = ud.TedarikciID;
                urunhareket.UrunAdeti = ud.UrunAdeti;
                urunhareket.Tarih = ud.Tarih;
                urunhareket.UrunID = urun.UrunID;

                db.UrunHareket.Add(urunhareket);
                db.SaveChanges();

                urun.UrunAdeti -= ud.UrunAdeti;
                db.SaveChanges();
                mesaj = "Kayıt Başarılı";
            }
            else
            {
                mesaj = "Depoda belirtilen miktarda ürün yoktur !";
            }
            
            return mesaj;
        }
    }
}