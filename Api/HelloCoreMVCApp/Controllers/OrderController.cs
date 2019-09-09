using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Contracts;
using HelloCoreMVCApp.Models.Order;
using HelloCoreMVCApp.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace HelloCoreMVCApp.Controllers
{
    public class OrderController : Controller
    {
        private IProductManager _productManager;
        private IOrderManager _orderManager;
        private IMapper _mapper;
        private ICustomerManager _customerManager;


        public OrderController(IProductManager productManager,
            IOrderManager orderManager,
            IMapper mapper,
            ICustomerManager customerManager)
        {
            _mapper = mapper;
            _productManager = productManager;
            _orderManager = orderManager;
            _customerManager = customerManager;
        }
        public IActionResult Index()
        {
            var orders = _orderManager.GetAllOrderSummary();
            return View(orders);
        }

        public IActionResult Create()
        {
            var products = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            var customer = _customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();

            var model = new OrderViewModel()
            {
                ProductSelectItems = products,
                Customers = customer
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {

            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);

              bool isAdded =   _orderManager.Add(order);

                if (isAdded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            var products = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.ProductSelectItems = products;

            return View(model);
        }

        public ActionResult Edit(int id,OrderViewModel model)
        {
            var products = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            var customer = _customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();

            var order = _orderManager.GetById(id);

            model.OrderDetails = order.OrderDetails;
            model.ProductSelectItems = products;
            model.Customers = customer;
            model.OrderDate = order.OrderDate;
            model.OrderNo = order.OrderNo;

            //var allOrder=_mapper.Map<OrderViewModel>(order);
            
            
            return View(model);
        }
    }
}