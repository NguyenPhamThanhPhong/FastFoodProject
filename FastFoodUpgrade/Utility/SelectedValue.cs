using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Utility
{
    public class SelectedValue
    {
        public static Staff LoggedinStaff { get; set; }
        public static Staff CreateAdmin()
        {
            return new Staff() { Fullname = "admin", AccessRight = "Admin" };
        }
    }
}
