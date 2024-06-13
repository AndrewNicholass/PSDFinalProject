using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDFinalProject.Models;

namespace PSDFinalProject.Repositories
{
    public class DBInstance
    {
        private static Database1Entities1 db;

        public static Database1Entities1 getInstance()
        {
            if (db == null)
            {
                db = new Database1Entities1();
            }
            return db;
        }
    }
}