using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Logic.Models
{
    public class MessageModel : AbstractModel
    {
        public MessageModel(int id, int chatId, string userId, string text, DateTime timeStamp)
            : base(id)
        {
            this.ChatId = chatId;
            this.UserId = userId;
            this.Text = text;
            this.TimeStamp = timeStamp;
        }
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public ChatModel Chat { get; set; }
    }
}
