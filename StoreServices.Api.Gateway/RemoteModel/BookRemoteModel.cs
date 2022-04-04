namespace StoreServices.Api.Gateway.RemoteModel;
    public class BookRemoteModel
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
        public RemoteAuthorModel RemoteAuthor { get; set; }
    }

