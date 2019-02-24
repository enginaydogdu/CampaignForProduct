using CampaignForProduct.Models;
using System.Collections.Generic;

namespace CampaignForProduct.Data
{
    public interface IProductRepository<T> where T : class
    {
        IEnumerable<T> GetProducts();

        string AddProduct(Product product);        
    }
}
