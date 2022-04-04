namespace StoreServices.Api.ShoppingCart.Model
{
    public class CartDetail
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string SelectedProduct { get; set; }
        public int CartSessionId { get; set; }
    }
}
