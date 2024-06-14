using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Repositories
{
    public class MakeupRepository
    {
        public static Database1Entities1 db = DBInstance.getInstance();

        public static List<Makeup> getMakeupList()
        {
            return db.Makeups.ToList();
        }

        public static Makeup getMakeupByName(string makeupname)
        {
            return db.Makeups.Where(u => u.MakeupName == makeupname).FirstOrDefault();
        }
        public static MakeupType getMakeupTypeByName(string makeupname)
        {
            return db.MakeupTypes.Where(u => u.MakeupTypeName == makeupname).FirstOrDefault();
        }

        public static int addNewMakeupType(MakeupType makeuptype)
        {
            db.MakeupTypes.Add(makeuptype);
            db.SaveChanges();
            return makeuptype.MakeupTypeID;

        }

        public static string addNewMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            db.SaveChanges();
            return "new makeup has been added successfully!";

        }
        public static Makeup getMakeupById(string id)
        {
            int makeupid = Convert.ToInt32(id);
            return db.Makeups.Where(u => u.MakeupID == makeupid).FirstOrDefault();
        }

        public static string deleteMakeup(Makeup makeup)
        {
            db.Makeups.Remove(makeup);
            db.SaveChanges();
            return "makeup has been deleted successfully!";

        }
        public static string updateMakeup(Makeup makeup, string id, string name, string price, string weight, string typeid, string brandid)
        {
            makeup.MakeupName = name;
            makeup.MakeupPrice = Convert.ToInt32(price);
            makeup.MakeupWeight = Convert.ToInt32(weight);
            makeup.MakeupTypeID = Convert.ToInt32(typeid);
            makeup.MakeupBrandID = Convert.ToInt32(brandid);
            db.SaveChanges();
            return "makeup has been updated successfully!";

        }
        public static MakeupType getMakeupTypeById(string id)
        {
            int typeid = Convert.ToInt32(id);
            return db.MakeupTypes.Where(u => u.MakeupTypeID == typeid).FirstOrDefault();
        }



        public static List<object> getMakeupDetailList()
        {
            var makeupDetails = (
                from m in db.Makeups
                join mt in db.MakeupTypes on m.MakeupTypeID equals mt.MakeupTypeID
                join mb in db.MakeupBrands on m.MakeupBrandID equals mb.MakeupBrandID
                select new
                {
                    m.MakeupName,
                    m.MakeupPrice,
                    m.MakeupWeight,
                    mt.MakeupTypeName,
                    mb.MakeupBrandName
                }
            ).ToList();

            List<object> MakeupDetailList = makeupDetails.Select(x => (object)new
            {
                MakeupName = x.MakeupName,
                MakeupPrice = x.MakeupPrice,
                MakeupWeight = x.MakeupWeight,
                MakeupTypeName = x.MakeupTypeName,
                MakeupBrandName = x.MakeupBrandName
            }
            ).ToList();

            return MakeupDetailList;
        }
    }
}