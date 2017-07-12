using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Net.Models
{
    public interface IProduct
    {
        List<Product> getProducts();
        List<Product> getAllProducts(String c);
        Item getCartItem(int id);
        List<Product> getCartItem1(int id);
        void SaveProduct(Product p);
        void UpdateProduct(Product p);
        Product ProductDetail(int id);
        List<Admin> logIn(Admin u);
        void addProd(List<Item> li, string name, double t);
        List<Product> search(string name);
    }
}
