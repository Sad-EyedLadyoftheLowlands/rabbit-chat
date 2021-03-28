namespace rabbit_chat.Models.Requests
{
    public class CreateMessageRequest
    {
        /// <summary>
        /// Id of user who sent message.
        /// </summary>
        public int SendingUserId { get; set; }
        
        /// <summary>
        /// TODO: Consider how messages should be handled once we add formatting.
        /// Content of message sent as JSON deserialized as a string.
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Id of room where message is sent from.
        /// </summary>
        public int RoomId { get; set; }
    }
}