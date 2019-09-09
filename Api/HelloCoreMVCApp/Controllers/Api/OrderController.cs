using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HelloCoreMVCApp.Controllers.Api
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderManager _orderManager;
        private IOrderDetailManager _orderDetailManager;

        public OrderController(IOrderManager orderManager,IOrderDetailManager orderDetailManager)
        {
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderManager.GetAll();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IEnumerable<OrderDetail> Get(int id)
        {
            var orderDetails=_orderDetailManager.getByOrderId(id);
            return orderDetails;
        }

        // POST: api/Order
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
