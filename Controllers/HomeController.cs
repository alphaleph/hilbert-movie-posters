using Microsoft.AspNetCore.Mvc;

namespace MoviePostersApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}