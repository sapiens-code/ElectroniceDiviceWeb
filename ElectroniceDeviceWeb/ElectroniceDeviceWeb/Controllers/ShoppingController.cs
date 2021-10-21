using ElectroniceDeviceWeb.Models;
using ElectroniceDeviceWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectroniceDeviceWeb.Controllers
{
    public class ShoppingController : Controller
    {
        private ElectricDeviceDBEntities DB;

        public ShoppingController()
        {
            DB = new ElectricDeviceDBEntities();
        }

        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in DB.Products
                                                                 join cate in DB.Categories
                                                                 on item.CategoryID equals cate.CategoryId
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     ImagePath = item.ImagePath,
                                                                     ProductName = item.ProductName,
                                                                     Description = item.Desciption,
                                                                     ProductPrice = item.ProductPrice,
                                                                     ProductID = item.ProductID,
                                                                     Category = cate.CategoryName,
                                                                 });
            return View(shoppingViewModels);
        }
    }
}