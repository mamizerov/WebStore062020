using System.Collections.Generic;
using WebStore062020.Models;

namespace WebStore062020.Infrastructure.Interfaces
{
    public interface IBlogsData
    {
        IEnumerable<Blog> Get();

        Blog GetById(int id);

        int Add(Blog blog);

        void Edit(Blog blog);

        bool Delete(int id);

        void SaveChanges();
    }
}
