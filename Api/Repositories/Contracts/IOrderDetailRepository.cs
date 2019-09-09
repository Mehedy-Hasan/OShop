using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.Contracts
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
        ICollection<OrderDetail> getByOrderId(int id);
    }
}
