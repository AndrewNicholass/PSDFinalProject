using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Repositories
{
    public class CartRepository
    {
        private static Database1Entities1 db = DBInstance.getInstance();

        public static Cart getCartByUserIDAndMakeupID(string userid, int makeupID)
        {
            int useridint = Convert.ToInt32(userid);
            return db.Carts.Where(u => u.UserID == useridint && u.MakeupID == makeupID).FirstOrDefault();
        }

        public static string updateQuantity(Cart toupdate, int quantity)
        {
            toupdate.Quantity = quantity;
            db.SaveChanges();
            return "cart has been updated!";
        }
        public static string addNewCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
            return "new cart has been added!";
        }

        public static void deleteCart(string id)
        {
            int userid = Convert.ToInt32(id);
            var todelete = (
                from x in db.Carts
                where x.UserID == userid
                select x
            ).ToList();
            foreach(var cart in todelete)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static List<Cart> getCartListByID(string userid)
        {
            int useridint = Convert.ToInt32(userid);
            return db.Carts.Where(u => u.UserID == useridint).ToList();
        }

        public static List<object> getCartDetailListByUserId(string userid)
        {
            int useridint = Convert.ToInt32(userid);
            var cartList = (
                from c in db.Carts
                join m in db.Makeups on c.MakeupID equals m.MakeupID
                where c.UserID == useridint
                select new
                {
                    m.MakeupName,
                    m.MakeupPrice,
                    c.Quantity,
                    subtotal = (m.MakeupPrice * c.Quantity)

                }
                
            ).ToList();

            List<object> cart = cartList.Select(x => (object)new
            {
                MakeupName = x.MakeupName,
                Quantity = x.Quantity,
                MakeupPrice = x.MakeupPrice,
                Subtotal = x.subtotal
            }
            ).ToList();
            return cart;
        }

    }
}