using _01.AriBilgi.Blog.Shared;

using _02.AriBilgi.Blog.Model.ArticleDtos;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using _02.AriBilgi.Blog.Model.CommentDtos;
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
    public class ArticleManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager()
        {
            _unitOfWork = new UnitOfWork();
        }


        public ArticleDto Get(int articleId)
        {
            Article article = _unitOfWork.ArticleRepository.Get(a => a.Id == articleId && !a.IsDeleted);

            ArticleDto articleDto = article.ToDto();

            articleDto.User = _unitOfWork.UserRepository.Get(u => u.Id == article.UserId).ToDto();
            articleDto.Category = _unitOfWork.CategoryRepository.Get(c => c.Id == article.CategoryId).ToDto();
            articleDto.Comments = _unitOfWork.CommentRepository.GetAll(c => c.ArticleId == article.Id).ToDto().ToList();

            return articleDto;
        }

        public List<ArticleDto> GetAll()
        {

            List<ArticleDto> articleDtos = (from a in _unitOfWork.ArticleRepository.GetAll()
                                            join c in _unitOfWork.CategoryRepository.GetAll() on a.CategoryId equals c.Id
                                            join u in _unitOfWork.UserRepository.GetAll() on a.UserId equals u.Id
                                            select new ArticleDto
                                            {
                                                Id = a.Id,
                                                Content = a.Content,
                                                IsDeleted = a.IsDeleted,
                                                Title = a.Title,
                                                State = a.IsDeleted ? "Silindi" : "Aktif",
                                                CreatedDate = a.CreatedDate,
                                                Category = c.ToDto(),
                                                User = u.ToDto(),
                                                FileName=a.FileName
                                            }).ToList();
            return articleDtos;

        }

        public List<ArticleDto> GetAll(int categoryId)
        {
            List<ArticleDto> articleDtos = GetAll();
            articleDtos = articleDtos.Where(a => a.Category.Id == categoryId && !a.IsDeleted).ToList();
            return articleDtos;
        }

        public List<ArticleDto> GetAllNonDeleted()
        {
            List<ArticleDto> articleDtos = GetAll();
            articleDtos = articleDtos.Where(a => !a.IsDeleted).ToList();
            return articleDtos;
        }

        public void Add(AddArticleDto addArticleDto)
        {
            try
            {
                

                _unitOfWork.ArticleRepository.Add(addArticleDto.ToEntity());
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(UpdateArticleDto updateArticleDto, int articleId)
        {
            try
            {
                Article article = _unitOfWork.ArticleRepository.Get(a => a.Id == articleId);

                article.Title = updateArticleDto.Title;
                article.Content = updateArticleDto.Content;
                article.CategoryId = updateArticleDto.CategoryId;
                article.ModifedDate = DateTime.Now;
                article.ModifedBy = "Uğurcan Özcan";

                _unitOfWork.ArticleRepository.Update(article);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int articleId)
        {
            try
            {
                Article article = _unitOfWork.ArticleRepository.Get(a => a.Id == articleId);
                article.IsDeleted = true;
                article.DeletedDate = DateTime.Now;
                article.DeletedBy = "Yağız Yenikurtuluş";
                _unitOfWork.ArticleRepository.Update(article);
                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SetActive(int articleId)
        {
            try
            {
                Article article = _unitOfWork.ArticleRepository.Get(a => a.Id == articleId);
                article.IsDeleted = false;
                article.ModifedBy = "Uğurcan Özcan";
                article.ModifedDate = DateTime.Now;

                _unitOfWork.ArticleRepository.Update(article);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      

    }
}
