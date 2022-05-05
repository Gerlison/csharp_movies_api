using AutoMapper;
using MoviesApi.Data.Dtos.Address;
using MoviesApi.Models;

namespace MoviesApi.Profiles
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, ReadAddressDto>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
