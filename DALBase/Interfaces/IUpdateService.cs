using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBase.Interfaces
{
    public interface IUpdateService<TEntity> where TEntity :  new()
    {
        bool Update(TEntity entity);
    }
}
