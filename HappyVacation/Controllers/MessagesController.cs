using HappyVacation.Repositories.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessages([FromQuery] string withUserId)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = claimsPrincipal.FindFirst("id").Value;

                var result = await _messageRepository.GetMessages(userId, withUserId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("for-guests")]
        public async Task<IActionResult> GetMessagesForGuest([FromQuery] string userId, string withUserId)
        {
            try
            {
                var result = await _messageRepository.GetMessages(userId, withUserId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("for-providers")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> GetMessagesForProvider([FromQuery]string withUserId)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);
                var result = await _messageRepository.GetMessagesForProvider(userId, withUserId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("me/chat-users")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> GetUserChatList()
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _messageRepository.GetUserChatList(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpDelete("me/conversation")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> DeleteConversation([FromQuery] string withUserId)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _messageRepository.DeleteConversation(userId, withUserId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }


        // image upload endpoint
        [HttpPost("images")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            try
            {
                var imageUrl = await _messageRepository.UploadImage(image);

                return Ok(new { ImageUrl = imageUrl });
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }
    }
}
