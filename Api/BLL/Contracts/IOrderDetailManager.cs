using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BLL.Contracts
{
    public interface IOrderDetailManager:IManager<OrderDetail>
    {
        ICollection<OrderDetail> getByOrderId(int id);
    }
}
