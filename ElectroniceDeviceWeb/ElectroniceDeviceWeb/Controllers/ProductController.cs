using ElectroniceDeviceWeb.Models;
using ElectroniceDeviceWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectroniceDeviceWeb.Controllers
{
    public class ProductController : Controller
    {
        private ECartDBEntities ECartDBEntities;

        public ProductController()
        {
            ECartDBEntities = new ECartDBEntities();
        }

        // GET: Product
        public ActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.CategorySelectListItem = (from item in ECartDBEntities.Categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = item.CategoryName,
                                                           Value = item.CategoryId.ToString(),
                                                           Selected = true
                                                       });

            return View(productViewModel);
        }
    }
}