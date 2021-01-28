using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApp.Models;
namespace TestMvcApp.Controllers
{
    public class ClaimOfficerController : Controller
    {
        // GET: ClaimOfficer
        public ActionResult List()
        {

            DBHelper db = new DBHelper();
            var ClaimOfficerData = new ClsClaimOfficer
            {
                ClaimOfficerList = db.ExecuteQueryData("SELECT DISTINCT claim_officer_idx, username, LOCATION, datetime,CASE WHEN is_active = '1'   THEN 'Yes'   ELSE 'No'  END AS activestatus  FROM hicl_sp_claim_officer", CommandType.Text).DataTableToList<ClsClaimOfficer>()
            };



            return View(ClaimOfficerData.ClaimOfficerList);
        }

        // GET: ClaimOfficer/Details/5
        public ActionResult Details(int id)
        {
            ClsClaimOfficer co = new ClsClaimOfficer();
            DBHelper db = new DBHelper();
            var list = db.ExecuteQueryData("SELECT DISTINCT claim_officer_idx, username, LOCATION, datetime,CASE WHEN is_active = '1'   THEN 'Yes'   ELSE 'No'  END AS activestatus  FROM hicl_sp_claim_officer where  claim_officer_idx='" + id + "'", CommandType.Text).DataTableToList<ClsClaimOfficer>();
            if (list.Count > 0)
            {
                co = list[0];
            }

            return View(co);

        }

        // GET: ClaimOfficer/Create


        public ActionResult Create()
        {
            DBHelper db = new DBHelper();
            ClsClaimOfficer co = new ClsClaimOfficer();
            co.ClaimOfficerType = DataHelper.DT2SelectList(db.ExecuteQueryData("SELECT USER_TYPE_ID, USER_TYPE_DESC FROM HICL_SP_USERTYPE", CommandType.Text), "USER_TYPE_ID", "USER_TYPE_DESC");

            co.ClaimOfficerBranchList = db.ExecuteQueryData("select distinct PLC_LOCACODE as BranchCode,PLC_LOCADESC as  Branch  from PR_GN_LC_LOCATION where PLC_LOCATYPE='D'  order by PLC_LOCADESC asc", CommandType.Text).DataTableToList<ClsClaimOfficer>();

            return View(co);
        }


        // POST: ClaimOfficer/Create

        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(List<ClsClaimOfficer> co)
        {
            //    if (ModelState.IsValid)
            //    {
            //        var datatable = new DataTable();
            //        var dbHelper = new DBHelper();
            //        var dbar = new DbActionResult();
            //        OracleParameter[] param = new OracleParameter[]
            //        {
            //        new OracleParameter("@ClaimOfficer", OracleDbType.NVarchar2, co.Username, ParameterDirection.Input),
            //        new OracleParameter("@Location", OracleDbType.NVarchar2, co.Location, ParameterDirection.Input),
            //        new OracleParameter("@ActiveStatus", OracleDbType.NVarchar2, co.Statusid == true ? "1" : "0", ParameterDirection.Input),
            //         new OracleParameter("@PRC", OracleDbType.RefCursor, ParameterDirection.Output)


            //        };

            //        try
            //        {
            //            datatable = dbHelper.BindGrid("hicl_sp_insertClaimOfficer", CommandType.StoredProcedure, param);
            //            TempData["ClaimOfficeridx"] = datatable.Rows[0]["CLAIMOFFICERIDX"].ToString();
            //            TempData["ReturnMessage"] = "Insert Successfully";
            //            return RedirectToAction("List");
            //        }
            //        catch (Exception ex)
            //        {
            //            TempData["ReturnMessage"] = ex.Message.ToString();
            //            return View();

            //        }
            //    }
            //    else
            //    {
            //        return View();
            //    }

            return View();

        }


        // GET: ClaimOfficer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClaimOfficer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClaimOfficer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClaimOfficer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
