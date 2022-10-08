using _01.AriBilgi.Blog.Shared;
using _02.AriBilgi.Blog.Model.Article;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AriBilgi.Blog.Service
{
    public interface IArticleService
    {
        IResult Get(int articleId);
       
    }
}
