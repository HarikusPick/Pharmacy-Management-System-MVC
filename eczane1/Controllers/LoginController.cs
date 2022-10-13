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
    public class LoginController : Controller
    { 
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {return View();}

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(tbl_kullanici k)
        {
           
            tbl_kullanici kullanici = n.tbl_kullanici.FirstOrDefault(x=>x.kullanici_nickname==k.kullanici_nickname && x.kullanici_password==k.kullanici_password);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.kullanici_nickname, false);
                return RedirectToAction("Index", "Kullanicilar");
            }
            else
            {
                ViewBag.mesaj = "kullanıcı adı veya şifre hatalı";
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Ekle()
        {
            tbl_kullanici t = new tbl_kullanici();
            return View(t);
        }

        [AllowAnonymous]
        public JsonResult checkUsername(string username)
        {
            bool result = !n.tbl_kullanici.ToList().Exists(model => model.kullanici_nickname.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Ekle(tbl_kullanici t)
        {
            tbl_kullanici kul = n.tbl_kullanici.FirstOrDefault(x=> x.kullanici_ad == t.kullanici_ad);
            if (kul == null)
                n.tbl_kullanici.Add(t);
            else //update
            {
                kul.kullanici_nickname = t.kullanici_nickname;
                kul.kullanici_password = t.kullanici_password;
                kul.kullanici_ad = t.kullanici_ad;
                kul.kullanici_soyad = t.kullanici_soyad;
                kul.kullanici_telefon = t.kullanici_telefon;
                kul.rol_id = t.rol_id;
            }
            n.SaveChanges();
            return RedirectToAction("index");
        }

        [AllowAnonymous]
        public ActionResult Hata()
        {
            return View();
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

    }
}