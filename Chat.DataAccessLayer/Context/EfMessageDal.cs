using Chat.DataAccess.Abstract;
using Chat.DataAccess.Context;
using Chat.DataAccessLayer.Abstract;
using Chat.DataAccessLayer.Repositories;
using IdentityChat.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DataAccessLayer.Context
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly AppDbContext _context;
        public EfMessageDal(AppDbContext appDbContext, AppDbContext context) : base(appDbContext)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessagesBetweenAsync(string user1Id, string user2Id)
        {
          return await _context.Messages.Where(x=>(x.SenderId == user1Id&&x.ReceiverId== user2Id) ||
          (x.SenderId == user2Id && x.ReceiverId == user1Id))
                .OrderBy(m => m.DateSent)
                .ToListAsync();
        }
    }
}
