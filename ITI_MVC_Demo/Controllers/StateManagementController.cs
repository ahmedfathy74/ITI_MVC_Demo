using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult setTempData()
        {
            TempData["msg"] = "Set Hello Message";
            return Content("Data Saved in Cookie by default");
        }
        public IActionResult get1() 
        {
            // read from TempData    
            string message = "Empty String";
            if(TempData.ContainsKey("msg"))
            {
                //message = TempData["msg"].ToString(); // normal read
                message = TempData.Peek("msg").ToString();
            }
            return Content("get1 func: " + message);
        }
        public IActionResult get2()
        {
            // read from TempData
            string message = TempData["msg"].ToString(); // normal read
            TempData.Keep("msg"); // always keep this data in this key
            return Content("get2 func: " + message);
        }

        public IActionResult setSessionData()
        {
            HttpContext.Session.SetString("name", "ahmed");
            HttpContext.Session.SetInt32("age", 25);

            return Content("Data Saved In Session");
        }
        public IActionResult getSessionData()
        {
            string name = HttpContext.Session.GetString("name");
            int age = HttpContext.Session.GetInt32("age").Value;

            return Content($"Name = {name}, Age = {age}");
        }

        public IActionResult setCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Secure = true;
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("name", "fathy", cookieOptions); // presetent cookie
            Response.Cookies.Append("age", "12"); //session cookie 20 min

            return Content("Cookie saved");
        }
        public IActionResult getCookie()
        {
           string name = Request.Cookies["name"];
            int age = int.Parse(Request.Cookies["age"]);

            return Content($"From cookie : {name} {age}");
        }
    }
}
