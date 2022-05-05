namespace MoviesApi.Data.Dtos.Theater
{
    public class ReadTheaterDto
    {
        public string Name { get; set; }

        public virtual Models.Address Address { get; set; }
    }
}
