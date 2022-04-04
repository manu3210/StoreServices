namespace StoreServices.Api.Author.Model
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<AcademyLevel>? AcademyLevels { get; set; }
        public string? BookAuthorGuid { get; set; } //this is going to be used to comunicate with another microservice
    }
}
