using Microsoft.AspNetCore.Mvc;
using SiGG_AngularCrud_MVC.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SiGG_AngularCrud_MVC.Controllers
{
    public class Homecontroller : Controller
    {
        EmployeeEntities EmpDb = new EmployeeEntities();   

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployee()
        {
            string message = null;
            string status = null;
            List<Employee> emp = new List<Employee>();   
            try
            {
                emp = EmpDb.Employee.ToList();
                status = "ok";   
            } 
            catch (Exception ex)
            {
                status = "failed";
                message = ex.Message.ToString(); 
            }

            return Json(new { emp, status, message }, JsonRequestBehavior.AllowGet);   
        }  

        public JsonResult GetEmployeeById(int Id)
        {
            string message = null;
            string status = null;
            Employee emp = new Employee();
            try
            {
                emp = empDb.Employee.Find(Id);
                status = "ok";   
            }
            catch (Exception ex)
            {
                status = "failed";
                message = ex.Message;  
            }
            return Json(new { emp, status, message }, JsonRequestBehavior.AllowGet);   
        }

        public JsonResult AddEmployee(Employee emp)
        {
            string message = null;
            string status = null;
            try
            {
                EmpDb.Employee.Add(emp);
                EmpDb.SaveChanges();
                status = "ok";
                message = "Employee record saved sucessfully";
            }
            catch (Exception ex)
            {
                status = "failed";
                message = ex.Message;
            }
            return Json(new { status, message }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteEmployeeById(int Id)
        {
            string message = null;
            string status = null;
            Employee emp = new Employee();
            try
            {
                emp = EmpDb.Employee.Find(Id);
                EmpDb.Employee.Remove(emp);
                EmpDb.SaveChanges();
                status = "ok";
                message = "Employee records deleted successfully";
            }
            catch (Exception ex)
            {
                status = "failed";
                message = ex.Message;
            }
            return Json(new { status, message }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdateEmployee(Employee emp)
        {
            string message = null;
            string status = null;
            //Employee emp = new Employee();
            try
            {
                Employee obj = EmpDb.Employee.Where(x => x.Emp_Id == emp.Emp_Id).FirstOrDefault();
                obj.Emp_Name = emp.Emp_Name;
                obj.Emp_Age = emp.Emp_Age;
                obj.Emp_City = emp.Emp_City;
                EmpDb.SaveChanges();
                status = "ok";
                message = "Record Updated Successfully";
            }
            catch (Exception ex)
            {
                status = "failed";
                message = ex.Message;
            }
            return Json(new { status, message }, JsonRequestBehavior.AllowGet);

        }

    }
}