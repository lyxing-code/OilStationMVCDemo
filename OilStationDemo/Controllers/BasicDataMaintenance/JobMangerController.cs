using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationDemo.Controllers.BasicDataMaintenance
{
    public class JobMangerController : Controller
    {
        Models.OSMSEntities DB = new Models.OSMSEntities();
        // GET: BasicDataMaintenance DeleteById
        public ActionResult Index(bool selected = false)
        {
            //用来控制浏览和操作的控制
            ViewBag.SelectStatus = selected ? "1" : "0";
            return View();
        }

        //职位展示
        public ActionResult ShowJobInfo(int page, int limit, string jobName, string jobCode)
        {
            //创建委托实现过滤条件
            Func<Models.Job, bool> filter = b =>
            {
                bool jobnameok = true, jobcodeok = true;
                if(!string.IsNullOrEmpty(jobName))
                    jobnameok = b.Name.Contains(jobName);
                
               if (!string.IsNullOrEmpty(jobCode))
                    jobcodeok = b.Code.Contains(jobCode);
                

                return jobnameok && jobcodeok;
            };

            var list = DB.Job.Where(filter).Skip((page-1)*limit).Take(limit).ToList();

                var jsonlist = new
                {
                    code = 0,
                    msg = "",
                    data = list,
                    count = DB.Job.Where(filter).Count()    
                }; 
            return Json(jsonlist,JsonRequestBehavior.AllowGet);
        }

        //添加职位视图
        public ActionResult AddJobInfo()
        {
            return View();
        }

        [HttpPost]//请求添加方法
        public ActionResult AddJobInfo(Models.Job job)
        {
            job.Id = Guid.NewGuid();
            job.CreateTime = DateTime.Now;
            job.UpdateTime = DateTime.Now;
            job.IsDel = false;
            DB.Job.Add(job);
            int rs = DB.SaveChanges();
            return Content(rs>0 ? "T" : "F");
        }

        //删除职位方法
        public ActionResult DeleteById(Guid gid)
        {
            Models.Job obj = DB.Job.FirstOrDefault(o => o.Id.Equals(gid));
            DB.Job.Remove(obj);
            int rs = DB.SaveChanges();
            return Content(rs > 0 ? "T" : "F");
        }

        //修改职位视图
        public ActionResult UpdateJobInfo(Guid gid)
        {
            Models.Job obj = DB.Job.FirstOrDefault(o => o.Id.Equals(gid));
            return View(obj);
        }

        //修改职位方法
        public ActionResult UpdateAction(Models.Job obj)
        {
            Models.Job newValue = DB.Job.FirstOrDefault(o => o.Id.Equals(obj.Id));
            newValue.UpdateTime = DateTime.Now;
            UpdateModel(newValue);
            int rs =   DB.SaveChanges();
            return Content(rs > 0 ? "T" : "F");
        }

    }
}