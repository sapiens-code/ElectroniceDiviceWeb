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
        private ECartDBEntities ECartDBEntities;

        public ShoppingController()
        {
            ECartDBEntities = new ECartDBEntities();
        }

        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> shoppingViewModels = (from item in ECartDBEntities.Products
                                                                 join cate in ECartDBEntities.Categories
                                                                 on item.CategoryID equals cate.CategoryId
                                                                 select new ShoppingViewModel()
                                                                 {
                                                                     ImagePath = item.ImagePath,
                                                                     ProductName = item.ProductName,
                                                                     Description = item.Desciption,
                                                                     ProductPrice = item.ProductPrice,
                                                                     ProductID = item.ProductID,
                                                                     Category = cate.CategoryName,
                                                                     ItemCode = item.ProductCode
                                                                 });
            return View(shoppingViewModels);
        }
    }
}