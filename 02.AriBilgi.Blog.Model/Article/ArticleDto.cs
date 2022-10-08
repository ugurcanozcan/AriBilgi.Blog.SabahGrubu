using _025.AriBilgi.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AriBilgi.Blog.Model.Article
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
