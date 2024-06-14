using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader createNewTransactionHeader(string userId)
        {
            int userID = Convert.ToInt32(userId);
            TransactionHeader newTransactionHeader = new TransactionHeader();
            newTransactionHeader.UserID = userID;
            newTransactionHeader.TransactionDate = DateTime.Now;
            newTransactionHeader.Status = "Unhandled";
            return newTransactionHeader;
        }

        public static List<TransactionDetail> createTransactionDetailList(TransactionHeader newTransactionHeader, List<Cart> CartList)
        {
            List<TransactionDetail> transactionDetailList = new List<TransactionDetail>();
            foreach (var cart in CartList)
            {
                TransactionDetail newTransactionDetail = new TransactionDetail();
                newTransactionDetail.TransactionID = newTransactionHeader.TransactionID;
                newTransactionDetail.MakeupID = cart.MakeupID; ;
                newTransactionDetail.Quantity = cart.Quantity;
                transactionDetailList.Add(newTransactionDetail);
            }
            return transactionDetailList;
        }
    }
}