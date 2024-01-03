namespace PulseActiveShop.Core.Interfaces.Services
{
    public interface ICryptoService
    {
        /// <summary>
        /// Changes the password for a user by comparing the current password with its hash and updating it with a new password.
        /// </summary>
        /// <param name="currentPassword">The current password entered by the user.</param>
        /// <param name="currentHash">The hash of the current password stored in the system.</param>
        /// <param name="newPassword">The new password to be set for the user.</param>
        /// <returns>The updated password hash if the current password matches the current hash, otherwise returns null.</returns>
        string ChangePassword(string currentPassword, string currentHash, string newPassword);

        /// <summary>
        /// Hashes the given password using a secure hashing algorithm.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>The hashed password.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifies if the provided password text matches the given hash value.
        /// </summary>
        /// <param name="text">The password text to be verified.</param>
        /// <param name="hash">The hash value to compare against.</param>
        /// <returns>True if the password text matches the hash value, otherwise false.</returns>
        bool VerifyPassword(string text, string hash);
    }
}
