using _03.AriBilgi.Blog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AriBilgi.Blog.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _blogContext;

        private readonly ArticleRepository _articleRepository;
        private readonly UserRepository _userRepository;
        private readonly CommentRepository _commentRepository;
        private readonly CategoryRepository _categoryRepository;


        public UnitOfWork()
        {
            _blogContext = new BlogContext();
        }



        public IArticleRepository ArticleRepository => _articleRepository ?? new ArticleRepository(_blogContext);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_blogContext);

        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_blogContext);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_blogContext);
    }
}
