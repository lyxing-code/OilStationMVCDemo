using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationDemo.Controllers
{
    public class StaffManageController : Controller
    {
        Models.OSMSEntities DB = new Models.OSMSEntities();
        // GET: StaffManage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 员工信息展示方法(带分页)
        /// </summary>
        /// <param name="page">起始页(从1开始)</param>
        /// <param name="limit">信息条数</param>
        /// <param name="Name">名字查询条件</param>
        /// <param name="No">编号查询条件</param>
        /// <returns>json</returns>
        public ActionResult Staffinfo(int page,int limit,string Name,string No)
        {

            Func<Models.v_staffinfo, bool> func = m =>
             {
                 bool NameOk = true;
                 bool NoOk = true;
                 NameOk = string.IsNullOrEmpty(Name)? true : (string.IsNullOrEmpty(m.Name) ? false : m.Name.Contains(Name));
                 NoOk = string.IsNullOrEmpty(No) ? true : (string.IsNullOrEmpty(m.No) ? false : m.No.Contains(No));
                 return NameOk && NoOk;
             };

            List<Models.v_staffinfo> list = DB.v_staffinfo.OrderBy(o=>o.Id).Where(func).Skip((page-1)*limit).Take(limit).ToList();


            var jsonlist = new
            {
                code = 0,
                msg = "",
                data = list,
                count = DB.v_staffinfo.Count()
            };
            return Json(jsonlist, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddStaffInfo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddStaffInfo(Models.Staff staffinfo)
        {
            staffinfo.Id = Guid.NewGuid();
            staffinfo.CreateTime = DateTime.Now;
            staffinfo.UpdateTime = DateTime.Now;
            staffinfo.IsHSEGroup = false;
            staffinfo.Sex = Request.Form[3] == (0).ToString() ? false : true;
            staffinfo.Password = HelperTools.EncryptHelper.Encode("svse");//默认密码(svse)
            DB.Staff.Add(staffinfo);
            return Content(DB.SaveChanges() > 0 ? "T" : "F");
        }


    }
}