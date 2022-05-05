using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Models;
using MoviesApi.Models.Dtos;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovieController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var moviesDto = _mapper.Map<IEnumerable<Movie>, List<ReadMovieDto>>(_context.Movies);
            moviesDto.ForEach(m => m.ReadAt = DateTime.Now);

            return new OkObjectResult(moviesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return new NotFoundResult();
            }

            var movieDto = _mapper.Map<ReadMovieDto>(movie);
            movieDto.ReadAt = DateTime.Now;

            return new OkObjectResult(movieDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return new CreatedAtActionResult(nameof(GetById), null, new { movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMovieDto movieDto)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
                return new NotFoundResult();

            _mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
                return new NotFoundResult();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
