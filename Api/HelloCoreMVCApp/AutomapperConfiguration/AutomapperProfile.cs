using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloCoreMVCApp.Models.Order;
using HelloCoreMVCApp.Models.Product;
using Models;

namespace HelloCoreMVCApp.AutomapperConfiguration
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductCreateViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<OrderDetail, OrderViewModel>();
            CreateMap<OrderViewModel, OrderDetail>();
        }
    }
}
