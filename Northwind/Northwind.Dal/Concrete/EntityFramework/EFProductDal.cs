using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {
        NorthwindContext _context = new NorthwindContext();
        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(Get(productId));
        }

        public Product Get(int ProductId)
        {
            return _context.Products.FirstOrDefault(x=>x.ProductID == ProductId);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault(x=>x.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryID = product.CategoryID;

            _context.SaveChanges();
        }
    }
}
