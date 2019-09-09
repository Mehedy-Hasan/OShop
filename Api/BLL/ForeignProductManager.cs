using System;
using System.Collections.Generic;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories;
using Repositories.Base;

namespace BLL
{
    public class ForeignProductManager:Manager<Product>,IProductManager
    {
        public ForeignProductManager() : base(new ProductRepository())
        {
        }

        public override bool Add(Product entity)
        {
            //foreign product add policy
            if (true)
            {
                //
            }
            else
            {
                
            }
            return base.Add(entity);
        }

        public ICollection<Product> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
