using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectASP.Net.Models;

namespace ProjectASP.Net.Controllers
{
    public class OrderPlaceController : Controller
    {
        //
        // GET: /OrderPlace/
        private IProduct prod;
        public OrderPlaceController(IProduct p)
        {
            prod = p;
        }
        public ActionResult Index()
        {
             
            List<Product> p = new List<Product>();
            p = prod.getProducts();
            ViewBag.listProduct = p;
            return View();
        
        }
        public ActionResult Men()
        {
            List<Product> p = new List<Product>();
            p = prod.getAllProducts("Men");
            ViewBag.listProduct = p;
            return View();
        }
        public ActionResult Woman()
        {
            List<Product> p = new List<Product>();
            p = prod.getAllProducts("Woman");
            ViewBag.listProduct = p;
            return View();
        }
        public ActionResult Kid()
        {
            List<Product> p = new List<Product>();
            p = prod.getAllProducts("Kid");
            ViewBag.listProduct = p;
            return View();
        }
        public ActionResult Detail(int id)
        {
            Product product = new Product();
            product = prod.ProductDetail(id);
            ViewBag.prodDetail = product;
            return View();
        }

    }
}
