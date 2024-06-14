using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Factories
{
    public class MakeupFactory
    {

        public static MakeupType createMakeupType(string type)
        {
            MakeupType makeupType = new MakeupType();
            makeupType.MakeupTypeName = type;
            return makeupType;
        }

        public static Makeup createMakeup(string name, string price, string weight, string makeuptypeid, string makeupbrandid)
        {
            int typeId = Convert.ToInt32(makeuptypeid);
            int brandId = Convert.ToInt32(makeupbrandid);
            int weightt = Convert.ToInt32(weight);
            int pricee = Convert.ToInt32(price);
            Makeup makeup = new Makeup();
            makeup.MakeupName = name;
            makeup.MakeupPrice = pricee;
            makeup.MakeupWeight = weightt;
            makeup.MakeupTypeID = typeId;
            makeup.MakeupBrandID = brandId;
            return makeup;
        }
    }
}