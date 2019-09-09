using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;
using Repositories.Base;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        public ICollection<VWOrderInfo> GetAllOrderSummary()
        {
            return db.VwOrderInfos.ToList();
        }

        public override Order GetById(int id)
        {
            return db.Orders
                .Include(c => c.OrderDetails)
                .ThenInclude(c=>c.Product)
                .FirstOrDefault(c => c.Id == id);
        }

        public Order GetByOrderDetail(int orderId)
        {
            return db.Orders
                .Include(c=>c.OrderDetails)
                    .ThenInclude(c=>c.Product)
                .FirstOrDefault(c=>c.Id==orderId);
        }

        public override ICollection<Order> GetAll()
        {
            return db.Orders.Include(c => c.OrderDetails).ToList();
        }

        
    }
}
