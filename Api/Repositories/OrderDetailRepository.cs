using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderDetailRepository:Repository<OrderDetail>,IOrderDetailRepository
    {
        public ICollection<OrderDetail> getByOrderId(int id)
        {
            return db.OrderDetails
                .Where(c => c.OrderId == id)
                .Include(c=>c.Product)
                .Include(c=>c.Order)
                .ToList();
        }
    }
}
