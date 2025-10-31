using Microsoft.AspNetCore.Mvc;

namespace CollegeApp_View.Controllers
{
    public class College_App : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
