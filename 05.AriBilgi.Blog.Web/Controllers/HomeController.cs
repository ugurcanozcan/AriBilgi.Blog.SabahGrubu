using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
