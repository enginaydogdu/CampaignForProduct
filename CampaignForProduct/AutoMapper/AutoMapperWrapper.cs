using AutoMapper;
using CampaignForProduct.Dtos;
using CampaignForProduct.Models;

namespace CampaignForProduct.AutoMapper
{
    public class AutoMapperWrapper : IAutoMapperWrapper
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Campaign, CampaignDto>();
                cfg.CreateMap<CampaignDto, Campaign>();

                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
            });
        }

        public void Reset()
        {
            Mapper.Reset();
        }
    }
}