using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FISWeb.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult CreateEmployee()
        {
            Models.CreateEmployeeModel model = new Models.CreateEmployeeModel();

            return View();
        }
    }
}