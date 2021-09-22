using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectroniceDeviceWeb.ViewModel
{
    public class ProductViewModel
    {
        public Guid ProductID { get; set; }
        
        public int CategoryID { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal ProductPrice { get; set; }

        public HttpPostedFileBase ImagePath { get; set; }

        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}