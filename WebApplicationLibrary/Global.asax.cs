using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Library.BLL.Infrastructure;
using WebApplicationLibrary.Util;

namespace WebApplicationLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer<LibraryContext>(new LibraryInitializer());

            // внедрение зависимостей
            NinjectModule orderModule = new BookModul();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            kernel.Unbind<ModelValidatorProvider>();
            //var _kernel = new StandardKernel();
            //_kernel.Unbind<ModelValidatorProvider>();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(_kernel));
        }
    }
}
