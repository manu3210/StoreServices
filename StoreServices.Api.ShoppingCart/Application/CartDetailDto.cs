namespace StoreServices.Api.ShoppingCart.Application
{
    public class CartDetailDto
    {
        public Guid? BookId { get; set; }
        public string BookTittle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? BookPublicationDate { get; set; }
    }
}
