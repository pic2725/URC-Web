/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     Opportunity

 */

using System;
using System.ComponentModel.DataAnnotations;

namespace URC.Models
{
    public class Opportunity
    {
        [Key]
        public int OpportunityID { get; set; }

        public string ProjectName { get; set; }
        public string ProfessorName { get; set; }
        public string ProfessorEmail { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string AssociatedImag { get; set; }
        public string StudentMentor { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Pay { get; set; }
        public bool Filled { get; set; }
        public string RequiredSkills { get; set; }
        public string SearchTags { get; set; }

        public int numOfApplied { get; set; }
        public int numOfViews { get; set; }


    }
}