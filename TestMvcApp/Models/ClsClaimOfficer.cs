using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TestMvcApp.Models
{
    public class ClsClaimOfficer
    {
       [Key]
        public int Claim_officer_idx { get; set; }
      
        [Required]
        public string Username { get; set; }
        [Required]
        public string Location { get; set; }

        public string Datetime { get; set; }
       
        public string ActiveStatus { get; set; }
        [Required]
        public bool Statusid { get; set; }
        [Required]
        public string UserType { get; set; }
        public string SettlementAmount { get; set; }
        public bool BranchChecked { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public SelectList ClaimOfficerType { get; set; }

        public List<ClsClaimOfficer> ClaimOfficerBranchList { get; set; }
        public List<ClsClaimOfficer> ClaimOfficerList { get; set; }

      
    }
}