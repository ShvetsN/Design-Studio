using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace BusinessLogicLayer
{
    public class WorkManipulation
    {
        private readonly UnitOfWorkPattern unitOfWork;

        public WorkManipulation()
        {
            unitOfWork = new UnitOfWorkPattern();
        }

        public async Task Add(WorkView work)
        {
            var item = Mapper.Map<UnitWork>(work);
            await unitOfWork.Works.Create(item);
            unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Works.Delete(id);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<WorkView>> GetAll()
        {
            var list = await unitOfWork.Works.GetList();
            return Mapper.Map<IEnumerable<WorkView>>(list);
        }
    }
}
