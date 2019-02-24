using CampaignForProduct.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CampaignForProduct.Data.Repository
{
    public class CampaignRepository : ICampaignRepository<Campaign>
    {
        private CampaignForProductContext _context;

        public CampaignRepository(CampaignForProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Campaign> GetPaginated(bool filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered)
        {
            var data = _context.Campaigns.Include("Product").AsQueryable();
            totalRecords = data.Count();

            if (filter)
            {
                data = data.Where(x => x.End > DateTime.Today);
            }

            recordsFiltered = data.Count();
            data = data
                .OrderBy(x => x.Name)
                .Skip(initialPage * pageSize)
                .Take(pageSize);
                
            return data.ToList();
        }

        public string AddCampaign(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return campaign.Id;
        }
    }
}