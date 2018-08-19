using FCFFApplication.Contracts;
using FCFFApplication.Mappings;
using FCFFApplication.Services;
using FCFFDomain.Contracts.Repositories;
using FCFFDomain.Contracts.Services;
using FCFFDomain.Services;
using FCFFInfra.Data.Context;
using FCFFInfra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FCFFPresentation.Api
{
    /// <summary>
    /// Classe para registro do AutoMapper, SimpleInjector e Configuração do SimpleInjector
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperConfig.Register();

            SimpleInjectorConfig();
        }

        private void SimpleInjectorConfig()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IEstoqueAppService, EstoqueAppService>(Lifestyle.Scoped);

            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);

            container.Register<IEstoqueDomainService, EstoqueDomainService>(Lifestyle.Scoped);

            container.Register<IProdutoDomainService, ProdutoDomainService>(Lifestyle.Scoped);

            container.Register<IEstoqueRepository, EstoqueRepository>(Lifestyle.Scoped);

            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            
            container.Register<DataContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }


    }

}

