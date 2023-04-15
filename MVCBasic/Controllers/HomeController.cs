using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBasic.Controllers
{
    //[RoutePrefix("abc")]
    public class HomeController : Controller
    {
        // GET: Home
        // [Route("home")]
        [HttpGet]
        public ActionResult Welcome(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( string employeename)
        {
            ViewBag.Name = employeename;
            return View("~/Views/Home/Welcome.cshtml");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}