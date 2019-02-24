using CampaignForProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaignForProduct.ViewModels
{
    public class NewProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}