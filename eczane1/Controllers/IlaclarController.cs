using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eczane1.Models;
using eczane1.Security;
using System.Web.Security;

namespace eczane1.Controllers
{
    [MyAuthorization (Roles ="eczane,admin,kullanici")]
    public class IlaclarController : Controller
    {

        // GET: Ilaclar
        
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        [HttpGet]
        public ActionResult Index()
        {
            List<tbl_ilac> ilac = n.tbl_ilac.ToList();
            return View(ilac);
        }

        public ActionResult Ekle()  //yeni ekleme
        {
            tbl_ilac t = new tbl_ilac();
            return View(t);
        }
       
        [HttpPost]
        public ActionResult Ekle(tbl_ilac t)
        {
            tbl_ilac ted = n.tbl_ilac.FirstOrDefault(x=> x.ilac_id == t.ilac_id);
            if (ted == null)
                n.tbl_ilac.Add(t);
            else //update
            {
                ted.ilac_ad = t.ilac_ad;
                ted.ilac_kod = t.ilac_kod;
                ted.ilac_fiyat = t.ilac_fiyat;
                ted.ilac_skt = t.ilac_skt;
                ted.ilac_turu_id = t.ilac_turu_id;

                //turu de ekliycez
            }
            n.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Guncelle(int id)
        {
            tbl_ilac nesne = n.tbl_ilac.FirstOrDefault(x=>x.ilac_id == id);
            return View("Ekle", nesne);
        }


        public string sil(int id)
        {
            tbl_ilac t = n.tbl_ilac.FirstOrDefault(x => x.ilac_id == id);
            if (t != null)
            {
                n.tbl_ilac.Remove(t);

                try
                {
                    n.SaveChanges();
                    return "başarılı";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }


            }
            return "başarısız";
        }





        public ActionResult Turler()
        {
            List<tbl_ilac_turu> ilacTuru = n.tbl_ilac_turu.ToList();
            return View(ilacTuru);
        }
        public ActionResult TurEkle()  //yeni ekleme
        {
            tbl_ilac_turu tr = new tbl_ilac_turu();
            return View(tr);
        }
        [HttpPost]
        public ActionResult TurEkle(tbl_ilac_turu tr)
        {
            tbl_ilac_turu tedr = n.tbl_ilac_turu.FirstOrDefault(x=> x.ilac_turu_id == tr.ilac_turu_id);
            if (tedr == null)
                n.tbl_ilac_turu.Add(tr);
            else //update
            {
                tedr.ilac_turu_ad = tr.ilac_turu_ad;
            }
            n.SaveChanges();
            return RedirectToAction("Turler");
        }

        public ActionResult TurGuncelle(int id)
        {
            tbl_ilac_turu nesner = n.tbl_ilac_turu.FirstOrDefault(x=>x.ilac_turu_id == id);
            return View("TurEkle", nesner);
        }





        public string Tursil(int id)
        {
            tbl_ilac_turu t = n.tbl_ilac_turu.FirstOrDefault(x => x.ilac_turu_id == id);
            if (t != null)
            {
                n.tbl_ilac_turu.Remove(t);

                try
                {
                    n.SaveChanges();
                    return "başarılı";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }


            }
            return "başarısız";
        }




    }
}