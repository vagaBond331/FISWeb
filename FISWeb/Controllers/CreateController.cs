using FISWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FISWeb.Controllers
{
    public class CreateController : Controller
    {
        private FISEntities db = new FISEntities();
        // GET: Create
        public ActionResult CreateEmployee()
        {
            List<Position> listPos = db.Positions.ToList();
            listPos = listPos.OrderBy(o => o.pos_type).ToList();
            List<string> list = new List<string>();
            foreach (var item in listPos)
            {
                switch (item.pos_type)
                {
                    case 1:
                        list.Add(item.pos_displayed + " (Admin role)");
                        break;
                    case 2:
                        list.Add(item.pos_displayed + " (Manager role)");
                        break;
                    case 3:
                        list.Add(item.pos_displayed + " (Employee role)");
                        break;
                    default: break;
                }
            }
            ViewBag.PosList = new SelectList(list);
            return View();
        }
    }
}