using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class ShareFileController : BaseController
    {
        //共享档案
        // GET: /ShareFile/
        TotalBLL tbll = new TotalBLL();
        UserBLL ubll = new UserBLL();
        UserManageBLL umbll = new UserManageBLL();
        ShareBLL sbll = new ShareBLL();

        /// <summary>
        /// 共享首页
        /// </summary>
        /// <returns></returns>
        public ActionResult ShareIndex()
        {
            //FileStutus为“已归档”的总表 
            List<DT_Total> filedlist = tbll.SelTotalsByFiled();
            ViewBag.filedlist = filedlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            return View();
        }
        /// <summary>
        /// 单人共享
        /// </summary>
        /// <returns></returns>
        public ActionResult ShareSingle(int tid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;
            //根据id查询所有内部登录用户
            List<DT_UserLoginRecord> ulist = umbll.QueryUinfoById(tid);
            ViewBag.ulist = ulist;

            return View();
        }





        /// <summary>
        /// 共享历史记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ShareRecord(int sid=0)
        {
            //--根据传进来的shareid查询到BeShareId的集合
            ViewBag.beshareids= sbll.GetBeShareIds(sid);
            //--根据传进来的shareid查询到最新一条记录
            ViewBag.oneshare= sbll.GetOneShare(sid);
            
            //
            List<DT_BeShared> beshared = sbll.SelBeShared();
            ViewBag.beshared = beshared;

            //所有共享记录
            List<DT_Share> slist = sbll.SelectShare();
            ViewBag.slist = slist;

            //所有系统内用户
            List<DT_UserLoginRecord> inners = sbll.SelInners();
            ViewBag.inners = inners;

            //所有系统外用户
            List<DT_UserLoginRecord> foreigns = sbll.SelForeign();
            ViewBag.foreigns = foreigns;

            //根据共享人id查询记录
            List<DT_Share> shares = sbll.SelShares(sid);
            ViewBag.shares = shares;

            //查询所有角色为0的用户
            List<DT_UserLoginRecord> selroles = sbll.SelRoles();
            ViewBag.selroles = selroles;

            //共享开始时间分组
            List<DT_Share> times=sbll.SelectShare().GroupBy(a=>a.ShareBeginTime).Select(b=>new DT_Share{ShareBeginTime=b.Key}).ToList();          

            foreach (var item in times)
            {
                ViewBag.times = item.ShareBeginTime;
            }
            ViewBag.times2 = ViewBag.times;
            

            return View();
        }
        /// <summary>
        /// 添加共享历史记录
        /// </summary>DT_Share s
        public void _AddShareRecord(string userids, int year, DateTime begintime, DateTime endtime, string sharedids)
        {
           
            string[] uids = userids.Split(',');  //共享人
            string[] sids = sharedids.Split(',');  //被共享人

            for (int i = 0; i < uids.Length; i++)
            {
               
                for (int j = 0; j < sids.Length; j++)
                {
                    DT_Share sh = new DT_Share();
                    
                    sh.ShareId = Convert.ToInt32(uids[i]);

                    _UpdShareRoleId(Convert.ToInt32(uids[i]));

                    sh.BeSharedId = Convert.ToInt32(sids[j]);
                 
                    sh.SharedYear = year;
                    sh.ShareBeginTime = begintime;
                    sh.ShareEndTime = endtime;

                    sh.CreateTime = DateTime.Now;

                    int count = sbll.AddShare(sh);

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
            } 
        }

        /// <summary>
        /// 修改共享历史记录
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdShareRecord(int id)
        {
            //DT_Share s = sbll.SelectShareById(id);

            List<DT_Share> shares = sbll.SelSharesById(id);


            List<DT_BeShared> beshared = sbll.SelBeShared();
            ViewBag.beshared = beshared;

            //所有共享记录
            List<DT_Share> slist = sbll.SelectShare();
            ViewBag.slist = slist;

            //所有系统内用户
            List<DT_UserLoginRecord> inners = sbll.SelInners();
            ViewBag.inners = inners;

            //所有系统外用户
            List<DT_UserLoginRecord> foreigns = sbll.SelForeign();
            ViewBag.foreigns = foreigns;

            return View();
        }

        /// <summary>
        /// 设置共享页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SetShare()
        {
            //共享人
            List<DT_SharePeople> sharepeople = sbll.SelSharePeople();
            ViewBag.sharepeople = sharepeople;


            //被共享人
            List<DT_BeShared> beshared = sbll.SelBeShared();
            ViewBag.beshared = beshared;

            //年份
            List<DT_Total> years = sbll.Total().GroupBy(a => a.YearTable).Select(b => new DT_Total { YearTable = b.Key }).ToList();
            ViewBag.years = years;

            //全部内部用户
            List<DT_UserLoginRecord> foreigns = sbll.SelForeign();
            ViewBag.foreigns = foreigns;

            //FileStutus为“已归档”的总表 
            List<DT_Total> filedlist = tbll.SelTotalsByFiled();
            ViewBag.filedlist = filedlist;

           // List<DT_Total> years = sbll.SelYears();
           // ViewBag.years = years;

            return View();
        }

        /// <summary>
        /// 修改外部共享人的roleid:0
        /// </summary>
        /// <param name="id"></param>
        public void _UpdShareRoleId(int id)
        {
            DT_UserLoginRecord updrole = sbll.QueryUserByid(id);
           // updrole.RoleId = 0;
            updrole.ShareStatus = "是";
            sbll.UpdShareRoleId(updrole);
        
        }


        /// <summary>
        /// 添加共享人
        /// </summary>
        /// <param name="spid"></param>
        public void _AddSharePeople(int spid)
        {
            DT_SharePeople sp = new DT_SharePeople();
            sp.ShareId = spid;

            int count = sbll.AddSharePeople(sp);

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
        /// 添加被共享人
        /// </summary>
        /// <param name="spid"></param>
        public void _AddBeShared(int bsid)
        {
            DT_BeShared bs = new DT_BeShared();
            bs.BeSharedId = bsid;

           sbll.AddBeShared(bs);
         
        }

        /// <summary>
        /// 删除被共享人
        /// </summary>
        /// <param name="spid"></param>
        public void _DelBeShared(int bsid)
        {
            DT_BeShared bs = sbll.SelBeSharedId(bsid);
           
            sbll.DelBeShared(bs);
 
        }




        #region 系统外用户
        /// <summary>
        /// 添加系统外用户
        /// </summary>
        /// <param name="u"></param>
        public void _AddUser(DT_UserLoginRecord u)
        {
            Tools t = new Tools();

            DT_UserLoginRecord ul = new DT_UserLoginRecord();
            ul.RealName = u.RealName;
            ul.Telphone = u.Telphone;
            ul.Password = t.GetMd5(u.Password);
            ul.IsInner = false; //是否内部成员 是
            ul.RoleId = 0;  //用户角色为0，表示系统外 
            ul.AddTime = DateTime.Now;
            ul.Status = true;//添加用户时，账号状态默认为true
           // ul.ShareStatus = "是";

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
        /// 修改系统外用户
        /// </summary>
        /// <param name="u"></param>
        public void _UpdUser(DT_UserLoginRecord u)
        {
            Tools t = new Tools();

            //根据id修改
            DT_UserLoginRecord ul = umbll.QueryById(u.Id);
            ul.RealName = u.RealName;
            ul.Telphone = u.Telphone;
            ul.Password = t.GetMd5(u.Password);

            //ul.IsInner = false; //是否内部成员 是           
            //ul.RoleId =0;  //用户权限       

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
        /// 删除系统外用户
        /// </summary>
        /// <param name="u"></param>
        public void _DelUser(int id)
        {
            DT_UserLoginRecord u = umbll.QueryById(id); //quabll.QueryPayByRole(id);

            int count = umbll.DelUser(u);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/ShareFile/SetShare';</script>");
            }
        }
        #endregion

    }
}
