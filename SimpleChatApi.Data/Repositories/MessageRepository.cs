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
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatApiContext context;

        public MessageRepository(ChatApiContext context)
        {
            this.context = context;
        }

        public MessageEntity Add(MessageEntity entity)
        {
            context.Messages.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(MessageEntity entity)
        {
            context.Messages.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var message = context.Messages.Find(id);
            if (message != null)
            {
                context.Messages.Remove(message);
                context.SaveChanges();
            }
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            return context.Messages.ToList();
        }

        public MessageEntity GetById(int id)
        {
            return context.Messages.Find(id);
        }

        public void Update(MessageEntity entity)
        {
            var message = context.Messages.Find(entity.Id);
            if (message != null)
            {
                context.Messages.Update(entity);
                context.SaveChanges();

            }
        }
    }
}
