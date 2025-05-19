using IdentityChat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<List<Message>> TGetMessagesBetweenAsync(string user1Id, string user2Id);
        Task TAddMessageAsync(Message message);
    }
}
