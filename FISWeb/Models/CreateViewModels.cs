using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace FISWeb.Models
{
    public class CreateEmployeeModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<byte> Usertype { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Address { get; set; }
        public string PosID { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
    }
}
