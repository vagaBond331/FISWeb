using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FISWeb.Models;

namespace FISWeb.Controllers
{
    public class AdminController : Controller
    {
        private FISEntities db = new FISEntities();

        // GET: Admin
        public ActionResult Index(String user_id)
        {
            AdminViewModels model = new AdminViewModels();
            model.logUser = db.Users.Find(user_id);
            foreach (var item in db.Users)
            {
                if(item.user_type != 1)
                {
                    model.empListName.Add(item.first_name + " " + item.last_name);
                    model.monthAttend.Add(checkAttend(item, DateTime.Now.Month));
                }
            }
            model.listDevice = db.Devices.ToList();

            return View(model);
        }

        public string[] checkAttend(User us, int month)
        {
            //listMonth is attend of user for a month (31 days)
            //1st == listMonth[1]
            string[] listMonth = new string[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + 1];

            List<Attent> list = db.Attents.ToList();

            //just keep log for this user
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].attent_user.Equals(us.user_id))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            //save to bool[] 
            for (int i = 0; i < list.Count; i++)
            {
                int day = list[i].attent_time.Day;
                if(month == list[i].attent_time.Month)
                {
                    listMonth[day] = "v";
                }
            }
            return listMonth;
        }
    }
}