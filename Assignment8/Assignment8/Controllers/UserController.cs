using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Drive.DAO;

namespace Assignment8.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String login, String password)
        {
            if (login == "" || password == "")
            {
                ViewBag.MSG = "Invalid Login/Password";
                ViewBag.Login = login;
                return View();
            }
            var test = UserDAO.UserLogin(login, password);
            if (test == true)
            {
                User obj = UserDAO.getUserByLogin(login);
                Session["user"] = obj;
                Session["uid"] = obj.id;
                Session["pfid"] = 0;
                
                return Redirect("~/Home/UserHome");
            }

            ViewBag.MSG = "Invalid Login/Password";
            ViewBag.Login = login;

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            ModelState.Clear();
            return RedirectToAction("Login");
        }

    }
}
