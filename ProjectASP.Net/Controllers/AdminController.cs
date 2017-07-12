using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectASP.Net.Models;
using System.IO;
namespace MCShoppingServer.Controllers
{
    public class AdminController : Controller
    {
        private IProduct prod;
        // GET: /Admin/
        public AdminController(IProduct p)
        {
            prod = p; 
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin u)
        {
            List<Admin> list = new List<Admin>();
            list = prod.logIn(u);

            if (list != null)
            {
                Session["admin"] = list;
                foreach (var i in list)
                {
                    Session["aname"] = i.Name;
                    Session["adu"] = i.UserName;
                }
                return Redirect("/Admin/Index");
            }
            return Redirect("/Admin/Login");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return Redirect("~/Home/Index");
        }
        public ActionResult addProduct()
        {

            //prod.SaveProduct(p);
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(FormCollection fc, HttpPostedFileBase file)
        {
            Product p = new Product();
            var allowedExtension = new[] { ".jpg", ".png", ".jpeg" };
            p.ProductName = Request["ProductName"].ToString();
            p.ProductCategory = Request["ProductCategory"].ToString();
            p.ProductPrice = Double.Parse(Request["ProductPrice"]);
            p.ProductQuantity = int.Parse(Request["ProductQuantity"]);
            p.Detail = Request["Detail"].ToString();
            p.ImageUrl = Request["ImageUrl"].ToString();
            var extension = Path.GetExtension(file.FileName);
            if (allowedExtension.Contains(extension))
            {
                
                String name = p.ImageUrl;
                String fileName = name + extension;
                var path = Path.Combine(Server.MapPath("~/Images"),fileName);
                var path1 = Path.Combine("~/Images", fileName);
                p.ImageUrl = path1;
                prod.SaveProduct(p);
                file.SaveAs(path);
            }
            //prod.SaveProduct(p);
            return View();
        }
        public ActionResult getAllProduct()
        {
            List<Product> p = new List<Product>();
            p = prod.getProducts();
            ViewBag.listProductt = p;
            return View();
        }
        public void DeleteProduct(int id)
        {
            //var product = db.Products.Find(id);
            //db.Products.Remove(product);
            //db.SaveChanges();

        }
        public ActionResult UpdateProduct(int id)
        {
            List<Product> list = new List<Product>();
            list = prod.getCartItem1(id);
            ViewBag.update = list;
            Product p = new Product();
            p = list[0];
            ModelState.Clear();
            //var prod = db.Products.Find(p.ProductId);
            //prod.Name = p.Name;
            //prod.Brand = p.Brand;
            //prod.Quantity = p.Quantity;
            //prod.UnitPrice = p.UnitPrice;
            //prod.Category = p.Category;
            //db.SaveChanges();
            return View(p);
        }
        [HttpPost]
        public ActionResult Update(FormCollection fc, HttpPostedFileBase file)
        {
           // var a = fc["ProductName"];
           // var s = Request["ProductName"];
            Product p = new Product();
           // var allowedExtension = new[] { ".jpg", ".png", ".jpeg" };
            p.ProductName = Request["ProductName"].ToString();
            p.ProductCategory = Request["ProductCategory"].ToString();
            p.ProductPrice = Double.Parse(Request["ProductPrice"]);
            p.ProductQuantity = int.Parse(Request["ProductQuantity"]);
            p.Detail = Request["Detail"].ToString();
            //p.ImageUrl = Request["ImageUrl"].ToString();
            p.Id = int.Parse(Request["Id"]);
            //var extension = Path.GetExtension(file.FileName);
            
           
                //String name = p.ImageUrl;
                //String fileName = name + extension;
                //var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //var path1 = Path.Combine("~/Images", fileName);
                //p.ImageUrl = path1;
                prod.UpdateProduct(p);
               // file.SaveAs(path);
            
            return Redirect("Index");
            
        }
        public JsonResult Search(string ProductName)
        {
            string s = null;
            List<Product> list = new List<Product>();
            list = prod.search(ProductName);
            s += "<tr><th>Product Id</th><th>Product Name</th><th>Product Cat</th><th>Product Price</th><th>Product Detail</th>";
            foreach (var i in list)
            {
                s += "<tr><td>" + i.Id + "</td><td>" + i.ProductName + "</td><td>" + i.ProductCategory + "</td><td>" + i.ProductPrice + "</td><td>" + i.Detail + "</td></tr>";
            }
            return this.Json(s,JsonRequestBehavior.AllowGet);
        }

        //public List<Product> GetAllProduct()
        //{
        //   //return  db.Products.ToList();
        //}
        //public Product GetProduct(int id)
        //{
        //    //return db.Products.Find(id);
        //}

    }
}
