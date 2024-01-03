using PulseActiveShop.Core.Constants;
using PulseActiveShop.Core.Interfaces.Core;
using System.Text.RegularExpressions;

namespace PulseActiveShop.Core.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Username { get; private set; } = null!;

        public string Password { get; private set; } = null!;

        public string Email { get; private set; } = null!;

        public User()
        {

        }

        public User(string username, string password, string email)
        {
            ThrowIfUsernameIsNotValid(username);
            ThrowIfEmailIsNotValid(email);

            Username = username;
            Password = password;
            Email = email;
        }

        public void ThrowIfEmailIsNotValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(email);

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            if (!regex.IsMatch(email))
                throw new ArgumentException("The provided email is not valid");
        }

        public void ThrowIfUsernameIsNotValid(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(username);

            if (username.Length >= ShopConstants.USERNAME_MIN_LENGTH)
                throw new ArgumentException($"The username should be {ShopConstants.USERNAME_MIN_LENGTH} chars long");
        }
    }

    public class UserCollection : BaseEntityCollection<User> { }
}
