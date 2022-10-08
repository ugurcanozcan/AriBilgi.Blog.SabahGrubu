using _01.AriBilgi.Blog.Shared;
using _02.AriBilgi.Blog.Model.Article;
using _03.AriBilgi.Blog.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AriBilgi.Blog.Service
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResult Get(int articleId)
        {
            try
            {
                var article = _unitOfWork.ArticleRepository.Get(a => a.Id == articleId);

                if (article != null)
                {
                    ArticleDto articleDto = new ArticleDto()
                    {
                        Id = article.Id,
                        Title = article.Title,
                        Content = article.Content
                    };

                    return new DataResult<ArticleDto>(articleDto, ResultStatus.Success);
                }

                return new Result(ResultStatus.Success, "Aradığınız id'ye ait bir makale bulunumadı");
            }
            catch (Exception ex)
            {
                // TODO: LOGLAMA YAPILACAK
                return new Result(ResultStatus.Error, "Makale getirilemedi. Sistem hatayla karşılaştı.", ex);
            }
        }
    }
}
