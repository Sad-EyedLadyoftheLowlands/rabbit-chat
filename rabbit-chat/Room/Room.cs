using System.Collections.Generic;
using rabbit_chat.Users;
using rabbit_chat.Messages;

namespace rabbit_chat.Rooms
{
    public class Room
    {
        /// <summary>
        /// Id of room
        /// </summary>
        public int Id;
        /// <summary>
        /// List of users associated with room
        /// </summary>
        public List<User> Users;
        /// <summary>
        /// List of messages associated with room
        /// </summary>
        public List<Message> Messages;
    }
}