using Microsoft.EntityFrameworkCore;
using SimpleChatApi.Data.Data;
using SimpleChatApi.Data.Entities;
using SimpleChatApi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatApiContext context;

        public ChatRepository(ChatApiContext context)
        {
            this.context = context;
        }

        public ChatEntity Add(ChatEntity entity)
        {
            context.Chats.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(ChatEntity entity)
        {
            context.Chats.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var chat = context.Chats.Find(id);
            if (chat != null)
            {
                context.Chats.Remove(chat);
                context.SaveChanges();
            }
        }

        public IEnumerable<ChatEntity> GetAll()
        {
            return context.Chats.ToList();
        }

        public ChatEntity GetById(int id)
        {
            return context.Chats.Include(c => c.Messages).FirstOrDefault(c => c.Id == id);
        }

        public void Update(ChatEntity entity)
        {
            var chat = context.Chats.Find(entity.Id);
            if (chat != null)
            {
                context.Chats.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
