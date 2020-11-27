/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     Student

 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URC.Models
{
    public class AppliedOpportunity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppliedOpportunityID { get; set; }
        public string StudentEmail { get; set; }
        public string ProfessorEmail { get; set; }




        public string OpportunitiyID { get; set; }
        public string OpportunitiyName { get; set; }
        public string OpportunityDepartment { get; set; }
        public string OpportunityProfessor { get; set; }



        public DateTime AppliedDate { get; set; }
        public string Status { get; set; }





    }
}