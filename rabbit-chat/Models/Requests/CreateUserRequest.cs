namespace rabbit_chat.Models.Requests
{
    public class CreateUserRequest
    {
        /// <summary>
        /// Username requested
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password requested
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Alias requested
        /// </summary>
        public string Alias { get; set; }
    }
}

// Default constructor is not sufficient when building an object from a POST request,
// getters and setters are required.