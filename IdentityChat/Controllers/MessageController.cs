using Chat.BusinessLayer.Abstract;
using IdentityChat.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }
        // Sohbet Sayfası 
        public async Task<IActionResult> Chat(string userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var messages = await _messageService.TGetMessagesBetweenAsync(currentUser.Id, userId);
            var chatWith = await _userManager.FindByIdAsync(userId);
            ViewBag.ChatWithId = userId;
            ViewBag.ChatWithName = chatWith?.UserName;

            return View(messages);

        }
        //MesajGönderme
        [HttpPost]
        public async Task<IActionResult> SendMessage(string receiverId, string content)
        {
            var sender = await _userManager.GetUserAsync(User);

            var message = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiverId,
                Content = content,
                DateSent = DateTime.Now

            };
            await _messageService.TAddMessageAsync(message);
            return RedirectToAction("Chat", new { userId = receiverId });
        }
        public async Task<IActionResult> UserListPartial()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var users = _userManager.Users.Where(x => x.Id != currentUser.Id).ToList();
            return PartialView("UserListPartial", users);
        }

    }
}

