using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Contracts;
using HelloCoreMVCApp.Models.Order;
using HelloCoreMVCApp.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Newtonsoft.Json;

namespace HelloCoreMVCApp.Controllers
{
    public class OrderController : Controller
    {
        private IProductManager _productManager;
        private IOrderManager _orderManager;
        private IMapper _mapper;
        private ICustomerManager _customerManager;
        private IOrderDetailManager _detailManager;


        public OrderController(IProductManager productManager,
            IOrderManager orderManager,
            IMapper mapper,
            ICustomerManager customerManager,
            IOrderDetailManager detailManager)
        {
            _mapper = mapper;
            _productManager = productManager;
            _orderManager = orderManager;
            _customerManager = customerManager;
            _detailManager = detailManager;
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
            var order = _mapper.Map<Order>(model);

            bool isAdded = _orderManager.Add(order);

            if (isAdded)
             {
                return RedirectToAction("Index");
            }

            var products = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.ProductSelectItems = products;

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
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
            var model = new OrderViewModel();

            model.OrderDetails = order.OrderDetails;
            model.ProductSelectItems = products;
            model.Customers = customer;
            model.OrderDate = order.OrderDate;
            model.OrderNo = order.OrderNo;

            //var allOrder=_mapper.Map<OrderViewModel>(order);


            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, OrderViewModel model)
        {
                        
            var existingOrderDetails = _detailManager.GetAll().Where(c => c.OrderId == id).ToList();
            
            var removeable = existingOrderDetails.Where(c => model.OrderDetails.All(sp => sp.Id != c.Id)).ToList();

            //Remove OrderDetail
            foreach(var remove in removeable)
            {
                var map = _mapper.Map<OrderDetail>(remove);
                _detailManager.Remove(map);
            }

            foreach (var dto in model.OrderDetails)
            {
                dto.OrderId = model.Id;
                if (dto.Id > 0)
                {
                    //Update
                    var dtldb = _detailManager.GetById(dto.Id);

                    dtldb.Id = dto.Id;
                    dtldb.OrderId = dto.OrderId;
                    dtldb.ProductId = dto.ProductId;
                    dtldb.Qty = dto.Qty;
                    dtldb.UnitPrice = dto.UnitPrice;
                    dtldb.DiscountPercentage = dto.DiscountPercentage;
                    _detailManager.Update(dtldb);
                }
                else
                {
                    //Add
                    var map = _mapper.Map<OrderDetail>(dto);
                    _detailManager.Add(map);
                }
            }      
            return View();
        }

    }
}