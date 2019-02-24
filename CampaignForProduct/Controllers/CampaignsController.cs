using System.Collections.Generic;
using System.Web.Mvc;
using CampaignForProduct.Models;
using CampaignForProduct.ViewModels;

namespace CampaignForProduct.Controllers
{
    public class CampaignsController : Controller
    {
        // GET: Campaigns
        public ActionResult Index()
        {
            return View();
        }
        
        //GET: Campaigns/Create
        public ActionResult Create()
        {            
            var viewModel = new NewCampaignViewModel
            {
                Products = new List<Product>()
            };

            return View(viewModel);
        }                             
    }
}
