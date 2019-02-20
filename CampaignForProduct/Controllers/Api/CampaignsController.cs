using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CampaignForProduct.Dtos;
using CampaignForProduct.Models;

namespace CampaignForProduct.Controllers.Api
{
    public class CampaignsController : ApiController
    {
        private CampaignForProductContext _context;

        public CampaignsController(CampaignForProductContext context)
        {
            _context = context;
        }

        // GET: api/Campaigns
        public IEnumerable<CampaignDto> GetCampaigns(object param)
        {
            return _context.Campaigns
                .Include(c => c.Product)
                .ToList()
                .Select(Mapper.Map<Campaign, CampaignDto>);
        }

        // GET: api/Campaigns/5
        [ResponseType(typeof(CampaignDto))]
        public IHttpActionResult GetCampaign(string id)
        {
            Campaign campaign = _context.Campaigns.Find(id);
            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Campaign, CampaignDto>(campaign));
        }

        // PUT: api/Campaigns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampaign(string id, CampaignDto campaignDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaignDto.Id)
            {
                return BadRequest();
            }

            var campaignInDb = _context.Campaigns.SingleOrDefault(c => c.Id == id);

            if (campaignInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(campaignDto, campaignInDb);

            _context.Entry(campaignInDb).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
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

            _context.Campaigns.Add(campaign);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CampaignExists(campaignDto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = campaignDto.Id }, campaignDto);
        }

        // DELETE: api/Campaigns/5
        [ResponseType(typeof(Campaign))]
        public IHttpActionResult DeleteCampaign(string id)
        {
            Campaign campaign = _context.Campaigns.Find(id);
            if (campaign == null)
            {
                return NotFound();
            }

            _context.Campaigns.Remove(campaign);
            _context.SaveChanges();

            return Ok(campaign);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampaignExists(string id)
        {
            return _context.Campaigns.Count(e => e.Id == id) > 0;
        }
    }
}