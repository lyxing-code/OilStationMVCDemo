using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationDemo.Controllers.BasicDataMaintenance
{
    public class OrganizationMangerController : Controller
    {
        Models.OSMSEntities DB = new Models.OSMSEntities();
        // GET: OrganizationManger
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrganizeTreeData()
        {
            DB.Configuration.LazyLoadingEnabled = false;
            List<Models.v_Organization> list= DB.v_Organization.ToList();
            var jsontreelist = new
            {
                code = 0,
                msg = "",
                data = list,
                count = list.Count()
            };
            return Json(jsontreelist, JsonRequestBehavior.AllowGet);
        }
        


    }
}