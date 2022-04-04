namespace StoreServices.Api.Cart.Model
{
    public class CartSession
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<CartDetail> ProductList { get; set; }
    }
}
