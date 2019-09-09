using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BLL.Contracts
{
    public interface IProductManager:IManager<Product>
    {
        
        ICollection<Product> GetByYear(int year);

        ICollection<Product> GetByCategory(int categoryId);
    }
}
