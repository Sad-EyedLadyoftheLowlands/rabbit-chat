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
    public class UserController : ControllerBase
    {
        // ***** GET REQUESTS *****
        
        [HttpGet]
        public List<RabbitUser> GetFriends([FromBody] int userId)
        {
            using var db = new RabbitChatContext();

            var p = db.RabbitUsers.Include(x => x.Friends).Single(user => user.RabbitUserId == userId);
            return p.Friends.ToList();
        }
        
        [HttpGet("singleuser")]
        public RabbitUser GetUser([FromBody] int userId)
        {
            using var db = new RabbitChatContext();
            return db.RabbitUsers.Include(x => x.Friends).Single(user => user.RabbitUserId == userId);
        }
        
        // ***** END OF GET REQUESTS *****
        
        // ***** POST REQUESTS *****

        [HttpPost("createuser")]
        public void CreateUser(CreateUserRequest createUserRequest)
        {
            using var db = new RabbitChatContext();
            db.Add(new RabbitUser
            {
                Username = createUserRequest.Username,
                Password = createUserRequest.Password,
                Alias = createUserRequest.Alias
            });
            db.SaveChanges();
        }

        // TODO: Validation that friend does not exist
        [HttpPost("addfriend")]
        public void AddFriend(AddFriendRequest addFriendRequest)
        {
            using var db = new RabbitChatContext();
            
            var sendingUser = db.RabbitUsers.Include(x => x.Friends)
                .Single(user => user.RabbitUserId == addFriendRequest.SendingUserId);
            var requestedUser = db.RabbitUsers.Include(x => x.Friends)
                .Single(user => user.Username == addFriendRequest.RequestedFriendUsername);
            
            sendingUser.Friends.Add(requestedUser);
            db.SaveChanges();
        }
        
        // ***** END OF POST REQUESTS *****
    }
}