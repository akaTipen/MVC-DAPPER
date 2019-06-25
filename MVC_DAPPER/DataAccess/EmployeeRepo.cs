using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using MVC_DAPPER.Models;

namespace MVC_DAPPER.DataAccess
{
    public class EmployeeRepo
    {
        private static DbTransaction dbTran = new DbTransaction(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        public List<EmployeeModel> EmployeeList() {
            List<EmployeeModel> ls = new List<EmployeeModel>();
            ls = dbTran.DbToList<EmployeeModel>("Sp_Employee_list", null, true);
            return ls;
        }
    }
}