using CampaignForProduct.Models;
using System.Collections.Generic;

namespace CampaignForProduct.Data
{
    public interface ICampaignRepository<T> where T : class
    {
        IEnumerable<T> GetPaginated(bool filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered);

        string AddCampaign(Campaign campaign);
    }
}
