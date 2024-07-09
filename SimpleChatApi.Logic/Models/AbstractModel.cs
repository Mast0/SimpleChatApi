using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Logic.Models
{
    public class AbstractModel
    {
        public AbstractModel(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
