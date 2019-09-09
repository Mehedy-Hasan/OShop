using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace HelloCoreMVCApp.Models.Order
{
    public class OrderViewModel
    {
       
        public int Id { get; set; }
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }
        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name="Customer")]
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public List<SelectListItem> ProductSelectItems { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
