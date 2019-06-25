using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_DAPPER.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") {

        }

        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }
    }
}