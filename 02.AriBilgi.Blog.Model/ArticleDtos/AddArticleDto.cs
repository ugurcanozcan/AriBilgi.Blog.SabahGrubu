using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AriBilgi.Blog.Model.ArticleDtos
{
    public class AddArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
    }
}
