using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Infrestructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernal;

        public NinjectControllerFactory()
        {
            _ninjectKernal = new StandardKernel();
            AddBllBindings(); 
        }

        private void AddBllBindings()
        {
            _ninjectKernal.Bind<IProductService>().To<ProductManager>()
                .WithConstructorArgument("productDal", new EFProductDal());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernal.Get(controllerType);
        }
    }
}