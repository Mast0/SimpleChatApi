using SimpleChatApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void Update(TEntity entity);
    }
}
