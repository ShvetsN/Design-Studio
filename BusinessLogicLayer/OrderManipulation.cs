using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace BusinessLogicLayer
{
    public class OrderManipulation
    {
        private UnitOfWorkPattern unitOfWork;

        public OrderManipulation()
        {
            unitOfWork = new UnitOfWorkPattern();
            // Mapper.Initialize(c => c.CreateMap<OrderView, UnitOrder>().ReverseMap());
        }
        public async Task Add(OrderView orderView)
        {
            var order = Mapper.Map<UnitOrder>(orderView);
            await unitOfWork.Orders.Create(order);
            unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Orders.Delete(id);
            unitOfWork.Save();
        }

        public async Task<OrderView> Get(int id)
        {
           var item =  await unitOfWork.Orders.Read(id);
            return Mapper.Map<OrderView>(item);
        }

        public async Task<List<OrderView>> GetAll()
        {
           var items = await unitOfWork.Orders.GetList();
           return Mapper.Map<List<OrderView>>(items);
        }
    }
}
