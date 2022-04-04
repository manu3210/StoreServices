namespace StoreServices.Api.ShoppingCart.RemoteModel
{
    public class RemoteBook
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
    }
}
