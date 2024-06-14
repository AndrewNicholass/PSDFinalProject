using PSDFinalProject.Models;
using PSDFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Handlers
{
    public class TransactionHandler
    {
        public static void handleTransaction(string transactionId)
        {
            TransactionHeader toupdate = TransactionRepository.getTransactionById(transactionId);
            if(toupdate != null)
            {
                TransactionRepository.updateTransactionStatus(toupdate);
            }
        }

        public static List<object> getHandledTransactionByUserId(string userid)
        {
            return TransactionRepository.getHandledTransactionListByUserId(userid);
        }

        public static List<TransactionHeader> getTransactionQueue()
        {
            return TransactionRepository.getTransactionHeaderList();
        }

        public static List<TransactionHeader> getHandledTransactions()
        {
            return TransactionRepository.getHandledTransactionList();
        }

        public static string getTransactionStatus(string id)
        {
            TransactionHeader transactionbyid = TransactionRepository.getTransactionById(id);
            if(transactionbyid != null)
            {
                return transactionbyid.Status;
            }
            return "";
        }

        public static string getTransactionDate(string id)
        {
            TransactionHeader transactionbyid = TransactionRepository.getTransactionById(id);
            if (transactionbyid != null)
            {
                return transactionbyid.TransactionDate.ToString("dd-MM-yyyy");
            }
            return "";
        }

        public static List<object> getTransactionDetails(string id)
        {
            return TransactionRepository.getTransactionDetailList(id);
        }

    }
}