//using ChatBot.Repositories.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace ChatBot.Controllers
//{
//        [Route("api/[controller]")]
//        [ApiController]
//        public class ChatTestController : ControllerBase
//        {
//            private readonly IChatApiClient _chatApiClient;

//            public ChatTestController(IChatApiClient chatApiClient)
//            {
//                _chatApiClient = chatApiClient;
//            }

//            [HttpPost("test")]
//            public async Task<IActionResult> Test([FromBody] ChatTestRequest request)
//            {
//                var answer = await _chatApiClient.SendMessageAsync(request.Message);
//                return Ok(new { answer });
//            }
//        }

//        public record ChatTestRequest(string Message);
    
//}
