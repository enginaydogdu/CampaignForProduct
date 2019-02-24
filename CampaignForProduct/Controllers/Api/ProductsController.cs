using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CampaignForProduct.AutoMapper;
using CampaignForProduct.Data;
using CampaignForProduct.Dtos;
using CampaignForProduct.Models;

namespace CampaignForProduct.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private IProductRepository<Product> _productRepository;

        public ProductsController(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        //GET: api/Products
        [HttpGet]
        public IEnumerable<ProductDto> Products()
        {
            var products = _productRepository.GetProducts();

            var data = new List<ProductDto>();
            foreach (var item in products)
            {
                data.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return data;
        }


        // POST: api/Products
        [ResponseType(typeof(ProductDto))]
        public IHttpActionResult PostProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productDto.Id = Guid.NewGuid().ToString();
            var product = Mapper.Map<ProductDto, Product>(productDto);

            _productRepository.AddProduct(product);

            return CreatedAtRoute("DefaultApi", new { id = productDto.Id }, productDto);
        }        
    }
}