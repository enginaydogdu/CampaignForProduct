using CampaignForProduct.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CampaignForProduct.Data.Repository
{
    public class ProductRepository: IProductRepository<Product>
    {
        private CampaignForProductContext _context;

        public ProductRepository(CampaignForProductContext context)
        {
            _context = context;
        }

        public string AddProduct(Product product)
        {
            _context.Products.Add(product);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return product.Id;
        }

        public IEnumerable<Product> GetProducts()
        {
            var data = _context.Products.OrderBy(x => x.Name).ToList();

            return data;
        }
    }
}