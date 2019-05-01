using Microsoft.AspNetCore.Mvc;
using NetcoreChat.Dtos;
using NetcoreChat.Extensions;
using NetcoreChat.Services;
using System.Threading.Tasks;

namespace NetcoreChat.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ChannelsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IChannelService _channelService;

        public ChannelsController(IRoomService roomService, IChannelService channelService)
        {
            _roomService = roomService;
            _channelService = channelService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] double[] position)
        {
            return Ok(_channelService.GetNearbyChannels(position));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = _roomService.GetById(id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChannelDto channel)
        {
            var newChannel = await _channelService.CreateAsync(channel.ToModel());

            if (newChannel == null)
                return BadRequest("Unable to create new channel");

            return Ok(newChannel.ToDto());
        }

        [HttpGet("{id}/messages")]
        public IActionResult GetMessages(int id)
        {
            var room = _roomService.GetById(id);

            if (room == null)
                return NotFound();

            return Ok(room.Messages);
        }

        [HttpPost("{id}/messages")]
        public IActionResult AddMessages(int id, [FromBody] MessageDto message)
        {
            var newMessage = _roomService.AddMessage(id, message);

            if (newMessage == null)
                return NotFound();

            return Created("", newMessage);
        }
    }
}