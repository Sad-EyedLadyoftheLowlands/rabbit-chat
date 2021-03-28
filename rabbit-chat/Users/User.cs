using System;
using System.Collections.Generic;

namespace rabbit_chat.Users
{
    public class User
    {
        /// <summary>
        /// Id of user
        /// </summary>
        public int Id;
        /// <summary>
        /// Username of user
        /// </summary>
        public string Username;
        /// <summary>
        /// Password of user
        /// </summary>
        public string Password;
        /// <summary>
        /// User created alias for display purposes only
        /// </summary>
        public string Alias;
        /// <summary>
        /// JWT token
        /// </summary>
        public string JwtToken;
        /// <summary>
        /// Refresh token for JWT
        /// </summary>
        public string RefreshToken;
        /// <summary>
        /// Expiration of refresh token
        /// </summary>
        public DateTime RefreshTokenExp;
        /// <summary>
        /// Firebase token
        /// </summary>
        public string FirebaseToken;
        /// <summary>
        /// DateTime of last login
        /// </summary>
        public DateTime LastLogin;
        public List<User> Friends;
    }
}