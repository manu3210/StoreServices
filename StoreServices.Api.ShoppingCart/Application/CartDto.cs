namespace StoreServices.Api.ShoppingCart.Application
{
    public class CartDto
    {
        public int Id { get; set; }
        public DateTime? SessionDate { get; set; }
        public List<CartDetailDto> Details { get; set; }
    }
}
