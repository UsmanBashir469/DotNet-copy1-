using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectASP.Net.Models
{
    public class ProductImplementation:IProduct
    {
        public List<Product> getProducts()
        {
            List<Product> list = new List<Product>();
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                var product = db.Products.Select(x => new { x.Id, x.ProductName, x.ProductCategory, x.ProductPrice, x.ProductQuantity,x.ImageUrl,x.Detail }).ToList();
                if (product.Count() > 0)
                {
                    foreach(var i in product)
                    {
                        Product p = new Product();
                        p.Id = i.Id;
                        p.ProductName = i.ProductName;
                        p.ProductCategory = i.ProductCategory;
                        p.ProductPrice = i.ProductPrice;
                        p.ProductQuantity = i.ProductQuantity;
                        p.ImageUrl = i.ImageUrl;
                        p.Detail = i.Detail;
                        list.Add(p);
                    }
                    return list;
                }
            }
            return null;
        }

        public List<Product> getAllProducts(String c)
        {
            List<Product> list = new List<Product>();
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                var product = db.Products.Where(x => x.ProductCategory.Equals(c)).Select(x => new { x.Id, x.ProductName, x.ProductCategory, x.ProductPrice, x.ProductQuantity, x.ImageUrl, x.Detail }).ToList();
                if (product.Count() > 0)
                {
                    foreach (var i in product)
                    {
                        Product p = new Product();
                        p.Id = i.Id;
                        p.ProductName = i.ProductName;
                        p.ProductCategory = i.ProductCategory;
                        p.ProductPrice = i.ProductPrice;
                        p.ProductQuantity = i.ProductQuantity;
                        p.ImageUrl = i.ImageUrl;
                        p.Detail = i.Detail;
                        list.Add(p);
                    }
                    return list;
                }
            }
            return null;
        }

        ////////////Get OrederItem From Product/////////////
        public Item getCartItem(int id)
        {
            Item item = new Item();

            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                var product = db.Products.Where(x => x.Id == id).Select(x => new { x.Id, x.ProductName, x.ProductCategory, x.ProductPrice, x.ProductQuantity, x.ImageUrl,x.Detail }).ToList();
                if (product.Count() > 0)
                {
                    foreach (var i in product)
                    {
                        Product p = new Product();
                        p.Id = i.Id;
                        p.ProductName = i.ProductName;
                        p.ProductCategory = i.ProductCategory;
                        p.ProductPrice = i.ProductPrice;
                        p.ProductQuantity = i.ProductQuantity;
                        p.ImageUrl = i.ImageUrl;
                        item.Product = p;
                        item.quantity = 1;
                    }
                    return item;
                }
            }
            return null;
        }
        public List<Product> getCartItem1(int id)
        {
           
            List<Product> list = new List<Product>();
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                var product = db.Products.Where(x => x.Id == id).Select(x => new { x.Id, x.ProductName, x.ProductCategory, x.ProductPrice, x.ProductQuantity, x.ImageUrl,x.Detail }).ToList();
                if (product.Count() > 0)
                {
                    foreach (var i in product)
                    {
                        Product p = new Product();
                        p.Id = i.Id;
                        p.ProductName = i.ProductName;
                        p.ProductCategory = i.ProductCategory;
                        p.ProductPrice = i.ProductPrice;
                        p.ProductQuantity = i.ProductQuantity;
                        p.ImageUrl = i.ImageUrl;
                        p.Detail = i.Detail;
                        list.Add(p);
                    }
                    return list;
                }
            }
            return null;
        }
        public void SaveProduct(Product p)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
        }
        public void UpdateProduct(Product p)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                  Product i = db.Products.Find(p.Id);
                 
                  if (i != null)
                  {
                      //i.Id = p.Id;
                      i.ProductName = p.ProductName;
                      i.ProductCategory = p.ProductCategory;
                      i.ProductPrice = p.ProductPrice;
                      i.ProductQuantity = p.ProductQuantity;
                      i.Detail = p.Detail;
                      db.SaveChanges();
                  }
                    
            }
        }
        public Product ProductDetail(int id)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                Product i = db.Products.Find(id);
                return i;
            }
        }
        public List<Admin> logIn(Admin u)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                List<Admin> list = new List<Admin>();
                var user = db.Admins.Where(x => x.UserName == u.UserName && x.Password == u.Password).Select(x => new { x.Name, x.Password, x.Address, x.Number, x.Email }).ToList();
                if (user.Count() > 0)
                {
                    foreach (var i in user)
                    {
                        Admin us = new Admin();
                        us.Name = i.Name;
                        us.Number = i.Number;
                        us.Address = i.Address;
                        us.Email = i.Email;
                        us.Password = i.Password;
                        us.UserName = u.UserName;
                        list.Add(us);
                    }

                    return list;
                }
            }
            return null; 
        }
        public List<Product> search(string name)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                List<Product> list = new List<Product>();
                var product = db.Products.Where(x => x.ProductName.Contains(name)).Select(x => new { x.Id, x.ProductName, x.ProductCategory, x.ProductPrice, x.ProductQuantity, x.ImageUrl, x.Detail }).ToList();
                if (product.Count() > 0)
                {
                    foreach (var i in product)
                    {
                        Product p = new Product();
                        p.Id = i.Id;
                        p.ProductName = i.ProductName;
                        p.ProductCategory = i.ProductCategory;
                        p.ProductPrice = i.ProductPrice;
                        p.ProductQuantity = i.ProductQuantity;
                        p.ImageUrl = i.ImageUrl;
                        p.Detail = i.Detail;
                        list.Add(p);
                    }
                    return list;
                }
            }
            return null;
 
        }
        public void addProd(List<Item> li, string name,double t)
        {
            Order o = new Order();
            o.OrderAmount = li.Count();
            o.OrderPrice = t;
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                var user = db.Users.Where(x => x.UserName == name).Select(x => new {x.Id, x.Name, x.Password, x.Address, x.Number, x.Email }).ToList();
                if (user.Count() > 0)
                {
                    User us = new User();
                    foreach (var i in user)
                    {
                        o.UserId = i.Id;

                    }

                   
                }
                db.Orders.Add(o);
                db.SaveChanges();
                int orderid = 0;
                var order = db.Orders.Where(x => x.UserId == o.UserId).Select(x => new { x.Id }).ToList();
                foreach (var i in order)
                {
                    orderid = i.Id;
                }
                foreach(var i in li)
                {
                    ProductDetail d = new ProductDetail();
                    d.OrderId = orderid;
                    d.ProdId = i.Product.Id;
                    db.ProductDetails.Add(d);
                    db.SaveChanges();
                }
            }
        }
    }
}