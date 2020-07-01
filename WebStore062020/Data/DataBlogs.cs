using System.Collections.Generic;
using WebStore062020.Models;

namespace WebStore062020.Data
{
    public class DataBlogs
    {
        public static List<Blog>Blogs { get; } = new List<Blog>
        {
            new Blog
            {
                Id = 1,
                Name = "Блог имени ASP.NET Core 3.1",
                Author = "Pushkin",
                TimeBlog = "1:43 pm",
                DateBlog = "20.10.2019",
                StarsBlog = 4,
                TextBlog = "Здесь отображается информация блога о технологии ASP.NET Core 3.1.",
            },
            new Blog
            {
                Id = 2,
                Name = "Блог имени C#",
                Author = "Lermontov",
                TimeBlog = "8:12 am",
                DateBlog = "04.06.2005",
                StarsBlog = 5,
                TextBlog = "Здесь отображается информация блога о языке C#.",
            },
            new Blog
            {
                Id = 3,
                Name = "Блог имени Java",
                Author = "Dostoevskiy",
                TimeBlog = "11:12 am",
                DateBlog = "14.09.2015",
                StarsBlog = 5,
                TextBlog = "Здесь отображается информация блога о языке Java.",
            },
            new Blog
            {
                Id = 4,
                Name = "Блог имени Payton",
                Author = "Tolstoy",
                TimeBlog = "9:22 pm",
                DateBlog = "04.12.2010",
                StarsBlog = 3,
                TextBlog = "Здесь отображается информация блога о языке Payton.",
            },

        };
    }
}
