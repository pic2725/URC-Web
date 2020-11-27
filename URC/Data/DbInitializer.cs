/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     DbInitializer

 */

using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace URC.Data
{
    public static class DbInitializer
    {
        public static void InitializeUrc(URCcontext context)
        {
            context.Database.EnsureCreated();

            if (!context.Opportunities.Any())
            {
                Opportunity_Seeding.GenerateSeed(context);
            }

            context.SaveChanges();
        }

        public static void InitializeUsersRolesDb(UsersRolesDB context)
        {
            context.Database.EnsureCreated();

            if (!context.UserRoles.Any())
            {
                SeedUsersRolesDB.GenerateSeed(context);
            }

            context.SaveChanges();
        }

        public static void InitializeStudentApplications(StudentDB context)
        {
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                SeedStudents.GenerateSeed(context);
            }

            context.SaveChanges();
        }
    }
}