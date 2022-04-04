namespace StoreServices.Api.ShoppingCart.Model
{
    public class CartSession
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public List<CartDetail> CartDetails { get; set; }
    }
}
