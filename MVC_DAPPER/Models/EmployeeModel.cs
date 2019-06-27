using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_DAPPER.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [DisplayName("Nama")]
        public string EmployeeName { get; set; }
        [DisplayName("Join Date")]
        public string JoinDate { get; set; }
        [DisplayName("Photo")]
        public HttpPostedFileBase PhotoInput { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public string DepartmenName { get; set; }
        public List<DepartmentModel> Departments { get; set; }
    }
}