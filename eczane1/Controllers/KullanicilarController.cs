using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eczane1.Models;

namespace eczane1.Controllers
{
    [AllowAnonymous]
    public class KullanicilarController : Controller
    {
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        // GET: Kullanicilar
        public ActionResult Index()
        {
            ViewBag.IlListe = new SelectList(GetTbl_ilList(), "il_id", "il_ad");
            return View();
        }

        public List<tbl_il> GetTbl_ilList()
        {
            List<tbl_il> iller = n.tbl_il.ToList();
            return iller;
        }
        public ActionResult GetIlceList(int il_id)
        {
            List<tbl_ilce> selectList = n.tbl_ilce.Where(x=>x.il_id == il_id).ToList();
            ViewBag.ilceList = new SelectList(selectList, "ilce_id", "ilce_ad");
            return PartialView("DisplayIlceler");
        }
        public ActionResult GetSemtList(int ilce_id)
        {
            List<tbl_semt> selectList = n.tbl_semt.Where(x=>x.ilce_id == ilce_id).ToList();
            ViewBag.semtList = new SelectList(selectList, "semt_id", "semt_ad");
            return PartialView("DisplaySemtler");
        }
        public ActionResult GetMahalleList(int semt_id)
        {
            List<tbl_mahalle> selectList = n.tbl_mahalle.Where(x=>x.semt_id == semt_id).ToList();
            ViewBag.mahalleList = new SelectList(selectList, "mahalle_id", "mahalle_ad");
            return PartialView("DisplayMahalleler");
        }

        public ActionResult AdreseGoreEczane(int mahalle_id)
        {
            List<tbl_eczane> selecList = n.tbl_eczane.Where(x=>x.mahalle_id == mahalle_id).ToList();
            ViewBag.eczaneList = selecList;
            return PartialView("DisplayEczaneler");
        }


    }
}


