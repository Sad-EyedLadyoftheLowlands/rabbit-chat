using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rabbit_chat.Models;

namespace rabbit_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActiumController : ControllerBase
    {
        [HttpPost("addroom")]
        public void AddRoom()
        {
            using var db = new RabbitChatContext();
            var unit = db.ActUnits.Include(u => u.ActUnitRooms).First();
            unit.ActUnitRooms.Add(new ActRoom{ ActRoomName = "newroomtestingthisisinaunit"});
            db.SaveChanges();
        }

        [HttpPost("addbed")]
        public void AddBed()
        {
            using var db = new RabbitChatContext();
            var room = db.ActRooms.Include(r => r.ActRoomBeds).First();
            room.ActRoomBeds.Add(new ActBed
            {
                ActBedName = "firstbed"
            });
            db.SaveChanges();
        }

        [HttpGet]
        public ActUnit GetUnitWithEverything()
        {
            using var db = new RabbitChatContext();
            
            
            var totalUnit = db.ActUnits.Include(u => u.ActUnitRooms).First();
            var finalUnit = new ActUnit
            {
                ActUnitId = totalUnit.ActUnitId,
                ActUnitName = totalUnit.ActUnitName,
                ActUnitRooms = new List<ActRoom>()
            };
            foreach (var room in totalUnit.ActUnitRooms)
            {
                finalUnit.ActUnitRooms.Add(db.ActRooms.Include(v => v.ActRoomBeds).Single(z => z.ActRoomId == room.ActRoomId));
            }
            return finalUnit;
            
            
            /*
            var totalUnit = db.ActUnits.Include(u => u.ActUnitRooms)
                .Include(z => z.)
                .First();

            
            
            return new ActUnit
            {
                A
            }
            */
        }
    }
}