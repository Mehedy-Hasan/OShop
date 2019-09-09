using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCoreMVCApp.Controllers.Api
{
  
    [Route("api/products")]
    public class ProductController : Controller
    {
        private IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _productManager.GetAll();
            return products;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _productManager.GetById(id);
            return product;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
