using System.Linq;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Models;
using rabbit_chat.Models.Requests;

namespace rabbit_chat.Services
{
    public static class RoomService
    {
        public static Room OpenPersonalRoom(SimpleOpenPersonalRoomRequest soprRequest)
        {
            using var db = new RabbitChatContext();

            var personalRoom = db.Rooms.Include(x => x.Users).FirstOrDefault(room => room.Users.Count(user =>
                user.RabbitUserId == soprRequest.FriendId || user.RabbitUserId == soprRequest.RequestUserId) == 2);

            return personalRoom;
        }
    }
}