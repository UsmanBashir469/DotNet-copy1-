using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectASP.Net.Models;

namespace ProjectASP.Net.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private IUser user;
        IProduct prod;

        public HomeController(IUser u,IProduct p)
        {
            user = u;
            prod = p;

        }

        public ActionResult Index()
        {
            List<Product> p = new List<Product>();
            p = prod.getAllProducts("Woman");
            ViewBag.listProduct = p;
            return View();
           
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();

        }
        public ActionResult Detail()
        {
            return View();

        }

        
        public ActionResult Detail1(String id)
        {
            Product p = new Product();
           
            ViewBag.detailData = p;
            return View();
        }
        public ActionResult Checkout()
        {
            return View();

        }
        public ActionResult Men()
        {
            return View();

        }
        public ActionResult About()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            user.save(u);
            return Redirect("~/Home/Login");
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            List<User> list = new List<User>();
            list = user.logIn(u);

            if (list!=null)
            {
                Session["user"] = list;
                foreach (var i in list)
                {
                    Session["name"] = i.Name;
                    Session["user12"] = i.UserName;
                }
                return Redirect("~/Home");
            }
            return Redirect("~/Home/Login");
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["cart"] = null;
            Session["cart"] = null;
            Session.RemoveAll();
            return Redirect("~/Home/Login");
        }
        public ActionResult Info()
        {
            String userName = Session["user12"].ToString();
            User u = user.getUser(userName);
            ViewBag.User = u;
            return View();
        }
        [HttpPost]
        public JsonResult check(String userName)
        {
            User u = user.getUser(userName);
            string s = null;
            if (u != null)
            {
                s = "**User Name Already Register";
            }
            else if(userName != null)
            {
                s = "**Please Enter the User Name";
            }
            else {
                s = "User Name Available";
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        public ActionResult saved_resource()
        {
            return View();
        }
        public ActionResult Women()
        {
            return View();
        }


    }

}

