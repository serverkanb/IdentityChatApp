using Chat.BusinessLayer.Abstract;
using IdentityChat.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public UserListViewComponent(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            // Kullanıcının son görülme zamanını güncelle
            currentUser.LastSeen = DateTime.Now;

            await _userManager.UpdateAsync(currentUser);
            // Diğer kullanıcıları getir
            var users = await _userManager.Users
                .Where(u => u.Id != currentUser.Id)
                .OrderByDescending(u => u.LastSeen)
                .ToListAsync();

            // Her kullanıcı için son mesaj
            foreach (var user in users)
            {
                var lastMessage = await _messageService.TGetMessagesBetweenAsync(currentUser.Id, user.Id);
                var latest = lastMessage.OrderByDescending(m => m.DateSent).FirstOrDefault();

                user.LastMessageContent = latest?.Content;
            }

            return View(users);
        }
    }
}
