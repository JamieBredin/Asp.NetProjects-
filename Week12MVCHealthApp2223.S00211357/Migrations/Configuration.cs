namespace Week12MVCHealthApp2223.S00211357.Migrations
{
    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using Week12HealthDomain2223.S00211357.models;
    using Week12MVCHealthApp2223.S00211357.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Week12MVCHealthApp2223.S00211357.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week12MVCHealthApp2223.S00211357.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var manager =
              new UserManager<ApplicationUser>(
                  new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            //Creating Admin, Doctor and LabTech roles
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Doctor" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "LabTech" }
                );

            //hash password
            PasswordHasher ps = new PasswordHasher();

            //Creating an Admin User
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "admin@SUH.ie",
                    Email = "admin@SUH.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("TheAdmin$1")
                });

            //Giving Admin User all Roles
            ApplicationUser admin = manager.FindByEmail("admin@SUH.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] {"Admin"});
            }
            //Saves Context
            context.SaveChanges();
            SeedApplicationMembers(manager, context);
            context.SaveChanges();
            //Saving changes
        }
        private void SeedApplicationMembers(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            PasswordHasher ps = new PasswordHasher();

            using (HealthContext DoctorContext = new HealthContext())
            {
                //Getting First Club
                List<Doctor> doctors = DoctorContext.Doctor.ToList();
                //Giving first member to be part of admin group
                foreach (Doctor d in doctors)
                {
                  //I dont know why this will not work for the doctors to seed the Doctors as Users
                        IdentityResult result = manager.Create(new ApplicationUser
                        {
                            EmailConfirmed = true,
                            Email = d.Email,
                            UserName = d.Email,
                            SecurityStamp = Guid.NewGuid().ToString(),
                            PasswordHash = ps.HashPassword(d.DSS+"$1")
                        });
                        if (result.Succeeded)
                        {
                            ApplicationUser doctorMember = manager.FindByEmail(d.Email);
                            if (doctorMember != null)
                            {
                                manager.AddToRoles(doctorMember.Id, new string[] { "Doctor" });
                            }
                        }
                    //}

                  
                }
                context.SaveChanges();
                //saving changes
            }
        }
    }
}
