using ITI_MVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class BindController : Controller
    {
        //Model Binding : Map Action Parameter With Request Data (FormData - Query String - RouteData)
        //Bind Premitive Type
        // l bining dh  byb2a 3n try2 l querystring byb2a f l get
        //Bind/testPremitive?id=1&name=ahmed&age=33&color=red&color=blue
        //Bind/testPremitive/1?name=ahmed&age=33 --> Id by default is defined in routedata so it's will be routing by default 

        public IActionResult testPremitive(int id , string name,int age, string[] color)
        {
            return Content($"Name = {name}, ID = {id}");
        }

        // Bind Collection (Dictionary (Key,Value))
        //Bind/testDic?name=SD&phones[ahmed]=123&phones[ali]=456
        public IActionResult testDic(Dictionary<string,int> phones,string name)
        {
            return Content($"Name = {name}");
        }
        //Binding Custom/Complex type
        //Bind/testComplex/1?name=sd&managername=Amira
        //Bind/testComplex/1?name=sd&managername=Amira&Employees[0].Name=ahmed

        // hna lma bb3t data  l query string we hya primitive data we mwgoda gw class wna 3mlo l f method object fa hoa byro7 y3ml bind ly primitive types(properties l gwa l object)  
        // l attribute bind by7dd l properties l 3azy y3ml 3leha bind bs.
        public IActionResult testComplex([Bind(include:"Id,Name")]Department dept)
        {
            return Content($"ok");
        }

    }
}
