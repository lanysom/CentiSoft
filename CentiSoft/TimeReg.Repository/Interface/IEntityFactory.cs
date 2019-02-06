using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository.Interface
{
    public interface IEntityFactory<TEntity>
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Create();
    }
}
