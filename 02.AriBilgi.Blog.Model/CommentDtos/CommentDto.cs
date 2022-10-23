using _02.AriBilgi.Blog.Model.ArticleDtos;
using _02.AriBilgi.Blog.Model.UserDtos;
using _025.AriBilgi.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AriBilgi.Blog.Model.CommentDtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserDto User { get; set; }
    }
}
