using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
               
            UserBLL ubll = new UserBLL();
            WorkUnitBLL wbll = new WorkUnitBLL();
            UserManageBLL umbll = new UserManageBLL();
            ShareBLL sbll = new ShareBLL();
            BuildTimeBLL bbll = new BuildTimeBLL();
            TotalBLL tbll = new TotalBLL();

            DT_UserLoginRecord u = filterContext.HttpContext.Session["user"] as DT_UserLoginRecord;
            //没有登录则不能访问
            if (u==null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
            else
            {
                ViewBag.username = u.Telphone;
                //ViewBag.photo=u
               //是否科级干部
                ViewBag.iscadre= ubll.IsCadre(u.Id);
           
                //登录id
               ViewBag.id = u.Id;
               //用户角色
               ViewBag.role= Session["roleid"];

               //用户是否有共享
               ViewBag.sharestatus= Session["sharestatus"];
             
               //全部单位
               List<DT_WorkUnit> allunits = wbll.SelUnitByParent();
               ViewBag.allunits = allunits;

               //全部科室
               List<DT_WorkUnit> alldepts = wbll.SelDeptByParent();
               ViewBag.alldepts = alldepts;

                //照片
               string img = ubll.GetImg(Convert.ToInt32(Session["id"]));
               ViewBag.img = img;

               //全部内部用户
               List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
               ViewBag.allusers = allusers;

               //根据本人登录id查询其单位id
               ViewBag.SelUnitidByUid= ubll.SelUnitidByUid(Convert.ToInt32(Session["id"]));
               //单位id
              ViewBag.unitid= Session["unitid"];

              //年份
              List<DT_Total> years = sbll.Total().GroupBy(a => a.YearTable).Select(b => new DT_Total { YearTable = b.Key }).ToList();
              ViewBag.years = years;

              //根据添加时间获取最新的建档时间
              ViewBag.buildtime = bbll.GetLastTime();

                //查询全部基本信息表
                List<DT_UserInfo> userinfolist1=ubll.SelectUserInfo();
                ViewBag.userinfolist1 = userinfolist1;
                 
                //根据登录id和年份查询出年份
               ViewBag.yeartable= tbll.SelectYear(Convert.ToInt32(Session["id"]));


              //根据登录id查询总表status的状态  这里主要是根据status为“被退回”来判断
              //修改二次修改,点击“保存”时,同时修改status为“未提交”,可再次提交 (注意年份)
              ViewBag.status = ubll.SelStatus(Convert.ToInt32(Session["id"]));

            
            }

        }

      
    }
}
