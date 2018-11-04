using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Abstract
{
    interface ICategoryDal
    {
        List<Category> GetAll();

        Category Get(int CategoryId);

        void Add(Category product);

        void Delete(int productId);

        //void Update(Category product);
    }
}
