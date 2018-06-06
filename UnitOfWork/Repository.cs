using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer;


namespace UnitOfWork
{
    public class Repository<Entity,UnitEntity> : IRepository<Entity,UnitEntity>
         where Entity : class  where UnitEntity:class
    {
        DesignContext context;

        public Repository(DesignContext context)
        {
            this.context = context;
            //Mapper.Initialize(c => c.CreateMap<Entity, UnitEntity>().ReverseMap());
        }

        public async Task Create(UnitEntity item)
        {
            var value = Mapper.Map<Entity>(item);
            await context.Set<Entity>().AddAsync(value);
        }

        public async Task Delete(int id)
        {
            var item = await context.Set<Entity>().FindAsync(id);
            context.Set<Entity>().Remove(item);
            
        }

        public void Update(UnitEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public async Task<UnitEntity> Read(int id)
        {
            var value = await context.Set<Entity>().FindAsync(id);
            return Mapper.Map<UnitEntity>(value);        }
             
        public async Task<IEnumerable<UnitEntity>> GetList()
        {
            var value = await context.Set<Entity>().ToListAsync();
            return Mapper.Map<IEnumerable<UnitEntity>>(value);
        }
    }
}
