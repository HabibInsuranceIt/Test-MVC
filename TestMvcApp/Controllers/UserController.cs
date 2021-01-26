using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApp.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TestMvcApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //public ActionResult Login(User u)
        //{
        //    var message = "";
        //    var dbar = new DbActionResult();

        //    var dbHelper = new DBHelper();
        //    OracleParameter[] param = new OracleParameter[]
        //   {
        //         new OracleParameter("@username", OracleDbType.NVarchar2,u.Username , ParameterDirection.Input),
        //         new OracleParameter("@password", OracleDbType.NVarchar2,u.Password , ParameterDirection.Input),


        //   };
        //    try
        //    {

        //        dbar = dbHelper.SaveChanges("hicl_insertsurveyordetail", CommandType.StoredProcedure, param);
        //        if (dbar.Action == true)
        //        {
        //            message = "Insert Surveyor Detail Successfully";
        //        }
        //        else
        //        {
        //            message = dbar.ErrorMessage.ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //    return RedirectToAction("Index","Home");

        //}
        public ActionResult Login()
        {
            DBHelper db = new DBHelper();
             
            User u = new User();
            u.UserType= DataHelper.DT2SelectList(db.ExecuteQueryData("SELECT USER_TYPE_ID, USER_TYPE_DESC FROM HICL_SP_USERTYPE", CommandType.Text), "USER_TYPE_ID", "USER_TYPE_DESC");
           TempData["UserType"] = u;
            
            return View(u);

           

        }
        public ActionResult AddUser(User u)
        {
            string a = u.Username;
            string b = u.Username;
            int c = u.DropdownVal;
            string d = u.GenderDropdown;
            string e = u.GenderRadio;
            return RedirectToAction("Login", "User");

        }
    }
}