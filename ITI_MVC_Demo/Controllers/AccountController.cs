using ITI_MVC_Demo.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ITI_MVC_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        //Registeration
        //action open link

        public IActionResult Registeration()
        {
            return View();
        }

        // action form ==> database
        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterAccountViewModel newAccount)
        {
            if(ModelState.IsValid)
            {
                //map from vm to Model
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;
                // how to save user and create cookie
               IdentityResult result =  await userManager.CreateAsync(user, newAccount.Password);
                if(result.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(user, isPersistent: false); //create cookie
                    return RedirectToAction("Index", "Department");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(newAccount);
        }
      
        //login
        public IActionResult Login(string ReturnUrl = "~/Department/index")
        {
            ViewData["RedirectURl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser, string ReturnUrl = "~/Department/Index")
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginUser.UserName) ;
                if(user!=null)
                {
                   SignInResult signInResult = await signInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.isPersisite, false);
                    
                    if(signInResult.Succeeded)
                    {
                        //return RedirectToAction("Index", "Department");
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "incorrect username & password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid username, password");
                }
            }
            return View(loginUser);
        }
        //logout

        public async  Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
