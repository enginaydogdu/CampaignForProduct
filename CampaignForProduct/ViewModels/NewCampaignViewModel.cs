using CampaignForProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaignForProduct.ViewModels
{
    public class NewCampaignViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Campaign Campaign { get; set; }
    }
}