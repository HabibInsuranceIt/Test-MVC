using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TestMvcApp.Models
{
    public class ClsClaimOfficer
    {
        public int Claim_officer_idx { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Datetime { get; set; }
        public string ActiveStatus { get; set; }
        public bool Statusid { get; set; }
        public List<ClsClaimOfficer> ClaimOfficerList { get; set; }
    }
}