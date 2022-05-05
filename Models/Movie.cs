using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is mandatory")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is mandatory")]
        public string Director { get; set; }

        [StringLength(30, ErrorMessage = "Director should not be greater than 30 caracters")]
        public string Gender { get; set; }

        [Range(1, 600, ErrorMessage = "Duration should be between 1 and 600 minutes")]
        public int Duration { get; set; }
    }
}
