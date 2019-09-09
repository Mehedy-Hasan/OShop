using System;
using System.Collections.Generic;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories;
using Repositories.Base;
using Repositories.Contracts;

namespace BLL
{
    public class ProductManager:Manager<Product>,IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }

        public ICollection<Product> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetByCategory(int categoryId)
        {
            var products = _productRepository.GetByCategory(categoryId);

            return products;
        }
    }
}
