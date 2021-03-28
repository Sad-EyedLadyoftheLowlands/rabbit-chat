namespace rabbit_chat.Models.Requests
{
    public class AddFriendRequest
    {
        public int SendingUserId { get; set; }
        public string RequestedFriendUsername { get; set; }
    }
}