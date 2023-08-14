using ITI_MVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ITI_MVC_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        ITIEntity context = new ITIEntity();

        public IActionResult Index()

        {
            List<Employee> employeesModel = context.Employees.Include(e => e.department).ToList();
            return View(employeesModel);
        }

        public IActionResult EmployeeCardDetails(int empid)
        {
            Employee employee = context.Employees.FirstOrDefault(e=>e.Id == empid);
            return PartialView("_EmployeeCard", employee);
        }

        public IActionResult TestUnique(string Name,string Address,string Image)
        {
            Employee smp = context.Employees.FirstOrDefault(e => e.Name == Name);
            if(smp == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult New()
        {
            // it will not throw exception like previous case that will send an new Department{} dummy object ==>new employee{}
            // because tag helper fix this issue by put all proprties equal null.
            List<Department> deptDropDwonList = context.Departments.ToList();
            ViewData["deptDropDwonList"] = deptDropDwonList;
            return View();
        }
        [HttpPost]
        //call internal
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee newEmployee)
        {
            if(ModelState.IsValid)
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            // can we add error to modestate but this error will be when add validatesummry = all
            //ModelState.AddModelError("Name", "name must contain ITI");

            List<Department> deptList = context.Departments.ToList();
            ViewData["deptList"] = deptList;
            return View("New", newEmployee);
            
        }

        public IActionResult Edit(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e=>e.Id==id);
            List<Department> dept = context.Departments.ToList();
            ViewData["dept"] = dept;
            return View(employee);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Employee empModel)
        {
            if(empModel.Name is not null)
            {
                Employee oldEmp = context.Employees.FirstOrDefault(e => e.Id == id);
                oldEmp.Name = empModel.Name;
                oldEmp.Salary = empModel.Salary;
                oldEmp.Address = empModel.Address;
                oldEmp.Image = empModel.Image;
                oldEmp.Dept_Id = empModel.Dept_Id;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<Department> dept = context.Departments.ToList();
                ViewData["dept"] = dept;
                return View("Edit", empModel);
            }
        }
    }
}
