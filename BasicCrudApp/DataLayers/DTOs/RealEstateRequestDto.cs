using BasicCrudApp.DataLayers.Entities;

namespace BasicCrudApp.DataLayers.DTOs
{
    public class RealEstateRequestDto
    {
        public OwnerEntity? Owner { get; set; }
        public RealEstateType Type { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfRooms { get; set; }
        public int SizeInSquareMeters { get; set; }

        public int Price { get; set; }
    }
}
