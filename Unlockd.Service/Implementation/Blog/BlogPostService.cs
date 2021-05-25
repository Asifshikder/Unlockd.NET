using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Repo;
using Unlockd.Service.Interface.Blog;

namespace Unlockd.Service.Implementation.Blog
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IRepository<BlogPost> BlogPostrepository;
        public BlogPostService(IRepository<BlogPost> _BlogPostrepository)
        {
            this.BlogPostrepository = _BlogPostrepository;
        }


        public IEnumerable<BlogPost> AllAsEnumerable()
        {
            return BlogPostrepository.GetAllEnumerable();
        }

        public IQueryable<BlogPost> AllAsQueryable()
        {
            return BlogPostrepository.GetAllQueryable();
        }

        public List<BlogPost> AllAsList()
        {
            return BlogPostrepository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = BlogPostrepository.Get(id);
            BlogPostrepository.Delete(entity);
        }

        public void DeleteEntity(BlogPost Color)
        {
            BlogPostrepository.Delete(Color);
        }
        
        public void DeleteMultipleEntity(List<BlogPost> blogPosts)
        {
            foreach(var item in blogPosts)
            {
                BlogPostrepository.Delete(item);
            }

            BlogPostrepository.SaveChanges();
        }

        public BlogPost GetById(int id)
        {
            return BlogPostrepository.Get(id);
        }

        public void InsertEntity(BlogPost Color)
        {
            BlogPostrepository.Insert(Color);
        }

        public void UpdateEntity(BlogPost Color)
        {
            BlogPostrepository.Update(Color);
        }
    }
}