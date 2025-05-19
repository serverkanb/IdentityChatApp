using IdentityChat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DataAccessLayer.Abstract
{
    public interface IMessageDal
    {
        Task<List<Message>> GetMessagesBetweenAsync(string user1Id, string user2Id);
        Task AddMessageAsync(Message message);
    }
}
