using PSDFinalProject.Factories;
using PSDFinalProject.Models;
using PSDFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Handlers
{
    public class MakeupHandler
    {
        public static List<object> getAllMakeupDetails()
        {
            return MakeupRepository.getMakeupDetailList();
        }

        public static List<Makeup> getAllMakeup()
        {
            return MakeupRepository.getMakeupList();
        }

        public static string insertNewMakeup(string name, string price, string weight, string typeid, string brandid)
        {
            Makeup makeup = MakeupRepository.getMakeupByName(name);
            if(makeup != null)
            {
                if(makeup.MakeupName == name)
                {
                    return "make up already exist !";
                }
            }
            Makeup newmakeup = MakeupFactory.createMakeup(name, price, weight, typeid, brandid);
            return MakeupRepository.addNewMakeup(newmakeup);
        }

        public static string removeMakeup(string id)
        {
            TransactionDetail transactionbyid = TransactionRepository.getTransactionByMakeupId(id);

            if (transactionbyid ==  null)
            {
                Makeup todelete = MakeupRepository.getMakeupById(id);
                return MakeupRepository.deleteMakeup(todelete);
            }
            return "makeup exist in another table!";
        }

        public static string changeMakeup(string id, string name, string price, string weight, string typeid, string brandid)
        {
            Makeup toupdate = MakeupRepository.getMakeupById(id);
            if(toupdate != null)
            {
                return MakeupRepository.updateMakeup(toupdate, id, name, price, weight, typeid, brandid);

            }
            return "makeup not found!";
        }

        public static string getMakeupName(string id)
        {
            Makeup makeupbyid = MakeupRepository.getMakeupById(id);
            if(makeupbyid != null)
            {
                return makeupbyid.MakeupName;
            }
            return "";
        }

        public static string getMakeupWeight(string id)
        {
            Makeup makeupbyid = MakeupRepository.getMakeupById(id);
            if (makeupbyid != null)
            {
                return makeupbyid.MakeupWeight.ToString();
            }
            return "";
        }

        public static string getMakeupPrice(string id)
        {
            Makeup makeupbyid = MakeupRepository.getMakeupById(id);
            if (makeupbyid != null)
            {
                return makeupbyid.MakeupPrice.ToString();
            }
            return "";
        }

        public static string getMakeupTypeName(string id)
        {
            MakeupType makeupbyid = MakeupRepository.getMakeupTypeById(id);
            if (makeupbyid != null)
            {
                return makeupbyid.MakeupTypeName;
            }
            return "not available!";
        }
    }
}