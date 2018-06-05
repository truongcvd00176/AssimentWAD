using LastCakeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastCakeProject.Controllers
{
    public class ListCartController
    {


        List<ListCart> listCarts;
        public void AddListCart(int Id, int productId, int quantity, decimal price)
        {
            ListCart cart = new ListCart(Id, productId, quantity, price);
            listCarts.Add(cart);
        }

        public List<ListCart> GetListCarts()
        {
            return listCarts;
        }
        public void DeleteListCart(ListCart cart)
        {
            listCarts.Remove(cart);
        }


    }
}