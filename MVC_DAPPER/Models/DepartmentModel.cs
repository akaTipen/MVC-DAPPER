using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DAPPER.Models
{
    public partial class DepartmentModel
    {
        public DepartmentModel()
        {
            this.Employees = new HashSet<EmployeeModel>();
        }

        public int DepartmentId { get; set; }
        public string DepartmenCode { get; set; }
        public string DepartmenName { get; set; }
        public ICollection<EmployeeModel> Employees { get; set; }
    }
}