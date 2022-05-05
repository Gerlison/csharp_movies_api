using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos.Theater
{
    public class CreateTheaterDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is mandatory")]
        public int AddressId { get; set; }
    }
}
