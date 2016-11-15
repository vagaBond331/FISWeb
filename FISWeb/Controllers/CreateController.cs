﻿using FISWeb.Models;
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

        public ActionResult CreateEmployee()
        {
            User logUser = db.Users.Find(Session["logUserID"]);

            List<Position> listPos = db.Positions.ToList();
            listPos = listPos.OrderBy(o => o.pos_type).ToList();

            if (logUser.user_type == 2)
            {
                listPos = listPos.Where(o => o.pos_type == 3).ToList();
            }

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

        public ActionResult CreateDevice()
        {
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

            string username = RemoveVietnamese(model.full_name.ToLower());

            string[] name = username.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < name.Count() - 1; i++)
            {
                name[name.Count() - 1] += name[i].First();
            }
            string namei = name[name.Count() - 1];
            int c = db.Users.Where(u => u.username.Contains(namei)).ToList().Count();
            newUser.username = (c == 0) ? namei : namei + c;

            //default passwork
            newUser.password = Constants.defaultPassword;

            newUser.status = 1;
            newUser.user_type = pos.pos_type;
            newUser.full_name = model.full_name;
            newUser.mail = model.Email;
            newUser.DOB = model.DOB;
            newUser.address = model.address;
            newUser.pos_id = pos.pos_id;
            newUser.department = model.department;
            newUser.phone = model.phone;

            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddNewDevice(CreateDeviceModel model)
        {
            Device newDevice = new Device();

            List<Device> listDevice = db.Devices.ToList();
            int newID = int.Parse(listDevice.Last().device_id.Substring(1)) + 1;

            newDevice.device_id = "P" + newID;
            newDevice.device_name = model.device_name;
            newDevice.description = model.description;
            newDevice.device_status = 2;

            db.Devices.Add(newDevice);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public static string RemoveVietnamese(string str)
        {
            for (int i = 1; i < Constants.VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < Constants.VietnameseSigns[i].Length; j++)
                    str = str.Replace(Constants.VietnameseSigns[i][j], Constants.VietnameseSigns[0][i - 1]);
            }
            return str;
        }
    }
}