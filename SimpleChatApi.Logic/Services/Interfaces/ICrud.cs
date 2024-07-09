using SimpleChatApi.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Logic.Services.Interfaces
{
    public interface ICrud
    {
        IEnumerable<AbstractModel> GetAll();
        AbstractModel GetById(int id);
        AbstractModel Add(AbstractModel model);
        void Update(AbstractModel model);
        void Delete(int id);
    }
}
