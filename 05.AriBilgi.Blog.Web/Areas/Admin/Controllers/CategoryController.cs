using _01.AriBilgi.Blog.Shared;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using _04.AriBilgi.Blog.Service;
using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
      
        public IActionResult Index()
        {
            return View(_categoryService.GetAll().Data);
        }
    }
}
