using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Models;
using rabbit_chat.Models.Requests;
using rabbit_chat.Services;

namespace rabbit_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        /// <summary>
        /// This will be accessed from the friend view. It should search for
        /// a private room and if it does not exist, call CreatePersonalRoom
        /// and return that new room. This cannot fail considering there must
        /// always be the capability to have a private room between friends.
        /// </summary>
        /// <param name="request"></param>
        [HttpGet]
        public void OpenPersonalRoom(PersonalRoomRequest request)
        {
            using var db = new RabbitChatContext();
            
            var room = db.Rooms.Include(x => x.RabbitUserLink)
        }
        
        /// <summary>
        /// Creates a personal room between two friends.
        /// TODO: Must validate that both users are friends.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public Room CreatePersonalRoom(CreatePersonalRoomRequest request)
        {
            using var db = new RabbitChatContext();

            var first = db.RabbitUsers.Single(user => user.RabbitUserId == request.CreatingUserId);
            var second = db.RabbitUsers.Single(user => user.RabbitUserId == request.InvitedUserId);

            var room = new Room
            {
                RoomName = request.RoomName
            };

            room.RabbitUserLink = new List<RabbitUserRoom>
            {
                new RabbitUserRoom
                {
                    RabbitUser = first,
                    Room = room
                },
                new RabbitUserRoom
                {
                    RabbitUser = second,
                    Room = room
                }
            };
            
            db.Add(room);
            db.SaveChanges();

            return room;
        }
    }
}