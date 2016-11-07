using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FISWeb.Models;

namespace FISWeb.Controllers
{
    public class UsersController : Controller
    {
        private FISEntities db = new FISEntities();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckLogin(LoginUser logUser)
        {
            List<User> list = db.Users.ToList();

            Boolean ck = false;
            User us = new User();

            foreach (var item in list)
            {
                if(item.username.Equals(logUser.Username) && item.password.Equals(logUser.Password))
                {
                    ck = true;
                    us = item;
                    break;
                }
            }

            if (ck == false) return RedirectToAction("Login", "Users");
            else
            {
                Session["logUserID"] = us.user_id;
                Session["logUserName"] = us.first_name + " " + us.last_name;
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult Logout()
        {
            Session["logUserID"] = "";
            Session["logUserName"] = "";
            return RedirectToAction("Login", "Users");
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
    }
}
