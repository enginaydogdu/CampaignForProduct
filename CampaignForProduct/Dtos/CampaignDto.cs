using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CampaignForProduct.Dtos
{
    public class CampaignDto
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ProductId { get; set; }

        public ProductDto Product { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public bool IsActive { get; set; }
    }
}