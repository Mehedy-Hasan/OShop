using System;
using System.Collections.Generic;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories;
using Repositories.Contracts;

namespace BLL
{
    public class OrderDetailManager:Manager<OrderDetail>,IOrderDetailManager
    {
        private IOrderDetailRepository _repository;
        public OrderDetailManager(IOrderDetailRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<OrderDetail> getByOrderId(int id)
        {
            return _repository.getByOrderId(id);
        }
    }
}
