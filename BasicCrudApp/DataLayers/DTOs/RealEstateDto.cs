using BasicCrudApp.DataLayers.Entities;

namespace BasicCrudApp.DataLayers.DTOs
{
    public class RealEstateDto
    {
        public int Id { get; set; }
        public RealEstateType Type { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfRooms { get; set; }
        public int SizeInSquareMeters { get; set; }
        public int Price { get; set; }

        public string OwnerName { get; set; }
        public string OwnerContact { get; set; }
    }
}
