using _02.AriBilgi.Blog.Model.ArticleDtos;
using _04.AriBilgi.Blog.Service;
using _05.AriBilgi.Blog.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.API.Controllers
{


    public class ArticleController : BaseController
    {
        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AddArticleDto addArticleDto)
        {
            ArticleManager articleManager = new();

            string[] fileBytesStringFormat = addArticleDto.File.Split(',');
            byte[] fileByte = new byte[fileBytesStringFormat.Length];

            for (int i = 0; i < fileBytesStringFormat.Length; i++)
            {
                fileByte[i] = Convert.ToByte(fileBytesStringFormat[i]);
            }

            System.IO.File.WriteAllBytes(Directory.GetCurrentDirectory() + "/wwwroot/" + addArticleDto.FileName, fileByte);

            articleManager.Add(addArticleDto);
        }

        [HttpPut]
        [Route("Update")]
        public void Update([FromBody] UpdateArticleDto updateArticleDto, int articleId)
        {

            ArticleManager articleManager = new();
            articleManager.Update(updateArticleDto, articleId);
        }

        [HttpGet]
        [Route("Delete")]
        public void Delete(int articleId)
        {

            Shared shared = new();
            string token = HttpContext.Request.Headers["Authorization"];

            if (shared.GetUsername(token) == "ugurcanozcan3")
            {
                ArticleManager articleManager = new();
                articleManager.Delete(articleId);
            }
            
           
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetById")]
        public ArticleDto GetById(int id)
        {
            ArticleManager articleManager = new();
            return articleManager.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<ArticleDto> GetAll()
        {
            ArticleManager articleManager = new();
            return articleManager.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllNonDeleted")]
        public List<ArticleDto> GetAllNonDeleted()
        {
            ArticleManager articleManager = new();
            return articleManager.GetAllNonDeleted();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllByCategoryId")]
        public List<ArticleDto> GetAllByCategoryId(int categoryId)
        {
            ArticleManager manager = new();
            return manager.GetAll(categoryId);
        }

        [HttpPut]
        [Route("SetActive")]
        public void SetActive(int articleId)
        {
            ArticleManager articleManager = new();
            articleManager.SetActive(articleId);
        }


    }
}
