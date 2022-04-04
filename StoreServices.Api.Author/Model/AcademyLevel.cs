namespace StoreServices.Api.Author.Model
{
    public class AcademyLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public DateTime? GradeDate { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuthor BookAuthor { get; set; }
        public string AcademyLevelGuid { get; set; }
    }
}
