using System.Collections;
using System.Collections.Generic;
using NetcoreChat.Models;

namespace NetcoreChat.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            Rooms = new List<RoomDto>();
        }

        public UserStatus Status { get; internal set; }
        public string UserName { get; set; }
        public IList<RoomDto> Rooms { get; set; }
    }
}
