using System;

namespace rabbit_chat.Models.Requests
{
    public class CreatePersonalRoomRequest
    {
        public int CreatingUserId { get; set; }
        public int InvitedUserId { get; set; }
        public string RoomName { get; set; }
    }
}