using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMvcApp.Models
{
    public class DataHelper
    {
        public static System.Web.Mvc.SelectList DT2SelectList(DataTable dt, string valueField, string textField)
        {
            if (dt == null || valueField == null || valueField.Trim().Length == 0
                || textField == null || textField.Trim().Length == 0)
                return null;

            List<SelectListItem> listName = new List<SelectListItem>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listName.Add(new SelectListItem { Value = dt.Rows[i][valueField].ToString(), Text = dt.Rows[i][textField].ToString() });
            }
            return new System.Web.Mvc.SelectList(listName, "Value", "Text");
        }
    }
}