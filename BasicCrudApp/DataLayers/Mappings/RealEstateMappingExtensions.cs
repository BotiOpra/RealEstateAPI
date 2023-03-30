using BasicCrudApp.DataLayers.DTOs;
using BasicCrudApp.DataLayers.Entities;

namespace BasicCrudApp.DataLayers.Mappings
{
    public static class RealEstateMappingExtensions
    {
        public static RealEstateEntity ToRealEstateEntity(this RealEstateRequestDto requestDto, int id)
        {
            RealEstateEntity realEstate = new()
            {
                Id = id,
                Owner = requestDto.Owner,
                Type = requestDto.Type,
                City = requestDto.City,
                Street = requestDto.Street,
                NumberOfRooms = requestDto.NumberOfRooms,
                SizeInSquareMeters = requestDto.SizeInSquareMeters,
                Price = requestDto.Price,
            };

            return realEstate;
        }

        public static RealEstateDto? ToRealEstateDto(this RealEstateEntity realEstate)
        {
            if (realEstate == null)
                return null;

            RealEstateDto realEstateDto = new()
            {
                Id = realEstate.Id,
                OwnerName = realEstate.Owner.FirstName + " " + realEstate.Owner.LastName,
                OwnerContact = realEstate.Owner.PhoneNumber,
                Type = realEstate.Type,
                City = realEstate.City,
                Street = realEstate.Street,
                NumberOfRooms = realEstate.NumberOfRooms,
                SizeInSquareMeters = realEstate.SizeInSquareMeters,
                Price = realEstate.Price
            };

            return realEstateDto;
        }
    }
}
