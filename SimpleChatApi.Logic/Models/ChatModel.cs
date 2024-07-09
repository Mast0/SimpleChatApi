using SimpleChatApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Logic.Models
{
    public class ChatModel : AbstractModel
    {
        public ChatModel(int id, string name, string createdby)
            : base(id)
        {
            this.Name = name;
            this.CreatedBy = createdby;
        }

        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<MessageModel> Messages { get; set; }
    }
}
