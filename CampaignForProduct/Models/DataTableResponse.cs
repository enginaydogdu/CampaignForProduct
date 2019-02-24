using CampaignForProduct.Dtos;
using System.Collections.Generic;

namespace CampaignForProduct.Models
{
    public class DataTableResponse
    {
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<CampaignDto> Data { get; set; }
        public string Error { get; set; }
    }
}