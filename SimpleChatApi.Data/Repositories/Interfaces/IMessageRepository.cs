using SimpleChatApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Data.Repositories.Interfaces
{
    public interface IMessageRepository : IRepository<MessageEntity>
    {
    }
}
