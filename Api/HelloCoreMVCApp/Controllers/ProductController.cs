using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL;
using BLL.Base;
using BLL.Contracts;
using HelloCoreMVCApp.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace HelloCoreMVCApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager _productManager;
        ICategoryManager _categoryManager;
        private IMapper _mapper;

        public ProductController(IProductManager productManager,ICategoryManager categoryManager,IMapper mapper)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productManager.GetAll();

            var productViewModelList = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return View(productViewModelList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            List<SelectListItem> categoryListItems = _categoryManager.GetAll().Select(c=>new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

           var model = new ProductCreateViewModel();
            model.CategoryItemList = categoryListItems;
            model.ProductList = _productManager.GetAll();
            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = _mapper.Map<Product>(model);

                   bool isAdded =  _productManager.Add(product);
                    if (isAdded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View();


            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult CategoryWiseProduct()
        {
            var model = new CategoryWiseProductViewModel();

            model.CategoryList = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            if (model.CategoryList == null)
            {
                model.CategoryList = new List<SelectListItem>();
            }


            return View(model);
        }

        [Route("api/product/byCategory")]
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            var products = _productManager.GetByCategory(categoryId);
            
            return products;
        }
    }
}