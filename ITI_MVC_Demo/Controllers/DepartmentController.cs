using ITI_MVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class DepartmentController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult Index()
        {
            // Get All Department 
            List<Department>deptListModel = context.Departments.ToList();
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
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New",dept);
            }
        }

    }
}
