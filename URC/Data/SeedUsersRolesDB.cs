/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     SeedUsersRolesDB

 */

using Microsoft.AspNetCore.Identity;
using URC.Const;

namespace URC.Data
{
    public static class SeedUsersRolesDB
    {
        public static void GenerateSeed(UsersRolesDB context)
        {
            context.Roles.Add(new IdentityRole { Id = "1", Name = RoleConst.ADMIN, NormalizedName = RoleConst.ADMIN.ToUpper() });
            context.Roles.Add(new IdentityRole { Id = "2", Name = RoleConst.PROFESSOR, NormalizedName = RoleConst.PROFESSOR.ToUpper() });
            context.Roles.Add(new IdentityRole { Id = "3", Name = RoleConst.STUDENT, NormalizedName = RoleConst.STUDENT.ToUpper() });

            context.Users.Add(new IdentityUser
            {
                Id = "1",
                UserName = "Daniel Pak",
                Email = "admin@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@UTAH.EDU",
                NormalizedUserName = "DANIELPAK"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "2",
                UserName = "Yoon Kim",
                Email = "professor@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "PROFESSOR@UTAH.EDU",
                NormalizedUserName = "YOONKIM"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "3",
                UserName = "Diane Pataki",
                Email = "professor_mary@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "PROFESSOR_MARY@UTAH.EDU",
                NormalizedUserName = "DIANEPATAKI"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "4",
                UserName = "Jimmy",
                Email = "u0000000@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "U0000000@UTAH.EDU",
                NormalizedUserName = "JIMMY"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "5",
                UserName = "Danny",
                Email = "u1234567@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "U1234567@UTAH.EDU",
                NormalizedUserName = "DANNY"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "6",
                UserName = "u0000001@utah.edu",
                Email = "u0000001@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "U0000001@UTAH.EDU",
                NormalizedUserName = "U0000001@UTAH.EDU"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "7",
                UserName = "u0000002@utah.edu",
                Email = "u0000002@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "U0000002@UTAH.EDU",
                NormalizedUserName = "U0000002@UTAH.EDU"
            });
            context.Users.Add(new IdentityUser
            {
                Id = "8",
                UserName = "u0000003@utah.edu",
                Email = "u0000003@utah.edu",
                PasswordHash = "AQAAAAEAACcQAAAAEASy7osooMIdwVsTCMuoc0ZDcz/PSggn0qr1okXMA1RI0/7y8wH/zb1vihChb83/+A==",
                EmailConfirmed = true,
                NormalizedEmail = "U0000003@UTAH.EDU",
                NormalizedUserName = "U0000003@UTAH.EDU"
            });

            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "1", RoleId = "1" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "2", RoleId = "2" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "3", RoleId = "2" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "4", RoleId = "3" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "5", RoleId = "3" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "6", RoleId = "3" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "7", RoleId = "3" });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = "8", RoleId = "3" });

            context.SaveChanges();
        }
    }
}