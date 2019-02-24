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

            var paginatedCampaigns = _campaignRepository.GetPaginated(filter, start.Value, length ?? 10, out recordsTotal, out recordsFiltered);
            
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
    }
}