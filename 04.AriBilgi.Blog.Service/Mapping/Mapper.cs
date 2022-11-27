using _02.AriBilgi.Blog.Model.ArticleDtos;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using _02.AriBilgi.Blog.Model.CommentDtos;
using _02.AriBilgi.Blog.Model.UserDtos;
using _025.AriBilgi.Blog.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AriBilgi.Blog.Service.Mapping
{
    public static class Mapper
    {
        #region ArticleDtos
        public static ArticleDto ToDto(this Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                IsDeleted = article.IsDeleted,
                FileName = article.FileName
            };
        }
        public static IEnumerable<ArticleDto> ToDto(this IEnumerable<Article> articles)
        {
            return articles.Select(a => a.ToDto());
        }
        public static Article ToEntity(this AddArticleDto addArticleDto)
        {
            return new Article
            {
                Title = addArticleDto.Title,
                Content = addArticleDto.Content,
                CategoryId = addArticleDto.CategoryId,
                IsDeleted = false,
                UserId = 1,
                CreatedDate = DateTime.Now,
                FileName = addArticleDto.FileName
            };
        }
        #endregion

        #region UserDtos
        public static UserDto ToDto(this User user)
        {
            if (user != null)
            {
                return new UserDto { Id = user.Id, Name = user.Name, Surname = user.Surname, Username = user.Username };
            }
            else
            {
                return null;
            }

           
        }
        #endregion

        #region CategoryDto
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                State = category.IsDeleted ? "Silindi" : "Aktif"
            };
        }
        public static IEnumerable<CategoryDto> ToDto(this IEnumerable<Category> categories)
        {
            return categories.Select(c => c.ToDto());
        }
        public static Category ToEntity(this AddCategoryDto addCategoryDto)
        {
            return new Category { Name = addCategoryDto.Name, Description = addCategoryDto.Description, CreatedDate = DateTime.Now, IsDeleted = false };
        }
        #endregion

        #region CommentDtos
        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto { Id = comment.Id, Content = comment.Content, User = comment.User.ToDto() };
        }
        public static IEnumerable<CommentDto> ToDto(this IEnumerable<Comment> comments)
        {
            return comments.Select(x => x.ToDto());
        }
        public static Comment ToEntity(this AddCommentDto addCommentDto)
        {
            return new Comment { Content = addCommentDto.Content, CreatedDate = DateTime.Now, UserId = 1, IsDeleted = false, ArticleId = addCommentDto.ArticleId };
        }
        #endregion
    }
}
