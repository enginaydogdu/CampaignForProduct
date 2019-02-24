using CampaignForProduct.Data;
using CampaignForProduct.Models;
using CampaignForProduct.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampaignForProduct.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();            
        }
    }
}