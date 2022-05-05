using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class Theater
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int AddressId { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        public virtual Address Address { get; set; }
    }
}
