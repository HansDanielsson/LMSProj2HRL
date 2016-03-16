using LMSProj2HRL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LMSProj2HRL.DataAccessLayer
{
    public class ItemContext : DbContext
    {
        public ItemContext() : base("DefaultConnection") { }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
    }
}