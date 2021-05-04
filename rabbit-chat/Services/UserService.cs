using System.Linq;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Models;

namespace rabbit_chat.Services
{
    public static class UserService
    {
        public static RabbitUser GetSingleUser(int userId)
        {
            using var db = new RabbitChatContext();
            return db.RabbitUsers.Include(user => user.Friends).Single(user => user.RabbitUserId == userId);
        }
    }
}