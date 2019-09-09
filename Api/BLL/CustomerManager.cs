using System;
using System.Collections.Generic;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories;
using Repositories.Contracts;


namespace BLL
{
    public class CustomerManager:Manager<Customer>,ICustomerManager
    {
        private ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository repository):base(repository)
        {
            _customerRepository = repository;
        }
       
    }
}
