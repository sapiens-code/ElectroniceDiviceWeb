using ElectroniceDeviceWeb.Models;
using ElectroniceDeviceWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectroniceDeviceWeb.Controllers
{
    public class ProductController : Controller
    {
        private ElectricDeviceDBEntities DB;

        public ProductController()
        {
            DB = new ElectricDeviceDBEntities();
        }

        // GET: Product
        public ActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.CategorySelectListItem = (from item in DB.Categories
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

            Product item = new Product
            {
                ImagePath = path,
                ProductName = productViewModel.ProductName,
                CategoryID = productViewModel.CategoryID,
                Desciption = productViewModel.Description,
                ProductID = Guid.NewGuid(),
                ProductPrice = productViewModel.ProductPrice
            };

            DB.Products.Add(item);
            try { 
            DB.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Exception raise = e;
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return Json(data: new { Success = true, Message = "item is added" }, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}