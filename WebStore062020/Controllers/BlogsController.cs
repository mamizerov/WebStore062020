using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore062020.Data;
using WebStore062020.Infrastructure.Interfaces;
using WebStore062020.Models;
using WebStore062020.ViewModels;

namespace WebStore062020.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogsData _BlogsData;

        public BlogsController(IBlogsData BlogsData) => _BlogsData = BlogsData;


        public IActionResult Index() => View(_BlogsData.Get());
  

        public IActionResult Details(int id)
        {
            var blog = _BlogsData.GetById(id);
            if (blog is null)
                return NotFound();

            return View(blog);
        }

        #region Edit

        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new BlogsViewModel());

            if (id < 0)
                return BadRequest();

            var blog = _BlogsData.GetById((int)id);
            if (blog is null)
                return NotFound();

            return View(new BlogsViewModel
            {
                Id = blog.Id,
                Name = blog.Name,
                Author = blog.Author,
                TimeBlog = blog.TimeBlog,
                DateBlog = blog.DateBlog,
                StarsBlog = blog.StarsBlog,
                TextBlog = blog.TextBlog
            });
        }

        [HttpPost]
        public IActionResult Edit(BlogsViewModel Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            var blog = new Blog
            {
                Id = Model.Id,
                Name = Model.Name,
                Author = Model.Author,
                TimeBlog = Model.TimeBlog,
                DateBlog = Model.DateBlog,
                StarsBlog = Model.StarsBlog,
                TextBlog = Model.TextBlog
            };

            if (Model.Id == 0)
                _BlogsData.Add(blog);
            else
                _BlogsData.Edit(blog);

            _BlogsData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var blog = _BlogsData.GetById(id);
            if (blog is null)
                return NotFound();

            return View(new BlogsViewModel
            {
                Id = blog.Id,
                Name = blog.Name,
                Author = blog.Author,
                TimeBlog = blog.TimeBlog,
                DateBlog = blog.DateBlog,
                StarsBlog = blog.StarsBlog,
                TextBlog = blog.TextBlog
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _BlogsData.Delete(id);
            _BlogsData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}