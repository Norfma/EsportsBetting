using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBase.Interfaces
{
    public interface IGetterService<TEntity, TKey> where TEntity : IEntity<TKey>, new()
    {
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
    }
}
