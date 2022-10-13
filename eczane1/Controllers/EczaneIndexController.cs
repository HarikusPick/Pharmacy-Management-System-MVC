using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eczane1.Models;
using eczane1.Security;

namespace eczane1.Controllers
{
    [MyAuthorization(Roles = "eczane,admin")]
    public class EczaneIndexController : Controller
    {
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        // GET: EczaneIndex
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Envanter()
        {
            string kAdi = HttpContext.User.Identity.Name.ToString();
            tbl_eczane Tid = n.tbl_eczane.FirstOrDefault(x=>x.eczane_nickname==kAdi);
            int id = Tid.eczane_id;
            TempData["ECID"] = id;
            ViewBag.ID = Convert.ToInt32(TempData["ID"]);
            List<tbl_eczane_ilac> EIID = n.tbl_eczane_ilac.Where(x=> x.eczane_id == id).ToList();
            TempData["EczaneID"] = id;
            return View(EIID);
        }

        public List<tbl_ilac_turu> GetTurListesi()
        {
            List<tbl_ilac_turu> turler = n.tbl_ilac_turu.ToList();
            return turler;
        }

        public ActionResult GetIlacList(int ilac_turu_id)
        {
            List<tbl_ilac> selectList = n.tbl_ilac.Where(x=>x.ilac_turu_id == ilac_turu_id).ToList();
            ViewBag.IlacList = new SelectList(selectList, "ilac_id", "ilac_ad");
            return PartialView("DisplayIlaclar");
        }

        public ActionResult Ekle() 
        {
            ViewBag.ID = Convert.ToInt32(TempData["EczaneID"]);
            ViewBag.TurListesi = new SelectList(GetTurListesi(), "ilac_turu_id", "ilac_turu_ad");
            
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(tbl_eczane_ilac t)
        {
            
            n.tbl_eczane_ilac.Add(t);
            n.SaveChanges();
            TempData["ID"] = TempData["ECID"];
            return RedirectToAction("Envanter");
        }

        public string sil(int id)
        {
            tbl_eczane_ilac t = n.tbl_eczane_ilac.FirstOrDefault(x => x.eczene_ilac_id == id);
            if (t != null)
            {
                n.tbl_eczane_ilac.Remove(t);
                TempData["ID"] = TempData["ECID"];
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