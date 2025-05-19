using Chat.BusinessLayer.Abstract;
using Chat.DataAccess.Abstract;
using Chat.DataAccessLayer.Abstract;
using IdentityChat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BusinessLayer.Concrete
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageRepository, IGenericDal<Message> genericDal)
            : base(genericDal)
        {
            _messageDal = messageRepository;
        }

        public async Task<List<Message>> TGetMessagesBetweenAsync(string user1Id, string user2Id)
        {
            return await _messageDal.GetMessagesBetweenAsync(user1Id, user2Id);
        }

        public async Task TAddMessageAsync(Message message)
        {
            await _messageDal.AddMessageAsync(message);
        }
    }
}
