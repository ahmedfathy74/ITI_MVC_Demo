using ITI_MVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITI_MVC_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger ,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //home/testparamter/33
        //[Route("tt/{id:int",Name ="route1")]
        //[Route("{id}")]
        //[HttpGet("tt/{id:int:min(20)}")]
        public IActionResult testparamter()
        {
            string myid = RouteData.Values["id"].ToString();
            return Content(myid);
        }
        public IActionResult Index()
        {
            //Exception ex = new Exception();
            //throw ex;
            ViewBag.name = _configuration.GetSection("appname").Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}