using System.Collections.Generic;

namespace NetcoreChat.Dtos
{
    public class RoomDto
    {
        public RoomDto()
        {
            Messages = new List<MessageDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Status { get; set; }
        public string LastConnectionTime { get; set; }

        public IList<MessageDto> Messages { get; set; }
    }
}
