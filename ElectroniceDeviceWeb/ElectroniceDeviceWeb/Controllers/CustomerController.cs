using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectroniceDeviceWeb.Models;

namespace ElectroniceDeviceWeb.Controllers
{
    public class CustomerController : Controller
    {
        private ECartDBEntities ECartDBEntities;

        public CustomerController()
        {
            ECartDBEntities = new ECartDBEntities();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            if(ModelState.IsValid)
            {
                var data = ECartDBEntities.Customers.Where(item => email.Equals(item.Email) && password.Equals(item.Password));
                if(data.Count() > 0)
                {
                    return RedirectToAction()
                }
            }
        }
    }
}