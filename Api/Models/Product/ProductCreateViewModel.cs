using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace HelloCoreMVCApp.Models.Product
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        //public List<Shop> Shops { get; set; }
        //public List<OrderDetail> Orders { get; set; }
     

    
        public List<SelectListItem> CategoryItemList { get; set; }

  
        public ICollection<global::Models.Product> ProductList { get; set; }
    }
}
