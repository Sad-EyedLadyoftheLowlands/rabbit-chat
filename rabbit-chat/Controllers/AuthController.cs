using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using rabbit_chat.Models;
using rabbit_chat.Models.Requests;

namespace rabbit_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPut]
        public RabbitUser SimpleSignIn(SimpleSignInRequest simpleSignInRequest)
        {
            try
            {
                using var db = new RabbitChatContext();
                return db.RabbitUsers.Single(user =>
                    user.Username == simpleSignInRequest.Username && user.Password == simpleSignInRequest.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}