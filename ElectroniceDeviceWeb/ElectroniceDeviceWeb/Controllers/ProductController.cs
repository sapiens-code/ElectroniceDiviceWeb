using ElectroniceDeviceWeb.Models;
using ElectroniceDeviceWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public JsonResult Index(ProductViewModel productViewModel)
        {
            string newImage = Guid.NewGuid() + Path.GetExtension(productViewModel.ImagePath.FileName);
            string path = "~/Image/" + newImage;
            productViewModel.ImagePath.SaveAs(Server.MapPath(path));

            Product item = new Product();
            item.ImagePath = path;
            item.ProductName = productViewModel.ProductName;
            item.CategoryID = productViewModel.CategoryID;
            item.Desciption = productViewModel.Description;
            item.ProductID = Guid.NewGuid();
            item.ProductPrice = productViewModel.ProductPrice;
            item.ProductCode = productViewModel.ProductCode;

            ECartDBEntities.Products.Add(item);
            ECartDBEntities.SaveChanges();

            return Json(data: new { Success = true, Message = "item is added" }, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}