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
    public class CampaignsController : ApiController
    {
        private ICampaignRepository<Campaign> _campaignRepository;

        public CampaignsController(ICampaignRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        // GET: api/Campaigns
        [HttpGet]
        public DataTableResponse Campaigns([FromUri] int? draw, int? start, int? length, bool filter)
        {
            var recordsTotal = 0;
            var recordsFiltered = 0;
            start = start.HasValue ? start / 10 : 0;

            var paginatedCampaigns = _campaignRepository.GetPaginated(filter, start.Value, length ?? 10, out recordsTotal, out recordsFiltered).ToList();
            
            var data = new List<CampaignDto>();

            try
            {
                foreach (var item in paginatedCampaigns)
                {
                    data.Add(new CampaignDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Product = new ProductDto
                        {
                            Id = item.Product.Id,
                            Name = item.Product.Name
                        },
                        Start = item.Start.ToShortDateString(),
                        End = item.End.ToShortDateString(),
                        IsActive = item.End > DateTime.Now
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }

            var response = new DataTableResponse
            {
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered,
                Data = data
            };
            return response;            
        }

        // GET: api/Campaigns/5
        //[ResponseType(typeof(CampaignDto))]
        //public IHttpActionResult GetCampaign(string id)
        //{
        //    Campaign campaign = _context.Campaigns.Find(id);
        //    if (campaign == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Mapper.Map<Campaign, CampaignDto>(campaign));
        //}

        // PUT: api/Campaigns/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCampaign(string id, CampaignDto campaignDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != campaignDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var campaignInDb = _context.Campaigns.SingleOrDefault(c => c.Id == id);

        //    if (campaignInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    Mapper.Map(campaignDto, campaignInDb);

        //    _context.Entry(campaignInDb).State = EntityState.Modified;

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CampaignExists(id))
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

        // POST: api/Campaigns
        [ResponseType(typeof(CampaignDto))]
        public IHttpActionResult PostCampaign(CampaignDto campaignDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            campaignDto.Id = Guid.NewGuid().ToString();
            var campaign = Mapper.Map<CampaignDto, Campaign>(campaignDto);

            _campaignRepository.AddCampaign(campaign);

            return CreatedAtRoute("DefaultApi", new { id = campaignDto.Id }, campaignDto);
        }

        // DELETE: api/Campaigns/5
        //[ResponseType(typeof(Campaign))]
        //public IHttpActionResult DeleteCampaign(string id)
        //{
        //    Campaign campaign = _context.Campaigns.Find(id);
        //    if (campaign == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Campaigns.Remove(campaign);
        //    _context.SaveChanges();

        //    return Ok(campaign);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CampaignExists(string id)
        //{
        //    return _context.Campaigns.Count(e => e.Id == id) > 0;
        //}
    }
}