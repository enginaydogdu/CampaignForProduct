using CampaignForProduct.Models;
using System.Linq;

namespace CampaignForProduct.Data
{
    public interface ICampaignRepository<T> where T : class
    {
        IQueryable<T> GetPaginated(bool filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered);

        string AddCampaign(Campaign campaign);
    }
}
