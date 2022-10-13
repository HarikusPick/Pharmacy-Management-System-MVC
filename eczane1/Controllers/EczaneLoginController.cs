using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eczane1.Models;
using System.Web.Security;
using eczane1.Security;

namespace eczane1.Controllers
{
    [AllowAnonymous]
    public class EczaneLoginController : Controller
    {

        // GET: EczaneLogin
        [AllowAnonymous]
        public ActionResult Index()
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            ViewBag.IlListe = new SelectList(GetTbl_ilList(), "il_id", "il_ad");
            return View(); 
        }

        [HttpPost]
        
        public ActionResult Index(tbl_eczane k)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            tbl_eczane eczane = n.tbl_eczane.FirstOrDefault(x=>x.eczane_nickname==k.eczane_nickname && x.eczane_password==k.eczane_password);
            if (eczane != null)
            {
                FormsAuthentication.SetAuthCookie(eczane.eczane_nickname,false);
                TempData["ID"] = eczane.eczane_id;
                return RedirectToAction("Envanter", "EczaneIndex" );
            }
            else
            {
                ViewBag.mesaj = "kullanıcı adı veya şifre hatalı";
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            string name = FormsAuthentication.FormsCookieName;
            HttpCookie authcookie = HttpContext.Request.Cookies[name];
            FormsAuthenticationTicket t = FormsAuthentication.Decrypt(authcookie.Value);
            string tnickname = t.Name;

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public List<tbl_il> GetTbl_ilList()
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            List<tbl_il> iller = n.tbl_il.ToList();
            return iller;
        }
        public ActionResult GetIlceList(int il_id)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            List<tbl_ilce> selectList = n.tbl_ilce.Where(x=>x. il_id == il_id).ToList();
            ViewBag.ilceList = new SelectList(selectList, "ilce_id", "ilce_ad");
            return PartialView("DisplayIlceler");
        }
        public ActionResult GetSemtList(int ilce_id)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            List<tbl_semt> selectList = n.tbl_semt.Where(x=>x. ilce_id == ilce_id).ToList();
            ViewBag.semtList = new SelectList(selectList, "semt_id", "semt_ad");
            return PartialView("DisplaySemtler");
        }
        public ActionResult GetMahalleList(int semt_id)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            List<tbl_mahalle> selectList = n.tbl_mahalle.Where(x=>x. semt_id == semt_id).ToList();
            ViewBag.mahalleList = new SelectList(selectList, "mahalle_id", "mahalle_ad");
            return PartialView("DisplayMahalleler");
        }
        
        [HttpPost]
        public JsonResult checkUsername(string username)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            bool result = !n.tbl_eczane.ToList().Exists(model => model.eczane_nickname.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            return Json(result);
        }
        public ActionResult Ekle()
        {
            tbl_eczane t = new tbl_eczane();
            return View(t);
        }
        [HttpPost]
        public ActionResult Ekle(tbl_eczane t)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            tbl_eczane kul = n.tbl_eczane.FirstOrDefault(x=> x.eczane_ad == t.eczane_ad);
            if (kul == null)
            {
                n.tbl_eczane.Add(t);
            }
                
            else //update
            {
                kul.eczane_nickname = t.eczane_nickname;
                kul.eczane_password = t.eczane_password;
                kul.eczane_ad = t.eczane_ad;
                kul.mahalle_id = t.mahalle_id;
                kul.eczane_tescil = t.eczane_tescil;
                kul.eczane_telefon = t.eczane_telefon;
                kul.rol_id = t.rol_id;
            }
            n.SaveChanges();
            return RedirectToAction("index");
        }

        
    }
}






       


