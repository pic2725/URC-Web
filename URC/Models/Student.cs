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

namespace URC.Models
{
    public class Student
    {
        [Key]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression(@"(^([u])+(\d{7})$)", ErrorMessage = "Must be a valid uID. EX) u1234567")]
        public string Uid { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Resume { get; set; }

        [Required]
        public string DegreePlan { get; set; }

        [Required]
        [Range(0, 4.0)]
        public double GPA { get; set; }

        [Range(0, 120)]
        public int HoursPerWeek { get; set; }

        [StringLength(100)]
        public string personalStatement { get; set; }

        public DateTime ExpectedGraduationDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool Active { get; set; }

        [StringLength(50)]
        public string StudentSkills { get; set; }

        [StringLength(50)]
        public string StudentCompletedCourses { get; set; }

        [StringLength(50)]
        public string StudentInterests { get; set; }

        public IEnumerable<AppliedOpportunity> AppliedOpportunity { get; set; }
    }
}