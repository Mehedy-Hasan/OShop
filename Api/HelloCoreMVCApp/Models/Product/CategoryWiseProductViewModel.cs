using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloCoreMVCApp.Models.Product
{
    public class CategoryWiseProductViewModel
    {
        public ICollection<SelectListItem> CategoryList { get; set; }
    }
}
