using StoreServices.Api.ShoppingCart.RemoteModel;

namespace StoreServices.Api.ShoppingCart.RemoteInterface
{
    public interface IBookService
    {
        Task<RemoteBook> GetLibro(Guid Id);
    }
}
