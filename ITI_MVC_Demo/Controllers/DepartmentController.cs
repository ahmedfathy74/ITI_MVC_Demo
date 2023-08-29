using ITI_MVC_Demo.Models;
using ITI_MVC_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Demo.Controllers
{
    //Share -controllerNAme high level  =>
    ////controalerfactory studentcontroller=new studentcontroler();//container
    public class DepartmentController : Controller
    {
        //ITIEnitities context = new ITIEnitities();
        IDepartmentRepository DepartmentRepository;//loosly -tight
        IEmployeeRepository EmployeeRepo;
        //DI implement & DIP depences inversion princle
        public DepartmentController(IDepartmentRepository _deptREpo, IEmployeeRepository _stdRepo)
        {
            DepartmentRepository = _deptREpo;// new DepartmentRepository();
            EmployeeRepo = _stdRepo;// new StudentRepository();
        }
        public IActionResult Index()
        {
            // Get All Department 
            List<Department> deptListModel = DepartmentRepository.getAll();
           // return View("Index",deptListModel); // view = index, model = deptlistmodel
            return View(deptListModel);           // view = index. model = deptlistmodel
           // return View();                      // view = index. model = null
           // return View("Index");               // view = index. model = null
        }
        // Anchor tag open empty form 
        [HttpGet] //Anchor | Form (get)
        public IActionResult New()
        {
            return View(new Department()); //form
        }
        // submit Button ==> store data in db
        //department/savenew (post)
        [HttpPost] // Form  
        public IActionResult SaveNew(Department dept)
        {
            if (dept.Name != null)
            {
                DepartmentRepository.Create(dept);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New",dept);
            }
        }
        public IActionResult Details(int deptId)
        {
            // Department department = context.Departments.Include(e=>e.Employees).FirstOrDefault(d=>d.Id== deptId);
            Department department = DepartmentRepository.getById(deptId);
            return View(department);
        }

    }
}
