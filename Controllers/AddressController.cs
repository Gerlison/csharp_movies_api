using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos.Address;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressController(AppDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var addresses = _mapper.Map<IEnumerable<Address>, List<ReadAddressDto>>(_context.Addresses);
            return new OkObjectResult(addresses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return new NotFoundResult();
            }

            var addressDto = _mapper.Map<Address, ReadAddressDto>(address);
            return new OkObjectResult(addressDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateAddressDto addressDto)
        {
            var address = _mapper.Map<CreateAddressDto, Address>(addressDto);

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return new CreatedAtActionResult(nameof(GetById), null, new { address.Id }, address);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateAddressDto addressDto)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return new NotFoundResult();
            }

            _mapper.Map(addressDto, address);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return new NotFoundResult();
            }

            _context.Remove(address);
            return new NoContentResult();
        }
    }
}
