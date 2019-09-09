using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class VWOrderInfo
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
    }
}
