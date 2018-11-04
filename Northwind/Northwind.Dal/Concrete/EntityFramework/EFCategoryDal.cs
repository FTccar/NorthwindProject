using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EFCategoryDal : ICategoryDal
    {
        private NorthwindContext _context = new NorthwindContext();

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            Category cat = Get(categoryId);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }

        public Category Get(int CategoryId)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryID == CategoryId);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        //public void Update(Category category)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
