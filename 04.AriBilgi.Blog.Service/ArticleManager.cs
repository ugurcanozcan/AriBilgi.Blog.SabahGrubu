using _01.AriBilgi.Blog.Shared;

using _02.AriBilgi.Blog.Model.ArticleDtos;
using _025.AriBilgi.Blog.Entities;
using _03.AriBilgi.Blog.Data.Repositories;
using _04.AriBilgi.Blog.Service.Mapping;
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

        public ArticleManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IResult Get(int articleId)
        {
            try
            {

                Article article = _unitOfWork.ArticleRepository.Get(a => a.Id == articleId);

                ArticleDto articleDto = article.ToDto();

                articleDto.User = _unitOfWork.UserRepository.Get(u => u.Id == article.UserId).ToDto();
                articleDto.Category = _unitOfWork.CategoryRepository.Get(c => c.Id == article.CategoryId).ToDto();
                articleDto.Comments = _unitOfWork.CommentRepository.GetAll(c => c.ArticleId == article.Id).ToDto().ToList();

                if (articleDto != null)
                {
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

        public IResult GetAll()
        {
            try
            {
                List<ArticleDto> articleDtos = _unitOfWork.ArticleRepository.GetAll().ToDto().ToList();
                return new DataResult<List<ArticleDto>>(articleDtos, ResultStatus.Success);
            }
            catch (Exception ex)
            {
                //TODO: LOGLAMA YAPILACAK
                return new Result(ResultStatus.Error, "Sistemsel bir hata oluştu.", ex);
            }

        }

        public IResult GetAllByCategoryId(int categoryId)
        {
            try
            {
                List<ArticleDto> articleDtos = _unitOfWork.ArticleRepository.GetAll(a => a.CategoryId == categoryId).ToDto().ToList();
                return new DataResult<List<ArticleDto>>(articleDtos, ResultStatus.Success);
            }
            catch (Exception ex)
            {
                //TODO: LOGLAMA YAPILACAK
                return new Result(ResultStatus.Error, "Sistemsel bir hata oluştu.", ex);
            }
        }

        public IResult GetAllNonDeleted()
        {
            try
            {
                List<ArticleDto> articleDtos = _unitOfWork.ArticleRepository.GetAll(a => !a.IsDeleted).ToDto().ToList();
                return new DataResult<List<ArticleDto>>(articleDtos, ResultStatus.Success);
            }
            catch (Exception ex)
            {
                //TODO: LOGLAMA YAPILACAK
                return new Result(ResultStatus.Error, "Sistemsel bir hata oluştu.", ex);
            }
        }
    }
}
