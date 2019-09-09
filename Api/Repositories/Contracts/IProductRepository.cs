using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepository<Product>
    {
        ICollection<Product> GetByCategory(int categoryId);
    }
}
