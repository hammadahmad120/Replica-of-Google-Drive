using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Drive.DAO;

namespace Assignment8.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult UserHome()
        {
            if (Session["user"] == null)
                return Redirect("~/User/Login");
            return View();
        }
       

    }
}
