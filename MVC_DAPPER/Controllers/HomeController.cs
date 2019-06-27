using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DAPPER.DataAccess;
using MVC_DAPPER.Models;

namespace MVC_DAPPER.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<EmployeeModel> model = new EmployeeRepo().EmployeeList();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmployeeData(int? id)
        {
            EmployeeModel model = new EmployeeModel();
            if (id != null)
            {
                model = new EmployeeRepo().GetEmployee(id);
            }
            model.Departments = new DepartmentRepo().DepartmentList();

            return View(model);
        }

        [HttpPost]
        public ActionResult EmployeeData(EmployeeModel model)
        {
            try
            {
                byte[] file = null;
                if (model.PhotoInput != null) {
                    file = new byte[model.PhotoInput.ContentLength];
                    model.PhotoInput.InputStream.Read(file, 0, file.Length);
                }
                if (model.EmployeeId == 0)
                {
                    new EmployeeRepo().InsertEmployee(model, file);
                }
                else {
                    new EmployeeRepo().UpdateEmployee(model, file);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteData(int id) {
            new EmployeeRepo().DeleteEmployee(id);
            return RedirectToAction("List");
        }

        public FileResult GetReport(int Id)
        {
            EmployeeModel model = new EmployeeRepo().GetEmployee(Id);    
            return File(model.Photo, "application/pdf");
        }
    }
}