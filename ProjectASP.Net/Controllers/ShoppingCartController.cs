using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectASP.Net.Models;

namespace ProjectASP.Net.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppingCart/
        IUser user;
        IProduct prod;
        public ShoppingCartController(IProduct p, IUser i)
        {
            prod = p;
            user = i;
        }
        public int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public int isExisting1(String id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ImageUrl.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return Redirect("~/ShoppingCart/Index");

        }
        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(prod.getCartItem(id));
                Session["cart"] = cart;
               
            }
            else
            {
                List<Item> cart = (List < Item >) Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                {
                    cart.Add(prod.getCartItem(id));
                }
                else
                {
                    cart[index].quantity++;
                }
                Session["cart"] = cart; 
            }
            return Redirect("~/ShoppingCart/Index");
        }
        public ActionResult OrderNow1(String url)
        {
            //if (Session["cart"] == null)
            //{
            //    List<Item> cart = new List<Item>();
            //    cart.Add(prod.getCartItem1(url));
            //    Session["cart"] = cart;

            //}
            //else
            //{
            //    List<Item> cart = (List<Item>)Session["cart"];
            //    int index = isExisting1(url);
            //    if (index == -1)
            //    {
            //        cart.Add(prod.getCartItem1(url));
            //    }
            //    else
            //    {
            //        cart[index].quantity++;
            //    }
            //    Session["cart"] = cart;
            //}
            return Redirect("~/ShoppingCart/Index");
        }
        public ActionResult DesignLab()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            if (Session["user"] != null)
            {
                String userName = Session["user12"].ToString();
                User u = user.getUser(userName);
                ViewBag.User = u;
                return View();
            }
            else {
                return Redirect("~/ShoppingCart/Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(User u)
        {
            List<User> list = new List<User>();
            list = user.logIn(u);

            if (list != null)
            {
                Session["user"] = list;
                foreach (var i in list)
                {
                    Session["name"] = i.Name;
                    Session["user12"] = i.UserName;
                }
                return Redirect("~/ShoppingCart/Checkout");
            }
            return Redirect("~/ShoppingCart/Login");
        } 
        public ActionResult check()
        {
            List<Item> list = new List<Item>();
            list = (List<Item>)Session["Cart"];
            string name = Session["user12"].ToString();
            double t = Double.Parse((Session["totalp"]).ToString());
            prod.addProd(list,name,t);
            Session.RemoveAll();
            return Redirect("~/Home/Index");
        }
        
    }
}
