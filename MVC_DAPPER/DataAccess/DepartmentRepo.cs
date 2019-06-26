using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MVC_DAPPER.Models;

namespace MVC_DAPPER.DataAccess
{
    public class DepartmentRepo
    {
        private static DbTransaction dbTran = new DbTransaction(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        public List<DepartmentModel> DepartmentList()
        {
            List<DepartmentModel> ls = new List<DepartmentModel>();
            ls = dbTran.DbToList<DepartmentModel>("SELECT * FROM Departments", null, false);
            return ls;
        }
    }
}