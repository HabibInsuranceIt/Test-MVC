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
            
            return View();
        }

      
        // POST: ClaimOfficer/Create
        [HttpPost]
        public ActionResult Create(ClsClaimOfficer co)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
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
