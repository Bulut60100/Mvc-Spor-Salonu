using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spor_Salonu.Models;

namespace Spor_Salonu.Controllers
{
    public class kullaniciController : Controller
    {
        // GET: kullanici
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult hakkimizda()
        {
            return View();
        }

    }
}