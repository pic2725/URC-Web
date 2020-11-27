/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     Program

 */

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using URC.Data;

namespace URC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var urcContext = services.GetRequiredService<URCcontext>();
                    DbInitializer.InitializeUrc(urcContext);

                    var usersRolesContext = services.GetRequiredService<UsersRolesDB>();
                    DbInitializer.InitializeUsersRolesDb(usersRolesContext);

                    var studentsContext = services.GetRequiredService<StudentDB>();
                    DbInitializer.InitializeStudentApplications(studentsContext);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}