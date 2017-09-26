using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PagedList;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class SystemManageController : BaseController
    {
        //系统管理
        // GET: /PersonManage/
        UserManageBLL umbll = new UserManageBLL();
        BuildTimeBLL bbll = new BuildTimeBLL();
        WorkUnitBLL wbll = new WorkUnitBLL();
        RoleBLL rbll = new RoleBLL();


        public ActionResult Index()
        {
            return View();

        }

        #region 用户管理

        #region UserManage
        
        //public ActionResult UserManage(int pageIndex = 1)
        //{
            
        //    //全部内部用户
        //    List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
        //    //List<DT_UserLoginRecord> allusers = umbll.SelectUsersPage((int)page, (int)rows);
        //    ViewBag.allusers = allusers;

        //    //全部单位
        //    List<DT_WorkUnit> units = wbll.SelUnitByParent();
        //    ViewBag.units = units;

        //    //全部科室
        //    List<DT_WorkUnit> depts = wbll.SelDeptByParent();
        //    ViewBag.depts = depts;

        //    //全部角色
        //    List<DT_Role> rlist = rbll.SelectRoles();

        //    ViewBag.rlist = rlist;

        //    IPagedList<DT_UserLoginRecord> modelUser_InfoList = umbll.SelectAllByPagerByFunc(pageIndex, 2).ToPagedList(5,5); 
        //    //User_InfoBLL.getMvcPageDataList(x => x.User_ID > 1, x => x.Create_Date, pageIndex, 2);

        //    return View(modelUser_InfoList);


        //  //  return View();
        //}

        #endregion


        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>     
        public ActionResult UserManage(int? page, int? rows)
        {
            if (page == null)
            {
                page = 1;

            }
            if (rows == null)
            {
                rows = 10;
            }
            ViewBag.allpages = null;
            if (umbll.GetCount() % rows == 0)
            {
                ViewBag.allpages = umbll.GetCount() / rows;
            }
            else
            {
                ViewBag.allpages = (umbll.GetCount() / rows) + 1;
            }
            ViewBag.rows = rows;
            ViewBag.cupage = page;

            //全部内部用户
            //List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
            List<DT_UserLoginRecord> allusers = umbll.SelectUsersPage((int)page, (int)rows);
            ViewBag.allusers = allusers;

            //全部单位
            List<DT_WorkUnit> units = wbll.SelUnitByParent();
            ViewBag.units = units;

            //全部科室
            List<DT_WorkUnit> depts = wbll.SelDeptByParent();
            ViewBag.depts = depts;

            //全部角色
            List<DT_Role> rlist = rbll.SelectRoles();

            ViewBag.rlist = rlist;

            //  var persons = (from p in DT_UserLoginRecord orderby p.ID descending select p).Skip((pageIndex - 1) * pageSize).Take(pageSize);  

            return View();
        }

        //public ActionResult UserManage(int? id=1)
        //{
            

        //    //全部内部用户
        //    List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
            
        //    ViewBag.allusers = allusers;

        //    //全部单位
        //    List<DT_WorkUnit> units = wbll.SelUnitByParent();
        //    ViewBag.units = units;

        //    //全部科室
        //    List<DT_WorkUnit> depts = wbll.SelDeptByParent();
        //    ViewBag.depts = depts;

        //    //全部角色
        //    List<DT_Role> rlist = rbll.SelectRoles();

        //    ViewBag.rlist = rlist;

        //    return View();
        //}


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u"></param>
        public void _AddUser(DT_UserLoginRecord u)
        {
            Tools t = new Tools();

            DT_UserLoginRecord ul = new DT_UserLoginRecord();
            ul.RealName = u.RealName;
            ul.WorkUnitId = u.WorkUnitId;
            ul.DeptId = u.DeptId;
            ul.IsCadre = u.IsCadre;//是否科级干部          
            ul.IsInner = true; //是否内部成员 是
            ul.Telphone = u.Telphone;
            ul.Password =t.GetMd5(u.Password)  ;
            ul.RoleId = u.RoleId;  //用户权限  
            ul.AddTime = DateTime.Now;
            ul.Status = true;//添加用户时，账号状态默认为true
            
            int count = umbll.AddUser(ul);

            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="u"></param>
        public void _UpdUser(DT_UserLoginRecord u)
        {
            Tools t = new Tools();

            //根据id修改
            DT_UserLoginRecord ul = umbll.QueryById(u.Id);
            ul.RealName = u.RealName;
            ul.WorkUnitId = u.WorkUnitId;
            ul.DeptId = u.DeptId;           
            ul.IsCadre = u.IsCadre;//是否科级干部           
            ul.IsInner = true; //是否内部成员 是
            ul.Telphone = u.Telphone;
            ul.Password =t.GetMd5(u.Password);
            ul.RoleId = u.RoleId;  //用户权限       
            ul.UpdateTime = DateTime.Now;

            int count = umbll.UpdUser(ul);

            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="u"></param>
        public void _DelUser(int id)
        {
            DT_UserLoginRecord u = umbll.QueryById(id); //quabll.QueryPayByRole(id);

            int count = umbll.DelUser(u);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/UserManage';</script>");
            }
        }


        /// <summary>
        /// 禁用用户状态
        /// </summary>
        /// <param name="u"></param>
        public void _ForbiddenStatus(int id)
        { 
            //根据id修改
            DT_UserLoginRecord ul = umbll.QueryById(id);
            ul.Status = false;

            int count = umbll.UpdUser(ul);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('该用户已被禁用，无权再登录系统！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/UserManage';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('禁用失败，请重试！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/UserManage';</script>");
            }
            //Response.End();
        }

        /// <summary>
        /// 启用用户状态
        /// </summary>
        /// <param name="u"></param>
        public void _OpenStatus(int id)
        {
            //根据id修改
            DT_UserLoginRecord ul = umbll.QueryById(id);
            ul.Status = true;

            int count = umbll.UpdUser(ul);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('该用户已被启用，可再次登录系统！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/UserManage';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('启用失败，请重试！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/UserManage';</script>");
            }
            //Response.End();
        }

        #endregion

        #region 单位设置
        public ActionResult WorkUnit()
        {
            //全部单位
            List<DT_WorkUnit> units = wbll.SelUnitByParent();
            ViewBag.units = units;

            //全部科室
            List<DT_WorkUnit> depts = wbll.SelDeptByParent();
            ViewBag.depts = depts;

            return View();
        }
        #region 单位
        /// <summary>
        /// 添加单位
        /// </summary>
        /// <param name="u"></param>
        public void _AddUnit(DT_WorkUnit w)
        {
            DT_UserLoginRecord u=(DT_UserLoginRecord)Session["user"];

            DT_WorkUnit wu = new DT_WorkUnit();
            wu.UnitName = w.UnitName;
            wu.AddUnitTime = DateTime.Now;
            wu.CreateUnit = u.Telphone;

            int count = wbll.AddUnit(wu);
            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();

        }
        /// <summary>
        /// 修改单位
        /// </summary>
        /// <param name="u"></param>
        public void _UpdUnit(DT_WorkUnit w)
        {
            //根据id修改
            DT_WorkUnit wu = wbll.QueryById(w.Id);
            wu.UnitName = w.UnitName;
            wu.UpdDeptTime = DateTime.Now;

            int count = wbll.UpdUnit(wu);
            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 删除单位
        /// </summary>
        /// <param name="u"></param>
        public void _DelUnit(int id)
        {
            DT_WorkUnit wu = wbll.QueryById(id);
            int count = wbll.DelUnit(wu);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/WorkUnit';</script>");
            }
        }
        #endregion

        #region 科室
        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="u"></param>
        public void _AddDept(DT_WorkUnit w)
        {
            DT_UserLoginRecord u = (DT_UserLoginRecord)Session["user"];

            DT_WorkUnit wu = new DT_WorkUnit();            
            wu.UnitName = w.UnitName;
            wu.ParentId = w.ParentId;
            wu.AddDeptTime = DateTime.Now;
            wu.CreateDept = u.Telphone;

            int count = wbll.AddUnit(wu);
            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();

        }
        /// <summary>
        /// 修改科室
        /// </summary>
        /// <param name="u"></param>
        public void _UpdDept(DT_WorkUnit w)
        {
            //根据id修改
            DT_WorkUnit wu = wbll.QueryById(w.Id);
            wu.UnitName = w.UnitName;
            wu.UpdDeptTime = DateTime.Now;          

            int count = wbll.UpdUnit(wu);
            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="u"></param>
        public void _DelDept(int id)
        {
            DT_WorkUnit wu = wbll.QueryById(id);
            int count = wbll.DelUnit(wu);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/WorkUnit';</script>");
            }
        }


        #endregion

        #endregion

        #region 建档时间管理


        #region 时间分页
     
        public void SelectTime(string page,string row)
        {
            int allcount = 1;
            List<DT_BuildTime> timelist = bbll.GetTimeList(Convert.ToInt32(page),Convert.ToInt32(row),out allcount);
            JavaScriptSerializer jss = new JavaScriptSerializer();

            Response.Write(jss.Serialize(new {allcount=allcount,timelist=timelist }));
            Response.End();
        
        }


        #endregion




        public ActionResult BuildTime()
        {
            List<DT_BuildTime> times = bbll.SelectTimes();

            ViewBag.times = times;


            return View();
        }

        /// <summary>
        /// 添加建档时间
        /// </summary>
        /// <param name="u"></param>
        public void _AddTime(DT_BuildTime b)
        {
            DT_BuildTime bu = new DT_BuildTime();
            bu.BuildStartTime = b.BuildStartTime;
            bu.BuildEndTime = b.BuildEndTime;
            bu.AddTime = DateTime.Now;

            int count = bbll.AddTime(bu);

            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 修改建档时间
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTime(DT_BuildTime b)
        {
            //根据id修改
            DT_BuildTime bu = bbll.QueryById(b.Id);
            bu.BuildStartTime = b.BuildStartTime;
            bu.BuildEndTime = b.BuildEndTime;
            bu.UpdateTime = DateTime.Now;

            int count = bbll.UpdTime(bu);

            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 删除建档时间
        /// </summary>
        /// <param name="u"></param>
        public void _DelTime(int id)
        {
            DT_BuildTime bu = bbll.QueryById(id);
            int count = bbll.DelTime(bu);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/BuildTime';</script>");
            }
        }



        #endregion


        #region 角色管理
        public ActionResult RoleManage()
        {
           List<DT_Role> rlist= rbll.SelectRoles();

           ViewBag.rlist = rlist;

            return View();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="u"></param>
        public void _AddRole(DT_Role r)
        {
            DT_Role ro = new DT_Role();
            ro.Id = r.Id;
            ro.Name = r.Name;
            ro.Remark = r.Remark;

            int count = rbll.AddRole(r);

            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="u"></param>
        public void _UpdRole(DT_Role r)
        {
            
            DT_Role ro = rbll.SelectOneRoleByid(r.Id);
            ro.Id = r.Id;
            ro.Name = r.Name;
            ro.Remark = r.Remark;
            int count = rbll.UpdateRole(ro);

            if (count > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            Response.End();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="u"></param>
        public void _DelRole(int id)
        {
            DT_Role ro = rbll.SelectOneRoleByid(id);

            int count = rbll.DelRole(ro);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/SystemManage/RoleManage';</script>");
            }
        }



        #endregion

        
        #region 修改密码
        //修改密码
        public ActionResult UpdatePwd()
        {
            return View();

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public string UpdPwd(string oldpwd, string newpwd)
        {
            bool result = umbll.IfRight((string)Session["tel"],oldpwd);  

            if (result == true)
            {
                if (umbll.UpdatePwd((string)Session["tel"], newpwd)>0)
                {
                    return "ok";
                }
                else
                {
                    return "fail";
                }
            }
            else
            {
                return "error";
            }
        }
        #endregion


        #region 分页
        public void PageList()
        {

            int page = 1;
            if (Request["page"] != null)
            {
                page = Convert.ToInt32(Request["page"]);
            }

            int allcount = umbll.GetCount();
            List<DT_UserLoginRecord> ulist = umbll.SelectAllByPagerByFunc(page, Convert.ToInt32(Request["pagerows"]));

            DTO_UserManage um = new DTO_UserManage();
            um.allcount = allcount;
            um.ulist = ulist;
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Response.Write(ser.Serialize(um));
            Response.End();
        
        }


        public void PageCount()
        {
            int count = umbll.GetCount();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Response.Write(ser.Serialize(count));
            Response.End();
        }




        #endregion

    
    }
}
