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
    public class AdminIndexController : Controller
    {
        // GET: AdminIndex
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adminler()
        {
            List<tbl_admin> admin = n.tbl_admin.ToList();
            return View(admin);
        }

        public ActionResult Kullanicilar()
        {
            List<tbl_kullanici> kullanici = n.tbl_kullanici.ToList();
            return View(kullanici);
        }

        public string KullaniciSil(int id)
        {
            tbl_kullanici t = n.tbl_kullanici.FirstOrDefault(x => x.kullanici_id == id);
            if (t != null)
            {
                n.tbl_kullanici.Remove(t);

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