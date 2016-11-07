using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FISWeb.Models
{
    public class AdminViewModels
    {
        public User logUser { get; set; }
        public List<string> empListName { get; set; }
        public List<string[]> monthAttend { get; set; }
        public int numDays { get; set; }
        public List<Device> listDevice { get; set; }
        public AdminViewModels()
        {
            logUser = new User();
            empListName = new List<string>();
            monthAttend = new List<string[]>();
            numDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            listDevice = new List<Device>();
        }
    }
}
