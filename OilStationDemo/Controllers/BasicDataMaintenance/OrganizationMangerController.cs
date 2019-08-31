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
        public ActionResult Index(bool selected = false)
        {
            //用来控制浏览和操作的控制
            ViewBag.SelectStatus = selected ? "1" : "0";
            return View();
        }

        /// <summary>
        /// 加载组织结构
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 预加载在那个区域添加组织结构
        /// </summary>
        /// <param name="gid">上级组织结构的Id</param>
        /// <returns></returns>
        public ActionResult AppendOrganize(Guid gid)
        {
            Models.v_Organization org = DB.v_Organization.FirstOrDefault(o => o.Id.Equals(gid));
            org.Leve += 1;
            if (org.Leve == 0)
            {
                ViewBag.Leve = "总部";
            }
            else if(org.Leve == 1)
            {
                ViewBag.Leve = "大区";
            }
            else if (org.Leve == 2)
            {
                ViewBag.Leve = "区域";
            }
            else if(org.Leve == 3)
            {
                ViewBag.Leve = "加油站";
            }
            else
            {
                ViewBag.Leve = "其他";
            }
            return View(org);
        }

        /// <summary>
        /// 添加组织方法
        /// </summary>
        /// <param name="organization">组织对象</param>
        /// <returns>Text</returns>
        [HttpPost]
        public ActionResult AppendOrganize(Models.OrganizationStructure organization)
        {
            organization.Id = Guid.NewGuid();
            organization.CreateTime = DateTime.Now;
            organization.UpdateTime = DateTime.Now;
            DB.OrganizationStructure.Add(organization);
            return Content(DB.SaveChanges() > 0 ? "T" : "F");
        }



        /// <summary>
        /// 预加载在那个区域修改组织结构的信息
        /// </summary>
        /// <param name="gid">上级组织结构的Id</param>
        /// <returns></returns>
        public ActionResult UpdateOrganize(Guid gid)
        {
            Models.v_Organization org = DB.v_Organization.FirstOrDefault(o => o.Id.Equals(gid));
            if (org.Leve == 0)
            {
                ViewBag.Leve = "总部";
            }
            else if (org.Leve == 1)
            {
                ViewBag.Leve = "大区";
            }
            else if (org.Leve == 2)
            {
                ViewBag.Leve = "区域";
            }
            else if (org.Leve == 3)
            {
                ViewBag.Leve = "加油站";
            }
            else
            {
                ViewBag.Leve = "其他";
            }
            return View(org);
        }


        /// <summary>
        /// 修改组织方法
        /// </summary>
        /// <param name="organization">组织对象</param>
        /// <returns>Text</returns>
        [HttpPost]
        public ActionResult UpdateOrganize(Models.OrganizationStructure organization)
        {
            Models.OrganizationStructure obj = DB.OrganizationStructure.FirstOrDefault(o => o.Id.Equals(organization.Id)); ;
            organization.UpdateTime = DateTime.Now;
            obj.Leve = organization.Leve;
            obj.Name = organization.Name;
            obj.Code = organization.Code;
            DB.OrganizationStructure.Attach(obj);
            DB.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return Content(DB.SaveChanges() > 0 ? "T" : "F");
        }



        //删除节点
        public ActionResult DeleteById(Guid gid)
        {
            Models.OrganizationStructure obj = DB.OrganizationStructure.FirstOrDefault(o => o.Id.Equals(gid));
            FindDeleteChild(obj);
            return Content(DB.SaveChanges() > 0 ? "T" : "F");
        }

        /// <summary>
        /// 递归删除节点
        /// </summary>
        /// <param name="node"></param>
        private void FindDeleteChild(Models.OrganizationStructure node)
        {
            node.IsDel = true;
            DB.OrganizationStructure.Attach(node);
            DB.Entry(node).State = System.Data.Entity.EntityState.Modified;
            Func<Models.OrganizationStructure, bool> filter = m => {
                if (m.ParentId == null)
                    return false;

                return m.ParentId.Equals(node.Id);
            };
            //获取子节点
            List<Models.OrganizationStructure> list = DB.OrganizationStructure.Where(filter).ToList();
            //递归调用 删除子级组织
            foreach (Models.OrganizationStructure item in list)
                FindDeleteChild(item);
        }

    }
}