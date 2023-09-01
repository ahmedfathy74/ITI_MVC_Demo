using ITI_MVC_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class ServiceController : Controller
    {
        IEmployeeRepository employeeRepository;
        IWebHostEnvironment env;
        public ServiceController(IEmployeeRepository _studentRepository , IWebHostEnvironment _env)//inject
        {
            employeeRepository = _studentRepository;
            env = _env;
        }
        public IActionResult Index()
        {
            ViewData["serviceID"] = employeeRepository.id;
            return View();
        }
        public IActionResult uploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult uploadImage(IFormFile Image)
        {
            string uploadsFolder = Path.Combine(env.WebRootPath, "Images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }
            return View();
        }
    }
}
