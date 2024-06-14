using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Controllers
{
    public class CartController
    {
        public static string validateOrder(string id, string makeupname, string quantity)
        {
            if(quantity == "")
            {
                return "quantity cant be 0";
            }
            int qty = Convert.ToInt32(quantity);
            if(qty <= 0)
            {
                return "quantity cant be negative";
            }
            return CartHandler
        }
    }
}