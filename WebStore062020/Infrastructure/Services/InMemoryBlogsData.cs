using System;
using System.Collections.Generic;
using System.Linq;
using WebStore062020.Data;
using WebStore062020.Infrastructure.Interfaces;
using WebStore062020.Models;

namespace WebStore062020.Infrastructure.Services
{
    public class InMemoryBlogsData : IBlogsData
    {
        private readonly List<Blog> _Blogs = DataBlogs.Blogs;

        public IEnumerable<Blog> Get() => _Blogs;

        public Blog GetById(int id) => _Blogs.FirstOrDefault(e => e.Id == id);

        public int Add(Blog blog)
        {
            if (blog is null)
                throw new ArgumentNullException(nameof(blog));

            if (_Blogs.Contains(blog)) return blog.Id;

            blog.Id = _Blogs.Count == 0 ? 1 : _Blogs.Max(e => e.Id) + 1;
            _Blogs.Add(blog);
            return blog.Id;
        }

        public void Edit(Blog blog)
        {
            if (blog is null)
                throw new ArgumentNullException(nameof(blog));

            if (_Blogs.Contains(blog)) return;

            var db_blog = GetById(blog.Id);
            if (db_blog is null) return;

            db_blog.Name = blog.Name;
            db_blog.Author = blog.Author;
            db_blog.TimeBlog = blog.TimeBlog ;
            db_blog.DateBlog = blog.DateBlog;
            db_blog.StarsBlog = blog.StarsBlog;
            db_blog.TextBlog = blog.TextBlog;
        }

        public bool Delete(int id) => _Blogs.RemoveAll(e => e.Id == id) > 0;

        public void SaveChanges() { }
    }
}
