/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     Opportunity_Seeding

 */

using System;
using URC.Models;

namespace URC.Data
{
    public static class SeedStudents
    {
        public static void GenerateSeed(StudentDB context)
        {
            context.Students.Add(new Student
            {
                Uid = "u1234567",
                FirstName = "User",
                LastName = "First",
                EmailAddress = "u0000001@utah.edu",
                PhoneNumber = "3341234567",
                DegreePlan = "BS",
                GPA = 3,
                HoursPerWeek = 20,
                personalStatement = "YES",
                ExpectedGraduationDate = DateTime.Parse("2020-12-29"),
                ApplicationDate = DateTime.Now,
                Active = false,
                StudentSkills = "Coding",
                StudentCompletedCourses = "Course1, Course2, Course3",
                StudentInterests = "Music, Eating",
                Resume = "Resume 1"
            });

            context.Students.Add(new Student
            {
                Uid = "u1234568",
                FirstName = "User",
                LastName = "Second",
                EmailAddress = "u0000002@utah.edu",
                PhoneNumber = "3341234567",
                DegreePlan = "BS",
                GPA = 3.5,
                HoursPerWeek = 20,
                personalStatement = "YES",
                ExpectedGraduationDate = DateTime.Parse("2020-12-29"),
                ApplicationDate = DateTime.Now,
                Active = false,
                StudentSkills = "Writing",
                StudentCompletedCourses = "Course1, Course2, Course3",
                StudentInterests = "Music, Eating",
                Resume = "Resume 2"
            });

            context.SaveChanges();
        }
    }
}