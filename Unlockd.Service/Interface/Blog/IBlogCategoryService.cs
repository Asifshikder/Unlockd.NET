using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Blog;

namespace Unlockd.Service.Interface.Blog
{
    public interface IBlogCategoryService
    {
        IEnumerable<BlogCategory> AllAsEnumerable();
        IQueryable<BlogCategory> AllAsQueryable();
        List<BlogCategory> AllAsList();
        BlogCategory GetById(int id);
        void InsertEntity(BlogCategory BlogCategory);
        void UpdateEntity(BlogCategory BlogCategory);
        void DeleteEntity(BlogCategory BlogCategory);
        void DeleteById(int id);
    }
}
