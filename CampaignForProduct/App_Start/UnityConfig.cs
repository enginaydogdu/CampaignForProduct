using CampaignForProduct.AutoMapper;
using CampaignForProduct.Data;
using CampaignForProduct.Data.Repository;
using CampaignForProduct.Models;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace CampaignForProduct
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAutoMapperWrapper, AutoMapperWrapper>(new ContainerControlledLifetimeManager());
            container.Resolve<IAutoMapperWrapper>().Initialize();

            container.RegisterType<ICampaignRepository<Campaign>, CampaignRepository>();
            container.RegisterType<IProductRepository<Product>, ProductRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}