using _04.AriBilgi.Blog.Service;
using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        
        public IActionResult Index()
        {
            var result = _articleService.GetAll();
            return View();
        }
    }
}
