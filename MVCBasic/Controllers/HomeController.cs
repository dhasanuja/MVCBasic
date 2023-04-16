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
            //i have data from api,database
            //i want to transfer my data to view
            ViewBag.Name = "Anuja Dhas";
            ViewBag.Employees = new string[] { "aaa","bbbb","cccc" };

            return View();
        }

        [HttpGet]
        public ActionResult Index1()
        {
            ViewData["Name"] = "Anuja Dhas";
            ViewData["Employees"] = new string[] { "aaa", "bbbb", "cccc" };

            return View();
        }
        [HttpGet]
        public ActionResult Index2()
        {
            TempData["Name"] = "Anuja Dhas";
            TempData["Employees"] = new string[] { "aaa", "bbbb", "cccc" };
            return View();
        }

        [HttpGet]
        public ActionResult Index3()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RazorDemo() 
        {
            return View();

        }
    }
}