using System.ComponentModel.DataAnnotations;

namespace CampaignForProduct.Models
{
    public class Product
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}