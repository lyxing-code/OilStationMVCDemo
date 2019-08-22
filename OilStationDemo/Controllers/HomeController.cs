using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationDemo.Controllers
{
    public class HomeController : Controller
    {
        Models.OSMSEntities DB = new Models.OSMSEntities();

        public ActionResult Index()
        {
            Models.Staff staffinfo = (Models.Staff)Session["loginuser"];
            ViewBag.Name = staffinfo.Name;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string no , string pwd)
        {
            pwd = HelperTools.EncryptHelper.Encode(pwd);
           
            Models.Staff staffInfo = DB.Staff.FirstOrDefault(o => o.No.Equals(no) && o.Password.Equals(pwd));
           
            if (string.IsNullOrEmpty(no) || string.IsNullOrEmpty(pwd))
            {
                var result = new
                {
                    LoginOk = false,
                    Message = "账号密码不能为空!",
                    StaffInfo = staffInfo
                };
                return Json(result);
            }
            else if (staffInfo == null)
            {
                var result = new
                {
                    LoginOk = false,
                    Message = "密码错误!",
                    StaffInfo = staffInfo
                };
                return Json(result);
            }
            else
            {
                var result = new
                {
                    LoginOk = true,
                    Message = "登录成功!",
                    StaffInfo = staffInfo
                };
                Session["loginuser"] = staffInfo;
                return Json(result);
                
            }

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        



    }
}