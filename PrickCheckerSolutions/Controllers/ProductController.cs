using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrickCheckerSolutions.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Get product details
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }


    }
}