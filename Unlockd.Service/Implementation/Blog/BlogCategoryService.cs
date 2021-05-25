using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Repo;
using Unlockd.Service.Interface.Blog;

namespace Unlockd.Service.Implementation.Blog
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IRepository<BlogCategory> BlogCategoryrepository;
        public BlogCategoryService(IRepository<BlogCategory> _BlogCategoryrepository)
        {
            this.BlogCategoryrepository = _BlogCategoryrepository;
        }


        public IEnumerable<BlogCategory> AllAsEnumerable()
        {
            return BlogCategoryrepository.GetAllEnumerable();
        }

        public IQueryable<BlogCategory> AllAsQueryable()
        {
            return BlogCategoryrepository.GetAllQueryable();
        }

        public List<BlogCategory> AllAsList()
        {
            return BlogCategoryrepository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = BlogCategoryrepository.Get(id);
            BlogCategoryrepository.Delete(entity);
        }

        public void DeleteEntity(BlogCategory Color)
        {
            BlogCategoryrepository.Delete(Color);
        }

        public BlogCategory GetById(int id)
        {
            return BlogCategoryrepository.Get(id);
        }

        public void InsertEntity(BlogCategory Color)
        {
            BlogCategoryrepository.Insert(Color);
        }

        public void UpdateEntity(BlogCategory Color)
        {
            BlogCategoryrepository.Update(Color);
        }
    }
}

