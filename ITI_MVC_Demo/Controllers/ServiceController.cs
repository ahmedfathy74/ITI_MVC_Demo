using ITI_MVC_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class ServiceController : Controller
    {
        IEmployeeRepository employeeRepository;
        public ServiceController(IEmployeeRepository _studentRepository)//inject
        {
            employeeRepository = _studentRepository;
        }
        public IActionResult Index()
        {
            ViewData["serviceID"] = employeeRepository.id;
            return View();
        }
    }
}
