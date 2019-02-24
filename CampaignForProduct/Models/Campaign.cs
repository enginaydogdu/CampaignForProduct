using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Start { get; set; }

        [Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime End { get; set; }
    }
}