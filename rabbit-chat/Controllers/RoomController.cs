using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Migrations;
using rabbit_chat.Models;
using rabbit_chat.Models.Requests;
using rabbit_chat.Services;

namespace rabbit_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        /*
        TODO: This is merely a demo, completely retarded. It returns all private rooms.
        TODO: Why the hell am I sending whole user objects instead of just ID's?
        
        This will only ever be called when we are certain that there should be a private room.
        Thus, here we can perform the check of does exist? and create and return if not.
        
        What is this supposed to be doing?
        
        Search for single room that has only two users and both of those are ID'd in the request.
         */
        [HttpGet]
        public ObjectResult OpenPersonalRoom(SimpleOpenPersonalRoomRequest soprRequest)
        {
            return new ObjectResult(RoomService.OpenPersonalRoom(soprRequest));
        }

        /*
         * Possibly should return room so the above method does not need another query.
         */
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