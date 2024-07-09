using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleChatApi.Data.Data;
using SimpleChatApi.Data.Entities;
using SimpleChatApi.Data.Repositories;
using SimpleChatApi.Data.Repositories.Interfaces;
using SimpleChatApi.Logic.Models;
using SimpleChatApi.Logic.Services.Interfaces;

namespace SimpleChatApi.Logic.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository repository;

        public ChatService(IChatRepository repository)
        {
            this.repository = repository;
        }

        public AbstractModel Add(AbstractModel model)
        {
            var chat = (ChatModel)model;
            repository.Add(new ChatEntity()
            {
                Id = chat.Id,
                Name = chat.Name,
                CreatedBy = chat.CreatedBy,
            });
            return chat;
        }

        public void Delete(string userId, int id)
        {
            var chat = repository.GetById(id);
            if (chat.CreatedBy != userId)
            {
                throw new UnauthorizedAccessException("There are no permissions to do the operation");
            }
            repository.DeleteById(id);
        }

        public void Delete(int id)
        {
            repository.DeleteById(id);
        }

        public IEnumerable<AbstractModel> GetAll()
        {
            return repository.GetAll().Select(c => new ChatModel(c.Id, c.Name, c.CreatedBy)).ToList();
        }

        public AbstractModel GetById(int id)
        {
            var chat = repository.GetById(id);
            return new ChatModel(chat.Id, chat.Name, chat.CreatedBy);
        }

        public void Update(AbstractModel model)
        {
            var chat = (ChatModel)model;
            repository.Update(new ChatEntity()
            {
                Id = chat.Id,
                Name = chat.Name,
                CreatedBy = chat.CreatedBy,
            });
        }
    }
}
