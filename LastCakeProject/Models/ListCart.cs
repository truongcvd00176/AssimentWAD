using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastCakeProject.Models
{
    public class ListCart
    {
        private int Id { get; set; }
        private int productId { get; set; }
        private int quantity { get; set; }
        private decimal price { get; set; }

        public ListCart()
        {

        }

        public ListCart(int Id, int productId, int quantity, decimal price)
        {
            this.Id = Id;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }



    }
}