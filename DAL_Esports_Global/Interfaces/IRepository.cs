using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>, new()
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        TKey Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TKey id);
    }
}
