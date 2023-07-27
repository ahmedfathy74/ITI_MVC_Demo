using ITI_MVC_Demo.Models;
using ITI_MVC_Demo.ViewModel;
using MessagePack;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Demo.Controllers
{
    public class PassDataController : Controller
    {
        ITIEntity context = new ITIEntity();
        // PassData/testViewData
        public IActionResult testViewData(int id)
        {
            Employee empModel = context.Employees.FirstOrDefault(e=>e.Id == id);
            // Extra info need to send to view 
            string msg = "hello";
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Smart");
            branches.Add("Sohag");
            branches.Add("Minya");
            int temp = 4;
            string color = "Red";

            //ViewData["Message"] = msg;
            ViewData["Message"] = "Hello";
            ViewBag.Message = "New Message"; // write new value for "Message" Key dictionary ViewData
            ViewData["brch"] = branches;
            ViewData["Temp"] = temp;
            ViewData["Color"] = color;
            return View(empModel);
        }
        //ViewModel : custmize class Data need To Send to View 
        // reasons Needs for ViewModel Class
        // 1- Model Send Extra Info 
        // 2- Merge between 2 Model
        // 3- filter property

        public IActionResult testViewModel(int id)
        {
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            // Extra info need to send to view 
            string msg = "hello";
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Smart");
            branches.Add("Sohag");
            branches.Add("Minya");
            int temp = 4;
            string color = "Red";
            // declare ViewModel
            EmployeeWithMessageAndBranchListViewModel empViewModel = new EmployeeWithMessageAndBranchListViewModel();
            // get data from model set ViewModel
            empViewModel.Message = msg;
            empViewModel.Branches = branches;
            empViewModel.Temp = temp;
            empViewModel.Color = color;
            empViewModel.EmpName = empModel.Name;
            empViewModel.EmpID = empModel.Id;

            return View(empViewModel);

        }
    }
}
