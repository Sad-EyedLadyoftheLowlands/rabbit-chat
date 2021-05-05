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
        [HttpGet]
        public void OpenPersonalRoom() // (PersonalRoomRequest request)
        {
            using var db = new RabbitChatContext();
            // var t = db.Rooms.Include(x => x.UserRooms).ToList();

            var t = db.RabbitUsers.Select(x => x.RoomLink).ToList();



            // return new ObjectResult(RoomService.OpenPersonalRoom(request));
        }

        /*
         * Possibly should return room so the above method does not need another query.
         */
        [HttpPut]
        public void CreatePersonalRoom(PersonalRoomRequest request)
        {
            // RoomService.CreatePersonalRoom(request);
            using var db = new RabbitChatContext();

            var allRooms = db.Rooms.Include(x => x.RabbitUserLink).ToList();

            var first = db.RabbitUsers.Single(user => user.RabbitUserId == request.RequestUserId);
            var second =  db.RabbitUsers.Single(user => user.RabbitUserId == request.FriendId);

            
            var room = new Room
            {
                RoomName = "test'"
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
            db.Rooms.Add(room);
            db.SaveChanges();
        }
    }
}