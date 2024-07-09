using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Data.Entities
{
    public class ChatEntity : BaseEntity
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<MessageEntity> Messages { get; set; }
    }
}
