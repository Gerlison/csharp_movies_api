using AutoMapper;
using MoviesApi.Data.Dtos.Theater;
using MoviesApi.Models;

namespace MoviesApi.Profiles
{
    public class TheaterProfile: Profile
    {
        public TheaterProfile()
        {
            CreateMap<Theater, ReadTheaterDto>();
            CreateMap<CreateTheaterDto, Theater>();
            CreateMap<UpdateTheaterDto, Theater>();
        }
    }
}
