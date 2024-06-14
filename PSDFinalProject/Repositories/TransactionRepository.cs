using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Repositories
{
    public class TransactionRepository
    {
        private static Database1Entities1 db = DBInstance.getInstance();
        public static void addNewTransactionHeader(TransactionHeader newTransactionHeader)
        {
            db.TransactionHeaders.Add(newTransactionHeader);
            db.SaveChanges();
        }
        public static void addNewTransactionDetails(List<TransactionDetail> newTransactionDetailsList)
        {
          
            foreach (var newTransactionDetail in newTransactionDetailsList)
            {
                db.TransactionDetails.Add(newTransactionDetail);
            }
            db.SaveChanges();
        }

        public static List<TransactionHeader> getTransactionHeaderList()
        {
            return db.TransactionHeaders.ToList();
        }
        public static TransactionDetail getTransactionByMakeupId(string makeupid)
        {
            int makeupID = Convert.ToInt32(makeupid);
            return db.TransactionDetails.Where(u => u.MakeupID == makeupID).FirstOrDefault();
        }

        public static TransactionHeader getTransactionById(string transactionId)
        {
            int transactionID = Convert.ToInt32(transactionId);
            return db.TransactionHeaders.Where(u => u.TransactionID == transactionID).FirstOrDefault();
        }
        public static void updateTransactionStatus(TransactionHeader toUpdate)
        {
            toUpdate.Status = "Handled";
            db.SaveChanges();
        }

        public static List<object> getHandledTransactionListByUserId(string userid)
        {
            int userID = Convert.ToInt32(userid);
            var historyList = (
                from th in db.TransactionHeaders
                where ((th.UserID == userID) && (th.Status == "Handled"))
                select new
                {
                    th.TransactionID,
                    th.TransactionDate,
                    th.Status
                }
            ).ToList();

            List<object> transactionHistoryList = historyList.Select(x => (object)new
                {
                    TransactionID = x.TransactionID,
                    TransactionDate = x.TransactionDate,
                    Status = x.Status
                }
            ).ToList();
            return transactionHistoryList;
        }

        public static List<object> getTransactionDetailList(string transactionid)
        {
            int transactionID = Convert.ToInt32(transactionid);
            var TransactionDetailList = (
                from td in db.TransactionDetails
                join ms in db.Makeups on td.MakeupID equals ms.MakeupID
                where td.TransactionID == transactionID
                select new
                {
                    ms.MakeupName,
                    ms.MakeupPrice,
                    td.Quantity,
                    subtotal = (ms.MakeupPrice * td.Quantity),
                }
            ).ToList();

            List<object> transactionDetailList = TransactionDetailList.Select(x => (object)new
            {
                MakeupName = x.MakeupName,
                MakeupPrice = x.MakeupPrice,
                Quantity = x.Quantity,
                SubTotal = x.subtotal
            }
            ).ToList();

            return transactionDetailList;
        }

        public static List<TransactionHeader> getHandledTransactionList()
        {
            return db.TransactionHeaders.Where(u => u.Status == "Handled").ToList();
        }
    }
}