using SimpleChatApi.Data.Data;
using SimpleChatApi.Data.Entities;
using SimpleChatApi.Data.Repositories;
using SimpleChatApi.Data.Repositories.Interfaces;
using SimpleChatApi.Logic.Models;
using SimpleChatApi.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Logic.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository repository;

        public MessageService(IMessageRepository repository)
        {
            this.repository = repository;
        }

        public AbstractModel Add(AbstractModel model)
        {
            var message = (MessageModel)model;
            repository.Add(new MessageEntity()
            {
                Id = message.Id,
                ChatId = message.ChatId,
                UserId = message.UserId,
                Text = message.Text,
                TimeStamp = message.TimeStamp,
            });
            return message;
        }

        public void Delete(int id)
        {
            repository.DeleteById(id);
        }

        public IEnumerable<AbstractModel> GetAll()
        {
            return repository.GetAll().Select(m => new MessageModel(m.Id, m.ChatId, m.UserId, m.Text, m.TimeStamp)).ToList();
        }

        public AbstractModel GetById(int id)
        {
            var message = repository.GetById(id);
            return new MessageModel(message.Id, message.ChatId, message.UserId, message.Text, message.TimeStamp);
        }

        public void Update(AbstractModel model)
        {
            var message = (MessageModel)model;
            repository.Update(new MessageEntity()
            {
                Id = message.Id,
                ChatId = message.ChatId,
                UserId = message.UserId,
                Text = message.Text,
                TimeStamp = message.TimeStamp,
            });
        }
    }
}
