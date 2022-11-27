using _02.AriBilgi.Blog.Model.UserDtos;
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
    public class UserManager
    {
        private readonly IUnitOfWork unitOfWork;
        public UserManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public UserDto LoginCheck(string username, string password)
        {
            return unitOfWork.UserRepository.Get(u => u.Username == username && u.Password == password && !u.IsDeleted).ToDto();
        }
    }
}
