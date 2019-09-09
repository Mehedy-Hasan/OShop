using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Models.ViewModels;

namespace BLL.Contracts
{
    public interface IOrderManager:IManager<Order>
    {
        ICollection<VWOrderInfo> GetAllOrderSummary();
        Order GetByOrderDetails(int orderId);
        ICollection<Order> GetByOrder(int id);
    }
}
