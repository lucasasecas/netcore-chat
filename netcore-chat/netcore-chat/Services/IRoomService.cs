using System.Collections.Generic;
using NetcoreChat.Dtos;
using NetcoreChat.Models;

namespace NetcoreChat.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomDto> GetAll(string name);
        RoomDto GetById(int id);
        MessageDto AddMessage(int id, MessageDto message);
    }
}
