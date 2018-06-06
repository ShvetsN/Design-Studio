using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace UnitOfWork
{
    public class UnitOfWorkPattern
    {
        private readonly DesignContext context = new DesignContext();
        private Repository<Order,UnitOrder> _orderRepository;
        private Repository<Work,UnitWork> _workRepository;

        public Repository<Order,UnitOrder> Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new Repository<Order,UnitOrder>(context);
                return _orderRepository;
            }
        }

        public Repository<Work,UnitWork> Works
        {
            get
            {
                if (_workRepository == null)
                    _workRepository = new Repository<Work,UnitWork>(context);
                return _workRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
