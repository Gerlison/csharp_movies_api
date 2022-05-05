using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos.Theater;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TheaterController: ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TheaterController(AppDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var theatersDto = _mapper.Map<IEnumerable<Theater>, List<ReadTheaterDto>>(_context.Theaters.ToList());;

            return new OkObjectResult(theatersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var theater = _context.Theaters.FirstOrDefault(movie => movie.Id == id);

            if (theater == null)
            {
                return new NotFoundResult();
            }

            var theaterDto = _mapper.Map<ReadTheaterDto>(theater);
            return new OkObjectResult(theaterDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTheaterDto theaterDto)
        {
            var theater = _mapper.Map<Theater>(theaterDto);

            _context.Theaters.Add(theater);
            _context.SaveChanges();

            return new CreatedAtActionResult(nameof(GetById), null, new { theater.Id }, theater);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTheaterDto theaterDto)
        {
            var theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);

            if (theater == null)
            {
                return new NotFoundResult();
            }

            _mapper.Map(theaterDto, theater);
            _context.Theaters.Update(theater);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id); 

            if (theater == null)
            {
                return new NotFoundResult();
            }

            _context.Remove(theater);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
