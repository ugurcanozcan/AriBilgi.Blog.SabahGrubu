using _01.AriBilgi.Blog.Shared;
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
        IResult GetAll();
        IResult GetAllNonDeleted();
        IResult GetAllByCategoryId(int categoryId);
    }
}
