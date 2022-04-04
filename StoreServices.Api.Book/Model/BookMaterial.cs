namespace StoreServices.Api.Book.Model
{
    public class BookMaterial
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
    }
}
