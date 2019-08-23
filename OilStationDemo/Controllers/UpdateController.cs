using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationDemo.Controllers
{
    public class UpdateController : Controller
    {
        Models.OSMSEntities DB = new Models.OSMSEntities();
        // GET: Update
        public ActionResult UpdatePwd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePwd(string OldPassword,string NewPassword)
        {
            Models.Staff staffinfo = (Models.Staff)Session["loginuser"];
            OldPassword = HelperTools.EncryptHelper.Encode(OldPassword);
            Models.Staff info = DB.Staff.FirstOrDefault(o => o.Password == OldPassword);

            if (info == null)
            {
                var json = new
                {
                    Error = false,
                    Message = "原密码错误!",
                };
                return Json(json);
            }
            else
            {

              Models.Staff staff = DB.Staff.FirstOrDefault(o => o.No == staffinfo.No);
              staff.Password = HelperTools.EncryptHelper.Encode(NewPassword);
              UpdateModel(staff);
              int rs =  DB.SaveChanges();
                if (rs > 0)
                {
                    var json = new
                    {
                        Error = true,
                        Message = "修改成功! 登录信息已经过期!",
                    };
                    return Json(json);
                }
                else
                {
                    var json = new
                    {
                        Error = false,
                        Message = "修改失败!",
                    };
                    return Json(json);
                }
              
            }

        }



    }
}