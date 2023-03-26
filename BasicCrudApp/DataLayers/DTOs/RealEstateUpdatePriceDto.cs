using System.ComponentModel.DataAnnotations;

namespace BasicCrudApp.DataLayers.DTOs
{
    public class RealEstateUpdatePriceDto
    {
        public int Id { get; set; }

        public int Price { get; set; }
    }
}
