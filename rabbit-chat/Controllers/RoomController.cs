using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Models;
using rabbit_chat.Models.Requests;

namespace rabbit_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        /*
        TODO: This is merely a demo, completely retarded. It returns all private rooms.
         */
        [HttpGet]
        public Room OpenPersonalRoom(SimpleOpenPersonalRoomRequest soprRequest)
        {
            using var db = new RabbitChatContext();
            // var x = db.Rooms.Include(room => room.Users).Any(room => room.Users.Count == 2)
            var t = db.Rooms.Include(room => room.Users).ToList();

            Room room = null;
            foreach (var a in t)
            {
                // if (a.Users.Count == 2 && a.Users.Contains(soprRequest.RequestUser) && a.Users.Contains(soprRequest.Friend))
                if (a.Users.Count == 2 ) // && a.Users.Contains(soprRequest.RequestUser) && a.Users.Contains(soprRequest.Friend)
                {
                    room = a;
                }
            }

            return room;
        }

        [HttpPut]
        public void CreatePersonalRoom(SimpleCreatePersonalRoomRequest scprRequest)
        {
            using var db = new RabbitChatContext();
            db.Rooms.Add(new Room
            {
                RoomName = "test",
                Users = new List<RabbitUser>
                {
                    db.RabbitUsers.Single(user => user.RabbitUserId == scprRequest.RequestUserId), 
                    db.RabbitUsers.Single(user => user.RabbitUserId == scprRequest.FriendId)
                }
            });
            db.SaveChanges();
        }
    }
}