using System.Buffers;

namespace BasicCrudApp.DataLayers.Entities
{
    public class RealEstateEntity
    {
        public int Id { get; set; }
        public OwnerEntity? Owner { get; set; }
        public RealEstateType Type { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfRooms { get; set; }
        public int SizeInSquareMeters { get; set; }
    }

    public enum RealEstateType
    {
        Apartment,
        House,
        Villa,
        Commercial,
        Industrial
    }
}
