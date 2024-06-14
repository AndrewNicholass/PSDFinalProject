using PSDFinalProject.Handlers;
using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Controllers
{
    public class MakeupController
    {
        public static List<object> showAllMakeupDetails()
        {
            return MakeupHandler.getAllMakeupDetails();
        }

        public static
    }
}