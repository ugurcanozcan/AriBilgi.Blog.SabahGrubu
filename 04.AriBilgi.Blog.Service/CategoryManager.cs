using _01.AriBilgi.Blog.Shared;
using _02.AriBilgi.Blog.Model.CategoryDtos;
using _025.AriBilgi.Blog.Entities;
using _03.AriBilgi.Blog.Data.Repositories;
using _04.AriBilgi.Blog.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AriBilgi.Blog.Service
{
    public class CategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager()
        {
            _unitOfWork = new UnitOfWork();
        }

       

        public IResult Get(int categoryId)
        {
            try
            {
                CategoryDto categoryDto = _unitOfWork.CategoryRepository.Get(c => c.Id == categoryId).ToDto();

                return new DataResult<CategoryDto>(categoryDto, ResultStatus.Success);
            }
            catch (Exception ex)
            {
                //TODO : LOGLAMA YAPILACAK
                return new Result(ResultStatus.Error, "Sistem hatası.", ex);
            }
        }

        public DataResult<List<CategoryDto>> GetAll()
        {
            try
            {
                List<CategoryDto> categoryDtos = _unitOfWork.CategoryRepository.GetAll().ToDto().ToList();
                return new DataResult<List<CategoryDto>>(categoryDtos, ResultStatus.Success);
            }
            catch (Exception ex)
            {
                //TODO : LOGLAMA YAPILACAK
                return new DataResult<List<CategoryDto>>(new List<CategoryDto>(), ResultStatus.Error);
            }
        }

        public IResult GetAllNonDeleted()
        {
            try
            {
                List<CategoryDto> categoryDtos = _unitOfWork.CategoryRepository.GetAll(c => !c.IsDeleted).ToDto().ToList();
                return new DataResult<List<CategoryDto>>(categoryDtos, ResultStatus.Success);
            }
            catch (Exception ex)
            {

                return new Result(ResultStatus.Error, "Sistem hatası.", ex);
            }
        }
    }
}
