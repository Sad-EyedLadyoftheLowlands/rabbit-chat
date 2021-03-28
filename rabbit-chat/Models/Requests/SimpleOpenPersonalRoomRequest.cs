namespace rabbit_chat.Models.Requests
{
    public class SimpleOpenPersonalRoomRequest
    {
        public RabbitUser RequestUser { get; set; }
        public RabbitUser Friend { get; set; }
    }
}