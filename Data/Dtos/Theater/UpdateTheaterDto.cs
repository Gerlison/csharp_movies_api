using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos.Theater
{
    public class UpdateTheaterDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
    }
}
