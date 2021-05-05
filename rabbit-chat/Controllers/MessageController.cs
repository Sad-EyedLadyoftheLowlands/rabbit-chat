using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Migrations;
using rabbit_chat.Models.Requests;
using rabbit_chat.Models;

namespace rabbit_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public void CreateMessage(CreateMessageRequest createMessageRequest)
        {
            using var db = new RabbitChatContext();
            var room = db.Rooms.Include(x => x.Messages)
                .First(x => x.RoomId == createMessageRequest.RoomId);
            
            room.Messages.Add(new Message
            {
                MessageContent = createMessageRequest.Content,
                RabbitUserId = createMessageRequest.SendingUserId,
                TimeSent = DateTime.Now
            });

            db.SaveChanges();
        }
        
        /// <summary>
        /// Returns all messages by room ID.
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpGet("{roomId}")]
        public List<Message> GetAllMessagesFromRoom(int roomId)
        {
            using var db = new RabbitChatContext();
            var room = db.Rooms.Include(x => x.Messages)
                .First(x => x.RoomId == roomId);
            
            return room.Messages.ToList();
        }
    }
}