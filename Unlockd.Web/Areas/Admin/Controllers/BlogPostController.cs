using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Service.Interface.Blog;
using Unlockd.Web.Areas.Admin.Models.Blog;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogPostController : Controller
    {
        private IBlogPostService blogPostService;
        private IBlogCategoryService blogCategoryService;
        private IFileHandler fileHandler;

        public BlogPostController(IBlogPostService blogPostService, IBlogCategoryService blogCategoryService, IFileHandler fileHandler)
        {
            this.blogPostService = blogPostService;
            this.blogCategoryService = blogCategoryService;
            this.fileHandler = fileHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entityList = blogPostService.AllAsEnumerable();

            foreach (var item in entityList)
            {
                item.BlogCategory = blogCategoryService.GetById(item.BlogCategoryId);
            }

            return View(entityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.catlist = new SelectList(blogCategoryService.AllAsEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostViewModel blogPost)
        {
            if (blogPost.PrimaryImageFile != null)
            {
                blogPost.PrimaryImage = fileHandler.UploadFile("Blog", blogPost.PrimaryImageFile);
            }

            BlogPost model = new BlogPost();
            model.Title = blogPost.Title;
            model.Description = blogPost.Description;
            model.ShortDesciption = blogPost.ShortDescription;
            model.PrimaryImage = blogPost.PrimaryImage;
            model.BlogCategoryId = blogPost.BlogCategoryId;
            blogPostService.InsertEntity(model);
            return Redirect("/Admin/BlogPost/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.catlist = new SelectList(blogCategoryService.AllAsEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            BlogPost blogPost = blogPostService.GetById(id);

            BlogPostViewModel viewModel = new BlogPostViewModel()
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Description = blogPost.Description,
                ShortDescription = blogPost.ShortDesciption,
                BlogCategoryId = blogPost.BlogCategoryId,
                PrimaryImage = blogPost.PrimaryImage
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Admin/BlogPost/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(BlogPostViewModel viewModel)
        {
            if (viewModel.PrimaryImageFile != null)
            {
                viewModel.PrimaryImage = fileHandler.UpdateFile(viewModel.PrimaryImage, "Blog", viewModel.PrimaryImageFile);
            }

            BlogPost blogPost = new BlogPost()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description,
                ShortDesciption = viewModel.ShortDescription,
                BlogCategoryId = viewModel.BlogCategoryId,
                PrimaryImage = viewModel.PrimaryImage
            };

            blogPostService.UpdateEntity(blogPost);
            return Redirect("/Admin/BlogPost/Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            BlogPost BlogPost = blogPostService.GetById(id);
            return View(BlogPost);
        }

        [HttpPost]
        [Route("/Admin/BlogPost/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(BlogPost blogPost)
        {
            if (blogPost.PrimaryImage != null)
            {
                fileHandler.DeleteFile(blogPost.PrimaryImage);
            }

            blogPostService.DeleteEntity(blogPost);
            return Redirect("/Admin/BlogPost/Index");
        }
        public IActionResult ChangeFeaturedStatus(int id)
        {
            var featuredCount = blogPostService.AllAsEnumerable().Where(b => b.IsFeatured == true).Count();
            var blogPost = blogPostService.GetById(id);
            if (featuredCount >= 3 && !blogPost.IsFeatured)
            {
                return Redirect("/Admin/BlogPost/index");
            }
            else
            {
                blogPost.IsFeatured = !blogPost.IsFeatured;
                blogPostService.UpdateEntity(blogPost);
                return Redirect("/Admin/BlogPost/index");
            }
        }
    }
}
