using _01.AriBilgi.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025.AriBilgi.Blog.Entities
{
    public class User : EntityBase, IEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
