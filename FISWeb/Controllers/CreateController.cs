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

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in listPos)
            {
                switch (item.pos_type)
                {
                    case 1:
                        listItems.Add(new SelectListItem { Text = item.pos_displayed + " (Admin role)", Value = item.pos_id });
                        break;
                    case 2:
                        listItems.Add(new SelectListItem { Text = item.pos_displayed + " (Manager role)", Value = item.pos_id });
                        break;
                    case 3:
                        listItems.Add(new SelectListItem { Text = item.pos_displayed + " (Employee role)", Value = item.pos_id });
                        break;
                    default: break;
                }
            }

            ViewBag.PosList = listItems;
            return View();
        }

        public ActionResult AddNewEmp(CreateEmployeeModel model)
        {
            Position pos = db.Positions.Find(model.posID);
            List<User> listUser = db.Users.Where(o => o.user_type == pos.pos_type).ToList();
            int newID = int.Parse(listUser.Last().user_id.Substring(2)) + 1;
            User newUser = new User();
            switch (pos.pos_type)
            {
                case 1:
                    newUser.user_id = "AD" + newID;
                    break;
                case 2:
                    newUser.user_id = "MN" + newID;
                    break;
                case 3:
                    newUser.user_id = "EM" + newID;
                    break;
            }
            newUser.username = model.username;
            newUser.password = model.password;
            newUser.status = 1;
            newUser.user_type = pos.pos_type;
            newUser.first_name = model.first_name;
            newUser.last_name = model.last_name;
            newUser.mail = model.Email;
            newUser.DOB = model.DOB;
            newUser.address = model.address;
            newUser.pos_id = pos.pos_id;
            newUser.department = model.department;
            newUser.phone = model.phone;

            db.Users.Add(newUser);
            db.SaveChanges();
            return View();
        }
    }
}