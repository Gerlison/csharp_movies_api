using AutoMapper;
using MoviesApi.Models;
using MoviesApi.Models.Dtos;

namespace MoviesApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, ReadMovieDto>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<CreateMovieDto, Movie>();
        }
    }
}
