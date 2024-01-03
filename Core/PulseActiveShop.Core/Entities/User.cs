using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }
    }

    public class UserCollection : BaseEntityCollection<User> { }
}
