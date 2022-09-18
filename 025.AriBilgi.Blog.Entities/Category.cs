using _01.AriBilgi.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025.AriBilgi.Blog.Entities
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Article> Articles { get; set; }
    }
}
