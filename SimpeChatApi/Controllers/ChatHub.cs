using Microsoft.AspNetCore.SignalR;
using SimpleChatApi.Logic.Models;
using SimpleChatApi.Logic.Services.Interfaces;

namespace SimpeChatApi.Controllers
{
    public class ChatHub : Hub
    {
        private readonly ICrud service;

        public ChatHub(ICrud messageService)
        {
            this.service = messageService;
        }

        public async Task SendMessage(int chatId, string userId, string message)
        {
            service.Add(new MessageModel(service.GetAll().Count() + 1, chatId, userId, message, DateTime.Now));
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", userId, message);
        }

        public async Task JoinChat(int chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        public async Task LeaveChat(int chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        }
    }
}
