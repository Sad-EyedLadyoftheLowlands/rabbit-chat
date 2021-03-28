namespace rabbit_chat.Models.Requests
{
    public class SimpleCreatePersonalRoomRequest
    {
        public int RequestUserId { get; set; }
        public int FriendId { get; set; }
    }
}