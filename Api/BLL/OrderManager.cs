using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Models.ViewModels;
using Repositories.Contracts;

namespace BLL
{
    public class OrderManager:Manager<Order>,IOrderManager
    {
        private IOrderRepository _repository;
        public OrderManager(IOrderRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<VWOrderInfo> GetAllOrderSummary()
        {
            return _repository.GetAllOrderSummary();
        }

        public Order GetByOrderDetails(int orderId)
        {
            return _repository.GetByOrderDetail(orderId);
        }

        public ICollection<Order> GetByOrder(int id)
        {
            return _repository.GetByOrder(id);
        }
    }
}
