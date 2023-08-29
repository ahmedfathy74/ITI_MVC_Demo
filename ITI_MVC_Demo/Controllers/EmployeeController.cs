using ITI_MVC_Demo.Models;
using ITI_MVC_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ITI_MVC_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository EmployeeService;//= new EmployeeRepository();
        IDepartmentRepository deptService;// = new DepartmentRepository();
        //DI 
        //IOC container ==ServiceProvider
        public EmployeeController(IEmployeeRepository _stdPro, IDepartmentRepository _deptRepo)
        {
            //intial
            EmployeeService = _stdPro;
            deptService = _deptRepo;
        }
        public IActionResult Index()

        {
            return View(EmployeeService.getAll());
        }

        public IActionResult EmployeeCardDetails(int empid)
        {
            return PartialView("_EmployeeCard", EmployeeService.getById(empid));
        }

        public IActionResult TestUnique(string Name,string Address,string Image)
        {
            Employee smp = EmployeeService.getByNAme(Name);
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
            List<Department> deptDropDwonList = deptService.getAll();
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
                EmployeeService.Create(newEmployee);
                return RedirectToAction("Index");
            }
            // can we add error to modestate but this error will be when add validatesummry = all
            //ModelState.AddModelError("Name", "name must contain ITI");

            List<Department> deptList = deptService.getAll();
            ViewData["deptList"] = deptList;
            return View("New", newEmployee);
            
        }

        public IActionResult Edit(int id)
        {
            Employee employee = EmployeeService.getById(id);
            List<Department> dept = deptService.getAll();
            ViewData["dept"] = dept;
            return View(employee);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Employee empModel)
        {
            if(empModel.Name is not null)
            {
                EmployeeService.Update(id, empModel);
                return RedirectToAction("Index");
            }
            else
            {
                List<Department> dept = deptService.getAll();
                ViewData["dept"] = dept;
                return View("Edit", empModel);
            }
        }
    }
}
