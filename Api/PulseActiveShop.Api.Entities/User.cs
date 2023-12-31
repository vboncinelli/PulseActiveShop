using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class User : BaseApiEntity
    {
        public string? Username { get; set; }

        public string? Email { get; set;}
    }

    public class UserCollection : BaseApiEntityCollection<User> { }
}
