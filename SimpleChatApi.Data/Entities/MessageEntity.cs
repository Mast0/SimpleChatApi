using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Data.Entities
{
    public class MessageEntity : BaseEntity
    {
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public ChatEntity Chat { get; set; }
    }
}
