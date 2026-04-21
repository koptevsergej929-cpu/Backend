using ChatBot.Commands;
using ChatBot.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace ChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly TelegramUpdateProcessor _processor;
        public UpdateController(TelegramUpdateProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TelegramUpdate update)
        {
            if (!ModelState.IsValid)
                return Ok();

            _ = Task.Run(() => _processor.HandleAsync(update));
            return Ok();

        }

        [HttpPost("Test")]
        public async Task<IActionResult> Test([FromBody] TelegramUpdate update)
        {
            _ = Task.Run(() => _processor.HandleAsync(update));
            return Ok();

        }
    }
}
