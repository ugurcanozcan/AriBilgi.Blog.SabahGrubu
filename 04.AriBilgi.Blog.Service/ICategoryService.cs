using _01.AriBilgi.Blog.Shared;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AriBilgi.Blog.Service
{
    public interface ICategoryService
    {
        IResult Get(int categoryId);
        DataResult<List<CategoryDto>> GetAll();
        IResult GetAllNonDeleted();
    }
}
