using _02.AriBilgi.Blog.Model.ArticleDtos;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using _02.AriBilgi.Blog.Model.CommentDtos;
using _02.AriBilgi.Blog.Model.UserDtos;
using _025.AriBilgi.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AriBilgi.Blog.Service.Mapping
{
    public static class Mapper
    {
        public static ArticleDto ToDto(this Article article)
        {
            return new ArticleDto { Id = article.Id, Title = article.Title, Content = article.Content };
        }
        public static IEnumerable<ArticleDto> ToDto(this IEnumerable<Article> articles)
        {
            return articles.Select(a => a.ToDto());
        }


        public static UserDto ToDto(this User user)
        {
            return new UserDto { Id = user.Id, Name = user.Name, Surname = user.Surname, Username = user.Username };
        }

        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto { Id = category.Id, Name = category.Name, Description = category.Description };
        }
        public static IEnumerable<CategoryDto> ToDto(this IEnumerable<Category> categories)
        {
            return categories.Select(c => c.ToDto());
        }


        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto { Id = comment.Id, Content = comment.Content, User = comment.User.ToDto() };
        }

        public static IEnumerable<CommentDto> ToDto(this IEnumerable<Comment> comments)
        {
            return comments.Select(x => x.ToDto());
        }
    }
}
