using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectroniceDeviceWeb.ViewModel
{
    public class ShoppingViewModel
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ItemCode { get; set; }
    }
}