using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesApi.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string District { get; set; }

        [JsonIgnore]
        public virtual Theater Theater { get; set; }
    }
}
