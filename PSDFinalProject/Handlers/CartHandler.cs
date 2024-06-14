using PSDFinalProject.Factories;
using PSDFinalProject.Models;
using PSDFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Handlers
{
    public class CartHandler
    {
        public static string checkOrder(string userid, string makeupname, int quantity)
        {
            Makeup makeupbyname = MakeupRepository.getMakeupByName(makeupname);
            int makeupid = 0;
            if(makeupbyname != null)
            {
                makeupid = makeupbyname.MakeupID;
            }

            Cart cart = CartRepository.getCartByUserIDAndMakeupID(userid, makeupid);
            if(cart == null)
            {
                Cart newCart = CartFactory.createNewCart(userid, makeupid.ToString(), quantity);
                return CartRepository.addNewCart(newCart);
            }

            return CartRepository.updateQuantity(cart, quantity);
        }

        public static void removeCart(string userid)
        {
            CartRepository.deleteCart(userid);
        }

        public static List<object> getCartDetailByUserId(string id)
        {
            return CartRepository.getCartDetailListByUserId(id);
        }

        public static void checkOutCart(string id)
        {
            List<Cart> cartList = CartRepository.getCartListByID(id);
            if(cartList != null)
            {
                TransactionHeader transactionHeader = TransactionFactory.createNewTransactionHeader(id);
                TransactionRepository.addNewTransactionHeader(transactionHeader);

                List<TransactionDetail> transactionDetailsList = TransactionFactory.createTransactionDetailList(transactionHeader, cartList);
                TransactionRepository.addNewTransactionDetails(transactionDetailsList);

                removeCart(id);
            
            }
        }
    }
}