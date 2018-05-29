using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Answers"] != null)
                Session.Clear();
            return View();
        }

        public ActionResult Advisor()
        {
            return View();
        }

    }
}