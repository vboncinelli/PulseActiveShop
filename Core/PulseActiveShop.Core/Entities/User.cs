using PulseActiveShop.Core.Constants;
using PulseActiveShop.Core.Interfaces.Core;
using System.Text.RegularExpressions;

namespace PulseActiveShop.Core.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }
    }

    public static class UserValidator
    {
        public static bool IsValidEmailAddress(this User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email)) return false;

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            return regex.IsMatch(user.Email);
        }

        public static bool IsValidUsername(this User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username)) return false;

            return user.Username.Length >= ShopConstants.USERNAME_MIN_LENGTH;
        }
    }

    public class UserCollection : BaseEntityCollection<User> { }
}
