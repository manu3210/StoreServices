namespace StoreServices.Api.Gateway.RemoteModel
{
    public class RemoteAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BookAuthorGuid { get; set; }
    }
}
