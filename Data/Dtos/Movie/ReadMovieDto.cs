using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models.Dtos
{
    public class ReadMovieDto
    {

        [Required(ErrorMessage = "Title is mandatory")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is mandatory")]
        public string Director { get; set; }

        [StringLength(30, ErrorMessage = "Director should not be greater than 30 caracters")]
        public string Gender { get; set; }

        [Range(1, 600, ErrorMessage = "Duration should be between 1 and 600 minutes")]
        public int Duration { get; set; }

        public DateTime ReadAt { get; set; }
    }
}
