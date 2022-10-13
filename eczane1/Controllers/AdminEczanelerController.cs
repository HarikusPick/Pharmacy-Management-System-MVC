using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eczane1.Models;
using eczane1.Security;

namespace eczane1.Controllers
{
    [MyAuthorization(Roles = "admin")]
    public class AdminEczanelerController : Controller
    {
        // GET: AdminEczaneler
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        [HttpGet]
        public ActionResult Index()
        {
            List<tbl_eczane> eczane = n.tbl_eczane.ToList();
            return View(eczane);
        }

        [HttpPost]
        public ActionResult Ekle(tbl_eczane t)
        {
            tbl_eczane ted = n.tbl_eczane.FirstOrDefault(x=> x.eczane_id == t.eczane_id);
            if (ted == null)
                n.tbl_eczane.Add(t);
            else
            {
                ted.eczane_ad = t.eczane_ad;
                ted.eczane_password = t.eczane_password;
                ted.eczane_telefon = t.eczane_telefon;
            }
            n.SaveChanges();
            return RedirectToAction("index");
        }
        
        public ActionResult Guncelle(int id)
        {
            tbl_eczane nesne = n.tbl_eczane.FirstOrDefault(x=>x.eczane_id == id);
            return View("Ekle", nesne);
        }

        public ActionResult Goster(int id)
        {
            List<tbl_eczane_ilac> EIID = n.tbl_eczane_ilac.Where(x=> x.eczane_id == id).ToList();
            return View(EIID);
        }

        [HttpPost]
        public string sil(int id)
        {
            tbl_eczane_ilac t = n.tbl_eczane_ilac.FirstOrDefault(x => x.eczene_ilac_id == id);
            if (t != null)
            {
                n.tbl_eczane_ilac.Remove(t);
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



        //public string sil2(int id)
        //{
        //    tbl_eczane t = n.tbl_eczane.FirstOrDefault(x => x.eczane_id == id);
        //    if (t != null)
        //    {
        //        n.tbl_eczane.Remove(t);

        //        try
        //        {
        //            n.SaveChanges();
        //            return "başarılı";
        //        }
        //        catch (Exception e)
        //        {
        //            return e.ToString();
        //        }


        //    }
        //    return "başarısız";
        //}













    }
}
