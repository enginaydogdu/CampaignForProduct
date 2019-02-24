using System.Collections.Generic;
using CampaignForProduct.AutoMapper;
using CampaignForProduct.Controllers.Api;
using CampaignForProduct.Data;
using CampaignForProduct.Dtos;
using CampaignForProduct.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CampaignForProduct.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        Product product;
        ProductDto productDto;
        List<Product> products;
        AutoMapperWrapper autoMapper = new AutoMapperWrapper();

        [TestInitialize]
        public void TestInitialize()
        {
            autoMapper.Reset();
            autoMapper.Initialize();
            product = new Product { Id = "ProductId", Name = "ProductName" };
            products = new List<Product> { product };
            productDto = new ProductDto { Id = "ProductId", Name = "ProductName" };
        }

        [TestMethod]
        public void Products_ShouldReturnProduct()
        {
            var repositoryMock = new Mock<IProductRepository<Product>>();
            repositoryMock.Setup(x => x.GetProducts()).Returns(products);

            var controller = new ProductsController(repositoryMock.Object);
            var result = controller.Products();

            CollectionAssert.Equals(products, result);
        }

        [TestMethod]
        public void PostProduct_ShouldReturnProduct()
        {
            var repositoryMock = new Mock<IProductRepository<Product>>();
            repositoryMock.Setup(x => x.AddProduct(It.IsAny<Product>())).Returns(It.IsAny<string>);

            var controller = new ProductsController(repositoryMock.Object);
            var product = controller.PostProduct(productDto);

            Assert.IsNotNull(product);
        }
    }
}
