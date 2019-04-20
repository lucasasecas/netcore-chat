using System;

namespace NetcoreChat.Dtos
{
    public class MessageDto
    {
        public string AuthorName { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int RoomId { get; set; }
    }
}
