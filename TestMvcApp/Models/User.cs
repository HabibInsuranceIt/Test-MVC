using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMvcApp.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public int DropdownVal { get; set; }
        public string GenderDropdown { get; set; }
        public string GenderRadio { get; set; }
        public SelectList UserType { get; set; }

    }
}