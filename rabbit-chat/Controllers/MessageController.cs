using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            db.Add(new Message
            {
                RabbitUserId = createMessageRequest.SendingUserId,
                MessageContent = createMessageRequest.Content,
                // RoomId = createMessageRequest.RoomId,
                TimeSent = DateTime.Now,
                
            });
            db.SaveChanges();
        }

        [HttpGet]
        public List<Message> GetAllMessagesFromRoom([FromBody] int roomId)
        {
            using var db = new RabbitChatContext();
            return db.Messages.Where(message => message.MessageId == roomId).ToList();
        }
        
        [HttpGet]
        public void TestGetMessagesFromRoom([FromBody] int roomId)
        {
            using var db = new RabbitChatContext();
            // var test = db.Rooms.Include(x => x.Messages).Where(y => y.RoomId == roomId).Select(new Message());
            // var test = db.Rooms.Join(Messages, room => room.RoomId,  )

            // var x = db.Messages.Where(x => x.RoomId )
            
            // var query = from db.Roo
        }
    }
}