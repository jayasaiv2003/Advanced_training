using Microsoft.AspNetCore.Mvc;

namespace CollageApp_View.Controllers
{
    public class Courses : Controller
    {
        public IActionResult Course()
        {
            return View();
        }
    }
}
