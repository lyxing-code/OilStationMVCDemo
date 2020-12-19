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
            ParentMenu();
            return View();
            
        }

        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="no">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>json</returns>
        [HttpPost]
        public ActionResult Login(string no , string pwd)
        {
            //pwd = HelperTools.EncryptHelper.Encode(pwd);
           
            Models.Staff staffInfo = DB.Staff.FirstOrDefault(o => o.No.Equals(no) && o.Password.Equals(pwd));
           
            if (string.IsNullOrEmpty(no) || string.IsNullOrEmpty(pwd))
            {
                return ReturnJosn(false, "账号密码不能为空!", staffInfo);
            }
            else if (staffInfo == null)
            {
                
                return ReturnJosn(false, "密码错误!", staffInfo);
            }
            else
            {
                
                Session["loginuser"] = staffInfo;
                return ReturnJosn(false, "登录成功!", staffInfo);

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


        /// <summary>
        /// 用来获取用户登录信息
        /// </summary>
        /// <param name="loginOk">是否成功登录</param>
        /// <param name="message">提示信息</param>
        /// <param name="staffInfo">用户信息</param>
        /// <returns></returns>
        public ActionResult ReturnJosn(bool loginOk,string message,Models.Staff staffInfo)
        {

            var result = new
            {
                LoginOk = loginOk,
                Message = message,
                StaffInfo = staffInfo
            };
            return Json(result);
        }

        /// <summary>
        /// 加载父级菜单
        /// </summary>
        public void ParentMenu()
        {
            Models.Staff staffinfo = (Models.Staff)Session["loginuser"];
            List<Models.v_staffmune> menu = DB.v_staffmune.Where(o => o.staffid.Equals(staffinfo.Id) && o.Type == 0 && o.ParentId == null ).ToList();
            ViewData.Model = menu;
        }

        /// <summary>
        /// 加载子级菜单
        /// </summary>
        /// <param name="parentmeunid">与parentid对应的父子级关系id</param>
        /// <returns></returns>
        public ActionResult ChildMenu(string parentmeunid)
        {
            Models.Staff staffinfo = (Models.Staff)Session["loginuser"];
            List<Models.v_staffmune> menu = DB.v_staffmune.Where(o => o.staffid.Equals(staffinfo.Id) && o.ParentId.ToString().Equals(parentmeunid)).ToList();
            return Json(menu);
        }

    }
}