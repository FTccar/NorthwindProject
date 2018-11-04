using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        //ProductManager _productManager = new ProductManager(new EFProductDal());
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public int pageSize = 5;
        public ViewResult Index(int page = 1)
        {
            List<Product> products = _productService.GetAll();

            return View(new ProductViewModel
            {
                Products = _productService.GetAll().Skip((page - 1) * pageSize).Take(5).ToList(),
                PagingInfo = new PageInfo
                {
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count,
                    CurrentPage = page
                }
            });
        }
    }
}