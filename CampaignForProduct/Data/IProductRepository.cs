using CampaignForProduct.Models;
using System.Linq;

namespace CampaignForProduct.Data
{
    public interface IProductRepository<T> where T : class
    {
        IQueryable<T> GetProducts();

        string AddProduct(Product product);        
    }
}
