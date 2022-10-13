using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eczane1.Models;

namespace eczane1.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detay()
        {
            
            ViewBag.ID = Convert.ToInt32(TempData["ID"]);
            
            ViewBag.AD = TempData["AD"];
            
            ViewBag.TELEFON = Convert.ToInt32(TempData["TELEFON"]);
            
            ViewBag.TESCIL = Convert.ToInt32(TempData["TESCIL"]);



            return View();
        }
    }
}