using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    interface IRepository<Entity,UnitEntity> where Entity: class where UnitEntity:class
    {
        Task Create(UnitEntity item);
        Task<UnitEntity> Read(int id);
        void Update(UnitEntity item);
        Task Delete(int id);
        Task<IEnumerable<UnitEntity>> GetList();
    }
}
