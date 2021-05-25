using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Blog;

namespace Unlockd.Service.Interface.Blog
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPost> AllAsEnumerable();
        IQueryable<BlogPost> AllAsQueryable();
        List<BlogPost> AllAsList();
        BlogPost GetById(int id);
        void InsertEntity(BlogPost blogPost);
        void UpdateEntity(BlogPost blogPost);
        void DeleteEntity(BlogPost blogPost);
        void DeleteMultipleEntity(List<BlogPost> blogPosts);
        void DeleteById(int id);
    }
}
