using ITI_MVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class ProductController : Controller
    {
        #region First Part

        //public string ShowMsg()
        // {
        //     return "hello it's me";
        // }
        // public ContentResult ShowMsg2()
        // {
        //     ContentResult result = new ContentResult();
        //     result.Content = "local Msg";
        //     return result;
        // }
        // public ViewResult ShowView()
        // {
        //     ViewResult result = new ViewResult();
        //     result.ViewName = "View1";
        //     return result;
        // }
        // public JsonResult jsonview()
        // {
        //     JsonResult result = new JsonResult(new { ID = 1, Name = "ahmed fathy" });
        //     return result;
        // }
        // // product/showmix/1?age=44   // with action parameter with name id only
        // // product/showmix?id=22&age=44  //with any action parameter
        // public IActionResult ShowMix(int id,int age)
        // {
        //     if(id %2==0)
        //     {
        //         return Content("Hello");
        //     }
        //     else
        //     {
        //         return View("View1");
        //     }
        // }
        #endregion


        ProductSampleData productSampleData = new ProductSampleData();

        // show Detail id
        // product/Details/1
        public IActionResult Details(int id)
        {
            //Model
            Product productModel = productSampleData.GetById(id);
            //Send view 
            return View("ProductDetails", productModel); // Model ==>Product
        }
        // show all products
        // product/index
        public IActionResult index()
        {
            return View("ShowAll", productSampleData.GetAll());
        }

    }
}
