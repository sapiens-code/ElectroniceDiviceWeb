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

        public CustomerController()
        {
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

    }
}