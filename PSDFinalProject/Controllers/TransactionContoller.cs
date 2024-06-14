using PSDFinalProject.Handlers;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace PSDFinalProject.Controllers
{
    public class TransactionContoller
    {
        public static string showTransactionDate(string transactionId)
        {
            return TransactionHandler.getTransactionDate(transactionId);
        }

        public static string showTransactionStatus(string transactionId)
        {
            return TransactionHandler.getTransactionStatus(transactionId);
        }

        public static List<object> showTransactionDetails(string transactionId)
        {
            return TransactionHandler.getTransactionDetails(transactionId);
        }
    }
}