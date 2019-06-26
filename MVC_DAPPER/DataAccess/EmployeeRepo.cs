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

        public List<EmployeeModel> EmployeeList()
        {
            List<EmployeeModel> ls = new List<EmployeeModel>();
            ls = dbTran.DbToList<EmployeeModel>("Sp_Employee_list", null, true);
            return ls;
        }

        public EmployeeModel GetEmployee(int? Id)
        {
            EmployeeModel model = new EmployeeModel();
            model = dbTran.DbToList<EmployeeModel>("Sp_Get_Employee", new { ID = Id }, true).FirstOrDefault();
            return model;
        }

        public void InsertEmployee(EmployeeModel model, byte[] file)
        {
            string[] split = model.JoinDate.Substring(0, 10).Split('/');
            string resultSplit = split[1] + "-" + split[0] + "-" + split[2];

            dbTran.DbExecute("Sp_INSERT_Employee", new
            {
                EmployeeName = model.EmployeeName,
                JoinDate = resultSplit,
                Photo = file,
                Height = model.Height,
                Weight = model.Weight,
                DepartmentId = model.DepartmentId
            }, true);

        }

        public void UpdateEmployee(EmployeeModel model, byte[] file)
        {
            string[] split = model.JoinDate.Substring(0, 10).Split('/');
            string resultSplit = split[1] + "-" + split[0] + "-" + split[2];

            dbTran.DbExecute("Sp_UPDATE_Employee", new
            {
                EmployeeId = model.EmployeeId,
                EmployeeName = model.EmployeeName,
                JoinDate = resultSplit,
                Photo = file,
                Height = model.Height,
                Weight = model.Weight,
                DepartmentId = model.DepartmentId
            }, true);

        }
    }
}