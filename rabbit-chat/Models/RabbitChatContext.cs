using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rabbit_chat.Models
{
    public class RabbitChatContext : DbContext
    {
        public DbSet<RabbitUser> RabbitUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        // ***** TESTING FOR ACTIUM CONVERSION TO EF CORE *****
        
        public DbSet<ActInfection> ActInfections { get; set; }
        public DbSet<ActWorkflow> ActWorkflows { get; set; }
        public DbSet<ActBed> ActBeds { get; set; }
        public DbSet<ActRoom> ActRooms { get; set; }
        public DbSet<ActUnit> ActUnits { get; set; }
        
        // public RabbitChatContext(DbContextOptions<RabbitChatContext> options) : base(options) {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=rabbit-chat.db");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RabbitUserRoom>().HasKey(x => new {x.RoomId, x.RabbitUserId});
        }
    }

    public class Message
    {
        public int MessageId { get; set; }
        public int RabbitUserId { get; set; }
        public DateTime? TimeSent { get; set; }
        public string MessageContent { get; set; }
        
        public int RoomId { get; set; }
    }

    public class RabbitUser
    {
        public int RabbitUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Alias { get; set; }
        
        public ICollection<RabbitUserRoom> RoomLink { get; set; }
        public ICollection<RabbitUser> Friends { get; set; }
    }
    
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public ICollection<RabbitUserRoom> RabbitUserLink { get; set; }
    }

    public class RabbitUserRoom
    {
        public int RabbitUserId { get; set; }
        public int RoomId { get; set; }
        // public byte Order { get; set; }
        
        public RabbitUser RabbitUser { get; set; }
        public Room Room { get; set; }
    }
    
    // ***** TESTING FOR ACTIUM CONVERSION TO EF CORE *****
    public class ActBed
    {
        public int ActBedId { get; set; }
        public string ActBedName { get; set; }
        [NotMapped]
        public ActRoom ActRoom { get; set; }
        [NotMapped]
        public ActUnit ActUnit { get; set; }
        
        public ActInfection ActBedInfection { get; set; }
        public ActWorkflow ActBedWorkflow { get; set; }
    }

    public class ActUnit
    {
        public int ActUnitId { get; set; }
        public string ActUnitName { get; set; }
        
        public ICollection<ActRoom> ActUnitRooms { get; set; }
        
    }

    public class ActInfection
    {
        public int ActInfectionId { get; set; }
        public string ActInfectionName { get; set; }
    }

    public class ActRoom
    {
        public int ActRoomId { get; set; }
        public string ActRoomName { get; set; }
        
        public ICollection<ActBed> ActRoomBeds { get; set; }
    }

    public class ActWorkflow
    {
        public int ActWorkflowId { get; set; }
        public string ActWorkflowText { get; set; }
    }
    
    // ***** END OF TESTING FOR ACTIUM CONVERSION TO EF CORE *****
}