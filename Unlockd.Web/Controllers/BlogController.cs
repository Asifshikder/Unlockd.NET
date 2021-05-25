using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Unlockd.Service.Interface.Blog;
using Unlockd.Web.Areas.Admin.Models.Blog;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private IBlogPostService blogPostService;
        private IBlogCategoryService blogCategoryService;

        public BlogController(
            IBlogPostService blogPostService,
            IBlogCategoryService blogCategoryService)
        {

            this.blogPostService = blogPostService;
            this.blogCategoryService = blogCategoryService;
        }

        public IActionResult Index()
        {
            var blogPosts = blogPostService.AllAsEnumerable().OrderBy(b => b.CreateDate);

            BlogIndexViewModel viewModel = new BlogIndexViewModel()
            {
                BlogPosts = blogPosts.Select(b => new BlogPostViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    PrimaryImage = ".." + b.PrimaryImage.Substring(1),
                    Description = b.Description.Substring(0, b.Description.Length > 300 ? 300 : b.Description.Length) + "...",
                    ShortDescription = b.ShortDesciption.Substring(0, b.ShortDesciption.Length > 200 ? 200 : b.ShortDesciption.Length) + "...",
                    BlogCategoryName = blogCategoryService.GetById(b.BlogCategoryId).Name,
                    CreateDate = b.CreateDate,
                    IsFeatured = b.IsFeatured
                })
            };

            return View(viewModel);
        }
        
        public IActionResult Post(int id)
        {
            var blogPost = blogPostService.GetById(id);
            var blogPosts = blogPostService.AllAsEnumerable().Where(b => b.Id != id).OrderByDescending(b => b.CreateDate).Take(3);

            BlogIndexViewModel viewModel = new BlogIndexViewModel()
            {
                BlogPost = new BlogPostViewModel()
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    ShortDescription = blogPost.ShortDesciption,

                    PrimaryImage = blogPost.PrimaryImage,
                    Description = blogPost.Description,
                    CreateDate = blogPost.CreateDate,
                    BlogCategoryName = blogCategoryService.GetById(blogPost.BlogCategoryId).Name
                },

                BlogPosts = blogPosts.Select(b => new BlogPostViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    ShortDescription = b.ShortDesciption,
                    Description = b.Description,

                    PrimaryImage = b.PrimaryImage,
                    BlogCategoryName = blogCategoryService.GetById(b.BlogCategoryId).Name,
                    CreateDate = b.CreateDate
                })
            };

            return View(viewModel);
        }

    }
}
