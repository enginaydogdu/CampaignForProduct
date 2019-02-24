using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
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
        public List<ProductDto> Products()
        {
            //var recordsTotal = 0;
            //var recordsFiltered = 0;
            //start = start.HasValue ? start / 10 : 0;

            var products = _productRepository.GetProducts().ToList();

            var data = new List<ProductDto>();
            foreach (var item in products)
            {
                data.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            //foreach (var item in products)
            //{
            //    data.Add(new T
            //    {
            //        Name = item.Name
            //    });
            //}

            //var response = new DataTableResponse
            //{
            //    Data = data
            //};

            return data;
        }

        // GET: api/Products/5
        //[ResponseType(typeof(ProductDto))]
        //public IHttpActionResult GetProductDto(string id)
        //{
        //    ProductDto productDto = db.ProductDtoes.Find(id);
        //    if (productDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(productDto);
        //}

        // PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutProductDto(string id, ProductDto productDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != productDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(productDto).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductDtoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

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

        // DELETE: api/Products/5
        //[ResponseType(typeof(ProductDto))]
        //public IHttpActionResult DeleteProductDto(string id)
        //{
        //    ProductDto productDto = db.ProductDtoes.Find(id);
        //    if (productDto == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ProductDtoes.Remove(productDto);
        //    db.SaveChanges();

        //    return Ok(productDto);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductDtoExists(string id)
        //{
        //    return db.ProductDtoes.Count(e => e.Id == id) > 0;
        //}
    }
}