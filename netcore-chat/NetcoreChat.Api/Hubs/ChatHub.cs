using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using NetcoreChat.Dtos;
using NetcoreChat.Services;

namespace NetcoreChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserService _userService;
        private readonly IRoomService _roomService;

        public ChatHub(UserService userService, IRoomService roomService)
        {
            _userService = userService;
            _roomService = roomService;
        }

        public override Task OnConnectedAsync()
        {
            var user = UserService.Connect(Context.ConnectionId);

            Clients.Caller.SendAsync("connectUser", user);
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string message, int roomId)
        {
            var room = _roomService.GetById(roomId);
            var messageDto = new MessageDto
            {
                RoomId = room.Id,
                AuthorName = Context.ConnectionId,
                Date = DateTime.Now,
                Message = message
            };

            room.Messages.Add(messageDto);

            await Clients.Group(room.Name).SendAsync("DisplayMessage", messageDto);
        }

        public async Task<RoomDto> JoinToRoom(int roomId)
        {
            var room = _roomService.GetById(roomId);
            var user = _userService.GetUserByConnectionId(Context.ConnectionId);
            user.Rooms.Add(room);

            await Groups.AddToGroupAsync(Context.ConnectionId, room.Name);

            return room;
        }
    }
}
