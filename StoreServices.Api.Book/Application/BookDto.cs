namespace StoreServices.Api.Book.Application
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
    }
}
