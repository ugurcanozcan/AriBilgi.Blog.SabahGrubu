using _02.AriBilgi.Blog.Model.ArticleDtos;
using _04.AriBilgi.Blog.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
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
            ArticleManager articleManager = new();
            articleManager.Delete(articleId);
        }

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

        [HttpGet]
        [Route("GetAllNonDeleted")]
        public List<ArticleDto> GetAllNonDeleted()
        {
            ArticleManager articleManager = new();
            return articleManager.GetAllNonDeleted();
        }

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
