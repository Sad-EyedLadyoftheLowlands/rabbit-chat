using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace rabbit_chat.Models
{
    public class RabbitChatContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RabbitUser> RabbitUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RabbitUserRoom> RabbitUserRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=rabbit-chat.db");
    }
    
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Message
    {
        public int MessageId { get; set; }
        public int RabbitUserId { get; set; }
        public int RoomId { get; set; }
        public DateTime? TimeSent { get; set; }
        public string MessageContent { get; set; }
    }

    public class RabbitUser
    {
        public int RabbitUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Alias { get; set; }
        
        public ICollection<RabbitUser> Friends { get; set; }
    }

    /*
    public class Friend
    {
        public int Friend
    }
    */
    
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        
        public ICollection<RabbitUser> Users { get; set; }
        
        /*
        TODO: How do you define a getter?
        return Room.Users.Length() < 2 
        public bool IsPersonal { get; }
        */
    }

    public class RabbitUserRoom
    {
        public int RabbitUserRoomId { get; set; }
        public int RoomId { get; set; }
        public int RabbitUserId { get; set; }
    }
    
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Test
    {
        public int TestId { get; set; }
        public string TestString { get; set; }
    }
}