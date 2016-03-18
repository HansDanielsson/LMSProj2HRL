namespace LMSProj2HRL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LMSProj2HRL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LMSProj2HRL.DataAccessLayer.ItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LMSProj2HRL.DataAccessLayer.ItemContext context)
        {

            context.Teacher.AddOrUpdate(
                 p => p.LoginId,
                 new Teacher { LoginId = "Admin", FName = "Admin", SName = "Admin", PassWD = "Admin" }
               );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

               
        }
    }
}
