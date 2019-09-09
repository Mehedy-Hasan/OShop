using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Contracts;
using DatabaseContext;
using HelloCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Repositories;

namespace HelloCoreMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public IActionResult Create()
        {

           

            List<SelectListItem> addressDataList = new List<SelectListItem>()
            {

                new SelectListItem(){Value="DHK",Text="Dhaka"},
                new SelectListItem(){Value="CTG",Text="Chittagong"},
                new SelectListItem(){Value="SYL",Text="Sylhet"},
                new SelectListItem(){Value="BAR",Text="Barishal"},
            };

            ViewBag.AddressList = addressDataList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _customerManager.Add(customer);
 
                if (isSaved)
                {
                    return RedirectToAction("Details", customer);
                }
                

            }

            return View();
        }

        public IActionResult Details(Customer customer)
        {
            //related code
            ViewBag.Title = "Customer Details";
            return View(customer);
        }
    }
}