using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using Transformers.Bank.Data.Context;

namespace Transformers.Bank.WebApi
{
    public static class DiContainerConfig
    {
        public static SimpleInjector.Container Container { get; set; }

        public static void Register(HttpConfiguration config)
        {
            Container = new SimpleInjector.Container();

            //Async Scope designed for Web API.
            Container.Options.DefaultLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            //Register Data Worker (UoW)
            Container.Register<IDataWorker, DataWorker>();

            Container.RegisterWebApiControllers(config);
            Container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }
    }
}