using Microsoft.Extensions.Logging;
using PulseActiveShop.Core.Constants;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Application.Services.Services
{
    public class UserService : BaseService<User, UserCollection, UserService>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService, ILogger<UserService> logger) : base(logger)
        {
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

            this._cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
        }

        /// <summary>
        /// Logs in a user with the provided username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The logged in user.</returns>
        public async Task<User> LoginWithUsernameAsync(string username, string password)
        {
            try
            {
                var user = await this._userRepository.FindUserByNameAsync(username);

                if (user == null)
                    throw new InvalidLoginException("Username and/or password do not match");

                var result = _cryptoService.VerifyPassword(password, user.Password!);

                if (!result)
                    throw new InvalidLoginException("Username and/or password do not match");

                return user;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Logs in a user with the provided email and password.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The logged in user.</returns>
        public async Task<User> LoginWithEmailAsync(string email, string password)
        {
            try
            {
                var user = await this._userRepository.FindUserByEmailAsync(email);

                if (user == null)
                    throw new InvalidLoginException("Email and/or password do not match");

                var result = _cryptoService.VerifyPassword(password, user.Password!);

                if (!result)
                    throw new InvalidLoginException("Email and/or password do not match");

                return user;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Finds a user by their username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to find.</param>
        /// <returns>The found user, or null if no user is found.</returns>
        public async Task<User?> FindUserByUsernameAsync(string username)
        {
            try
            {
                return await this._userRepository.FindUserByNameAsync(username);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Finds a user by their email asynchronously.
        /// </summary>
        /// <param name="email">The email of the user to find.</param>
        /// <returns>The found user, or null if no user is found.</returns>
        public async Task<User?> FindUserByEmailAsync(string email)
        {
            try
            {
                return await this._userRepository.FindUserByEmailAsync(email);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Checks if first user initialization is required.
        /// </summary>
        /// <returns>
        /// True if initialization is required, false otherwise.
        /// </returns>
        public async Task<bool> CheckIfUserInitializationIsRequiredAsync()
        {
            try
            {
                var count = await this._userRepository.CountAsync();

                return count == 0;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Add a new User entity asynchronously.
        /// </summary>
        /// <param name="entity">The User entity to insert.</param>
        /// <returns>The inserted User entity.</returns>
        public async Task<User> AddAsync(User entity)
        {
            try
            {
                this.ValidateUserData(entity);

                await ThrowIfUsernameAlreadyExistsAsync(entity.Username!);

                await ThrowIfEmailAlreadyExistsAsync(entity.Email!);

                var hashedPassword = _cryptoService.HashPassword(entity.Password!);

                entity.Password = hashedPassword;

                return await this._userRepository.AddAsync(entity);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        private void ValidateUserData(User user)
        {
            if (!user.IsValidUsername())
            {
                throw new InvalidParameterException($"Please provide an username. The username should be at least {ShopConstants.USERNAME_MIN_LENGTH} characters long");
            }

            if (!user.IsValidEmailAddress())
            {
                throw new InvalidParameterException("Please provide a valid email");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new InvalidParameterException("Please provide a password");
            }
        }

        private async Task ThrowIfUsernameAlreadyExistsAsync(string username)
        {
            var user = await this._userRepository.FindUserByNameAsync(username);

            if (user != null)
                throw new UsernameAlreadyExistingException($"An user with the same username already exists");
        }

        private async Task ThrowIfEmailAlreadyExistsAsync(string email)
        {
            var user = await this._userRepository.FindUserByEmailAsync(email);

            if (user != null)
                throw new EmailAlreadyExistingException($"An user with the same email already exists");
        }
    }
}
