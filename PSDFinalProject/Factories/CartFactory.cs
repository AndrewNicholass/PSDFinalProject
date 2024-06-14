using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Factories
{
    public class CartFactory
    {
        public static Cart createNewCart(string userid, string makeupid, int quantity)
        {
            Cart cart = new Cart();
            int id = Convert.ToInt32(userid);
            int makeupid2 = Convert.ToInt32(makeupid);
            cart.UserID = id;
            cart.MakeupID = makeupid2;
            cart.Quantity = quantity;

            return cart;
        }
    }
}