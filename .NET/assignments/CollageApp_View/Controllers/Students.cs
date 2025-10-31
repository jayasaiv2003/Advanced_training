using Microsoft.AspNetCore.Mvc;

namespace CollageApp_View.Controllers
{
    public class Students : Controller
    {
        public IActionResult Student()
        {
            return View();
        }
    }
}
