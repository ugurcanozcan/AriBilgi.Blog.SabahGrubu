using _01.AriBilgi.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025.AriBilgi.Blog.Entities
{
    public class Article : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string FileName { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
