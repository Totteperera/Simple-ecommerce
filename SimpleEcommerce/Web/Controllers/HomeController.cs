using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SimpleEcommerce.BL.Mappers;
using SimpleEcommerce.BL.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pw = new List<ProductViewModel>();
            using(var db = new SimpleEcommerce.DAL.SimpleEcommerceContext())
            {
                var test = db.Products.ToList();
                pw = test.Select(x => x.Map()).ToList();
            }
            return View(pw);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}