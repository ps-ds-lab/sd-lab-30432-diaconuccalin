using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
