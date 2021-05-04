namespace rabbit_chat.Models.Requests
{
    public class SimpleOpenPersonalRoomRequest
    {
        public int RequestUserId { get; set; }
        public int FriendId { get; set; }
    }
}