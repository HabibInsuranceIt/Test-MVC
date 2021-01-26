using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMvcApp.Models
{
    public class ClsUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string Gender { get; set; }
        public SelectList UserType { get; set; }
    }


}