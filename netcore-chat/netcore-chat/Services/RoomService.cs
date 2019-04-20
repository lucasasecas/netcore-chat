using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetcoreChat.Dtos;

namespace NetcoreChat.Services
{
    public class RoomService : IRoomService
    {
        private static readonly List<RoomDto> Rooms = new List<RoomDto>
        {
            new RoomDto
                {
                    Id = 1,
                    AvatarUrl = "https://s3-us-west-2.amazonaws.com/s.cdpn.io/195612/chat_avatar_01.jpg",
                    Name = "General",
                    Status = "online",
                    Messages = new List<MessageDto>()
                },
                new RoomDto
                {
                    Id = 2,
                    AvatarUrl = "https://s3-us-west-2.amazonaws.com/s.cdpn.io/195612/chat_avatar_02.jpg",
                    Name = "Aiden Chavez",
                    Status = "offline",
                    LastConnectionTime = "left 7 mins ago"
                }
            };

        public IEnumerable<RoomDto> GetAll(string name)
        {
            var rooms = Rooms.AsQueryable<RoomDto>();

            if (!string.IsNullOrEmpty(name))
                rooms = rooms.Where(x => x.Name.Contains(name));

            return rooms.ToList();
        }

        public RoomDto GetById(int id)
        {
            foreach (var room in Rooms)
            {
                if (room.Id == id)
                    return room;
            }

            return null;
        }

        public MessageDto AddMessage(int id, MessageDto message)
        {
            var room = GetById(id);

            if (room == null)
                return null;

            message.Date = DateTime.Now;
            room.Messages.Add(message);

            return message;
        }
    }
}
