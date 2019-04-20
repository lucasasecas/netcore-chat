using Microsoft.AspNetCore.Mvc;
using NetcoreChat.Dtos;
using NetcoreChat.Services;

namespace NetcoreChat.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string name)
        {
            return Ok(_roomService.GetAll(name));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = _roomService.GetById(id);

            if (room == null)
                return NotFound();

            return Ok(room);
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