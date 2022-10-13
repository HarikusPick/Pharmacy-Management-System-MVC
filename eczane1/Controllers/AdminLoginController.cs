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
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(tbl_admin k)
        {
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            tbl_admin admin = n.tbl_admin.FirstOrDefault(x=>x.admin_nickname==k.admin_nickname && x.admin_password==k.admin_password);
            List<tbl_eczane> eczaneList = n.tbl_eczane.ToList();
            ViewBag.eczaneList = eczaneList;
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.admin_nickname, false);
                return RedirectToAction("Index", "AdminIndex");
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

    }
}