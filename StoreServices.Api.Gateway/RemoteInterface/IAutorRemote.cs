using StoreServices.Api.Gateway.RemoteModel;

namespace StoreServices.Api.Gateway.RemoteInterface
{
    public interface IAutorRemote
    {
        Task<RemoteAuthorModel> GetAutor(Guid id);
    }
}
