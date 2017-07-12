using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProjectASP.Net.Controllers;
namespace ProjectASP.Net.Models
{
    public class Item
    {
        public Product product = new Product();

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public int quantity{get;set;}

        

        public Item()
        { 
        }
        public Item(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

    }
}