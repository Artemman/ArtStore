using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Domain.Abstract;
using Domain.Concrete;
using Ninject;

namespace WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            //
            kernel.Bind<IProductRepositary>().To<EFProductRepositary>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}