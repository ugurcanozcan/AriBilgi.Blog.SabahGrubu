using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AriBilgi.Blog.Model.CommentDtos
{
    public class AddCommentDto
    {
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}
