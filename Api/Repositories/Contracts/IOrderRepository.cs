using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Models.ViewModels;

namespace Repositories.Contracts
{
    public interface IOrderRepository:IRepository<Order>
    {
        ICollection<VWOrderInfo> GetAllOrderSummary();
        Order GetByOrderDetail(int orderId);
        ICollection<Order> GetByOrder(int id);
    }
}
