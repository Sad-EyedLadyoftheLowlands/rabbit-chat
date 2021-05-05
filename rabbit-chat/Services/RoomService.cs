using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Models;
using rabbit_chat.Models.Requests;

namespace rabbit_chat.Services
{
    public static class RoomService
    {
        public static void OpenPersonalRoom(PersonalRoomRequest request)
        {
            using var db = new RabbitChatContext();

            /*
            var personalRoom = db.Rooms.Include(x => x.Users).FirstOrDefault(room => room.Users.Count(user =>
                user.RabbitUserId == request.FriendId || user.RabbitUserId == request.RequestUserId) == 2);
            
            if (personalRoom == null)
            {
                CreatePersonalRoom(request);
            }
            
            return personalRoom;
            */
        }

        public static void CreatePersonalRoom(PersonalRoomRequest request)
        {
            using var db = new RabbitChatContext();
            /*
            db.Rooms.Add(new Room
            {
                RoomName = "test",
                Users = new List<RabbitUser>
                {
                    db.RabbitUsers.Single(user => user.RabbitUserId == request.RequestUserId), 
                    db.RabbitUsers.Single(user => user.RabbitUserId == request.FriendId)
                }
            });
            */
            db.SaveChanges();
        }
    }
}