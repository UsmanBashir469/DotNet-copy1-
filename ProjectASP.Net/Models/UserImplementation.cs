using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectASP.Net.Models
{
    public class UserImplementation : IUser
    {
        public void save(User u)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                db.Users.Add(u);
                db.SaveChanges();
            }
        }
        public List<User> logIn(User u)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                List<User> list = new List<User>();
                var user = db.Users.Where(x => x.UserName == u.UserName && x.Password == u.Password).Select(x => new { x.Name, x.Password, x.Address, x.Number, x.Email }).ToList();
                if (user.Count() > 0)
                {
                    foreach (var i in user)
                    {
                        User us = new User();
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
        public User getUser(String user1)
        {
            using (ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1())
            {
                var user = db.Users.Where(x => x.UserName == user1 ).Select(x => new { x.Name, x.Password, x.Address, x.Number, x.Email }).ToList();
                if (user.Count() > 0)
                {
                    User us = new User();
                    foreach (var i in user)
                    {
                        us.Name = i.Name;
                        us.Number = i.Number;
                        us.Address = i.Address;
                        us.Email = i.Email;
                        us.Password = i.Password;
                        us.UserName = user1;
                         
                    }

                    return us;
                }
            }
            return null;
        }
    }
}