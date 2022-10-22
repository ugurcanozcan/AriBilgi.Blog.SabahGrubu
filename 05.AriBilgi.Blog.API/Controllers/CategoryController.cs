using _01.AriBilgi.Blog.Shared;
using _02.AriBilgi.Blog.Model.ArticleDtos;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using _025.AriBilgi.Blog.Entities;
using _04.AriBilgi.Blog.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [Route("AddArticle")]
        public void AddArticle([FromBody]Article articleDto)
        {
         

        }

       
    }
}
