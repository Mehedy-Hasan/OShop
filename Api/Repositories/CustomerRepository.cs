using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;
using Repositories.Contracts;

namespace Repositories
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepository
    {
        public override bool Add(Customer entity)
        {
            //application logic
            if (true)
            {
                
            }
            else
            {
                
            }

            return base.Add(entity);
        }
    }
}
