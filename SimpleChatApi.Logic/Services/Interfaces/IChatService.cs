using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Logic.Services.Interfaces
{
    public interface IChatService : ICrud
    {
        void Delete(string userId, int id);
    }
}
