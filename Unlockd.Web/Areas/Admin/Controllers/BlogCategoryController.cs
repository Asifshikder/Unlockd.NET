using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Service.Interface.Blog;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogCategoryController : Controller
    {
        private IBlogCategoryService blogCategoryService;
        private IBlogPostService blogPostService;
        private IFileHandler fileHandler;

        public BlogCategoryController(IBlogCategoryService blogCategoryService,
            IBlogPostService blogPostService,
            IFileHandler fileHandler)
        {
            this.blogCategoryService = blogCategoryService;
            this.blogPostService = blogPostService;
            this.fileHandler = fileHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entityList = blogCategoryService.AllAsEnumerable();
            return View(entityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BlogCategory blogCategory = new BlogCategory();
            return View(blogCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogCategory blogCategory)
        {
            blogCategoryService.InsertEntity(blogCategory);
            return Redirect("/Admin/BlogCategory/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BlogCategory blogCategory = blogCategoryService.GetById(id);
            return View(blogCategory);
        }

        [HttpPost]
        [Route("/Admin/BlogCategory/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(BlogCategory blogCategory)
        {
            blogCategoryService.UpdateEntity(blogCategory);
            return Redirect("/Admin/BlogCategory/Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            BlogCategory blogCategory = blogCategoryService.GetById(id);

            if (blogPostService.AllAsEnumerable().Where(b => b.BlogCategoryId == blogCategory.Id).Any())
            {
                ViewBag.Warning = "This category has Blog Post, deleting this category will delete all the post in it.";
            }

            return View(blogCategory);
        }

        [HttpPost]
        [Route("/Admin/BlogCategory/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(BlogCategory blogCategory)
        {
            var blogPosts = blogPostService.AllAsEnumerable().Where(b => b.BlogCategoryId == blogCategory.Id);
            if (blogPosts.Any())
            {
                blogPostService.DeleteMultipleEntity(blogPosts.ToList());
                foreach (var item in blogPosts)
                {
                    if (item.PrimaryImage != null)
                    {
                        fileHandler.DeleteFile(item.PrimaryImage);
                    }
                }
            }

            blogCategoryService.DeleteEntity(blogCategory);
            return Redirect("/Admin/BlogCategory/Index");
        }
    }
}
