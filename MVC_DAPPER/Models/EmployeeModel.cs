using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DAPPER.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JoinDate { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public DepartmentModel Department { get; set; }
    }
}