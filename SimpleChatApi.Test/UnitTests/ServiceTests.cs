using Moq;
using SimpleChatApi.Data.Data;
using SimpleChatApi.Data.Entities;
using SimpleChatApi.Data.Repositories.Interfaces;
using SimpleChatApi.Logic.Models;
using SimpleChatApi.Logic.Services;
using SimpleChatApi.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SimpleChatApi.Test.Tests
{
    public class ServiceTests
    {
        private readonly Mock<IChatRepository> chatRepoMock;
        private readonly Mock<IMessageRepository> messageRepoMock;

        private readonly IChatService chatService;
        private readonly IMessageService messageService;

        public ServiceTests()
        {
            chatRepoMock = new Mock<IChatRepository>();
            messageRepoMock = new Mock<IMessageRepository>();

            chatService = new ChatService(chatRepoMock.Object);
            messageService = new MessageService(messageRepoMock.Object);
        }

        [Fact]
        public void CreateChat_ShouldReturnChat()
        {
            var chatName = "Test Chat";
            var createdBy = "User1";

            var chat = new ChatEntity()
            {
                Id = 1,
                Name = chatName,
                CreatedBy = createdBy,
                Messages = new List<MessageEntity>()
            };

            chatRepoMock.Setup(repo => repo.Add(It.IsAny<ChatEntity>())).Returns(chat);

            var res = (ChatModel)chatService.Add(new ChatModel(chat.Id, chat.Name, chat.CreatedBy));

            Assert.NotNull(res);
            Assert.Equal(chatName, res.Name);
            Assert.Equal(createdBy, res.CreatedBy);
        }

        [Fact]
        public void CreateMessage_ShouldReturnMessage()
        {
            var chatId = 1;
            var userId = "1";
            var text = "Test Message";
            var timeStamp = DateTime.Now;

            var message = new MessageEntity()
            {
                Id = 1,
                ChatId = chatId,
                UserId = userId,
                Text = text,
                TimeStamp = timeStamp
            };

            messageRepoMock.Setup(repo => repo.Add(It.IsAny<MessageEntity>())).Returns(message);

            var res = (MessageModel)messageService.Add(new MessageModel(message.Id, message.ChatId, message.UserId, message.Text, message.TimeStamp));

            Assert.NotNull(res);
            Assert.Equal(chatId, res.ChatId);
            Assert.Equal(userId, res.UserId);
            Assert.Equal(text, res.Text);
            Assert.Equal(timeStamp, res.TimeStamp);
        }
    }
}
