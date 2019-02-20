using AutoMapper;
using CampaignForProduct.Dtos;
using CampaignForProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaignForProduct.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CampaignDto, Campaign>();

            CreateMap<Product, ProductDto>();
        }
    }
}