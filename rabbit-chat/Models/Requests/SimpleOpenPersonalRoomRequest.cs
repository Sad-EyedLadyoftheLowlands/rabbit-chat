namespace rabbit_chat.Models.Requests
{
    public class PersonalRoomRequest
    {
        public int RequestUserId { get; set; }
        public int FriendId { get; set; }
    }
}