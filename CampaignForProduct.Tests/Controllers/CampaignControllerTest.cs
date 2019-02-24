using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignForProduct;
using CampaignForProduct.Data;
using CampaignForProduct.Models;
using Moq;
using CampaignForProduct.AutoMapper;
using CampaignForProduct.Controllers.Api;
using CampaignForProduct.Dtos;

namespace CampaignForProduct.Tests.Controllers
{
    [TestClass]
    public class CampaignControllerTest
    {
        Campaign campaign;
        CampaignDto campaignDto;
        Product product;
        ProductDto productDto;
        List<Campaign> campaigns;
        int recordsTotal;
        int recordsFiltered;
        AutoMapperWrapper autoMapper = new AutoMapperWrapper();

        [TestInitialize]
        public void TestInitialize()
        {
            autoMapper.Reset();
            autoMapper.Initialize();
            product = new Product { Id = "ProductId", Name = "ProductName" };
            productDto = new ProductDto { Id = "ProductId", Name = "ProductName" };
            campaign = new Campaign
            {
                Id = "CampaignId",
                Name = "CampaignName",
                Start = DateTime.Now,
                End = DateTime.Now.AddMonths(1),
                Product = product
            };
            campaignDto = new CampaignDto
            {
                Name = "CampaignName",
                Start = "01.02.2019",
                End = "01.03.2019",
                Product = productDto
            };
            campaigns = new List<Campaign> { campaign };
        }

        [TestMethod]
        public void Campaigns_ShouldReturnDataTableResponse()
        {
            var repositoryMock = new Mock<ICampaignRepository<Campaign>>();
            repositoryMock.Setup(x => x.GetPaginated(It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<int>(), out recordsTotal, out recordsFiltered)).Returns(campaigns);

            var controller = new CampaignsController(repositoryMock.Object);
            var result = controller.Campaigns(1, 0, 10 ,false);

            CollectionAssert.Equals(campaigns, result.Data);
        }

        [TestMethod]
        public void PostCampaign_ShouldReturnCampaign()
        {
            var repositoryMock = new Mock<ICampaignRepository<Campaign>>();
            repositoryMock.Setup(x => x.AddCampaign(It.IsAny<Campaign>())).Returns(It.IsAny<string>);

            var controller = new CampaignsController(repositoryMock.Object);
            var campaign = controller.PostCampaign(campaignDto);

            Assert.IsNotNull(campaign);
        }
    }
}
