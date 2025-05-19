

using Microsoft.AspNetCore.Identity;

namespace IdentityChat.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }

        public DateTime? LastSeen { get; set; }

        public string? LastMessageContent { get; set; }
    }
}
