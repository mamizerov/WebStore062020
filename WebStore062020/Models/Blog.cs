using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore062020.Models
{
    public class Blog
    {
        public int Id {get; set;}

        public string Name { get; set; }

        public string Author { get; set; }

        public string TimeBlog { get; set; }

        public string DateBlog { get; set; }

        public double StarsBlog { get; set; }

        public string TextBlog { get; set; }
    }
}
