using KursachV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kursach.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpGet]
        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
