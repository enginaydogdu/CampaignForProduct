using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CampaignForProduct.Models
{
    public class Campaign
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Campaign Name")]
        public string Name { get; set; }

        public Product Product { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime End { get; set; }

        public bool IsActive { get; set; }
    }
}