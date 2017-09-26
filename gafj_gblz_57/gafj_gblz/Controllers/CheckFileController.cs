using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class CheckFileController : BaseController
    {
        //审核档案
        // GET: /CheckFile/
        TotalBLL tbll = new TotalBLL();
        WorkUnitBLL wbll = new WorkUnitBLL();
        RoleBLL rbll = new RoleBLL();
        UserManageBLL umbll = new UserManageBLL();
        UserBLL ubll = new UserBLL();
        ProfitReportBLL pbll = new ProfitReportBLL();
        MarryChangeBLL mcbll = new MarryChangeBLL();
        CrimeBLL cbll = new CrimeBLL();
        WeddingDieBLL wdbll = new WeddingDieBLL();
        IndustryChangeBLL icbll = new IndustryChangeBLL();

        ImportantBLL imbll = new ImportantBLL();
        ResponsibilityBLL rsbll = new ResponsibilityBLL();
        LetterCheckBLL lcbll = new LetterCheckBLL();
        AdmonishTalkBLL atbll = new AdmonishTalkBLL();
        IncorruptTalkBLL itbll = new IncorruptTalkBLL();
        ApplyLetterBLL albll = new ApplyLetterBLL();
        RewardPublishBLL rpbll = new RewardPublishBLL();
        RefuseGiftBLL rgbll = new RefuseGiftBLL();
        HouseBLL hbll = new HouseBLL();
        AbroadBLL abll = new AbroadBLL();

        #region 审核用户审核    
          /// <summary>
        /// 审核用户审核页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SelWaits()
        {
            //待审核
            List<DT_Total> Waits = tbll.SelWaitStutus();
            ViewBag.Waits = Waits;

            return View();
        }

        /// <summary>
        /// 审核用户审核页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckUserIndex()
        {
            
            //全部CheckStatus不为空或“”的总表
            List<DT_Total> tlist = tbll.SelTotalsByChkStutus();          
            ViewBag.tlist = tlist;  
           
            //全部基本信息表
            List<DT_UserInfo> userinfolist =ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //全部内部登录用户  basecontroller里有 可以继承
           //List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
           //ViewBag.allusers = allusers;

           //全部单位
           List<DT_WorkUnit> units = wbll.SelUnitByParent();
           ViewBag.units = units;

           //全部科室
           List<DT_WorkUnit> depts = wbll.SelDeptByParent();
           ViewBag.depts = depts;

           //全部角色
           List<DT_Role> rlist = rbll.SelectRoles();
           ViewBag.rlist = rlist;

           //审核用户审核的四种状态
           //待审核
           List<DT_Total> Waits= tbll.SelWaitStutus();
           ViewBag.Waits = Waits;
           //已退回    
           List<DT_Total> Backeds = tbll.SelBackedStutus();
           ViewBag.Backeds = Backeds;
           //已提交
           List<DT_Total> Submits = tbll.SelSubmitStutus();
           ViewBag.Submits = Submits;
           //被退回
           List<DT_Total> BeBackeds = tbll.SelBeBackedStutus();
           ViewBag.BeBackeds = BeBackeds;




            return View();
        }

        /// <summary>
        /// 审核用户审核个人页面
        /// </summary>待审核
        /// <returns></returns>
        public ActionResult CheckUserCheckOne(int tid=0)
        {
            //根据登录id查询基本信息
            List<DT_UserInfo> uslist = ubll.SelectUserInfoByid(tid);
            ViewBag.SelInfoById = uslist;

            //根据总表id查询用户登录id
            ViewBag.t = tbll.SelUidByTid(tid);
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal(); 
            ViewBag.tlist = tlist;            
            //根据id查询所有内部登录用户 
            List<DT_UserLoginRecord> ulist = umbll.QueryUinfoById(tid);
            ViewBag.ulist = ulist;
          
            //根据登录id查询家庭表
            List<DT_FamilyTotal> falist = ubll.SelectFaByUid(tid);
            ViewBag.falist = falist;

            //查询家庭分表
            List<DT_Family> flist = ubll.SelFamily(tid);
            ViewBag.flist = flist;


            //根据登录id查询营利持股表
            List<DT_ProfitReport> profitlist=pbll.SelectProfitByid(tid);
            ViewBag.profitlist = profitlist;

            //根据登录id查询婚姻变化表
            List<DT_MarryChange> marry=mcbll.SelectMarryByUid(tid);
            ViewBag.marry = marry;

            //根据登录id查询犯罪表
            List<DT_CrimeReport> crime = cbll.SelectCrimeByUid(tid);
            ViewBag.crime = crime;

            //根据登录id查询近亲婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wdbll.SelectWeddingDieByUid(tid);
            ViewBag.weddingdie = weddingdie;

            //根据UserId查询从业变更
            List<DT_IndustryChanges> industry = icbll.SelectIndustryByUid(tid);
            ViewBag.industry = industry;

            //根据UserId查询重大事项
            List<DT_Important> important = imbll.SelectImportantByUid(tid);
            ViewBag.important = important;

            //根据UserId查询责任追究
            List<DT_Responsibility> respons = rsbll.SelectResponsByUid(tid);
            ViewBag.respons = respons;

            //根据UserId查询信访核查
            List<DT_PetitionLetter> letterchk = lcbll.SelectLetterChkByUid(tid);
            ViewBag.letterchk = letterchk;

            //根据UserId查询诫勉谈话
            List<DT_AdmonishingTalk> admonish = atbll.SelectAdmonishByUid(tid);
            ViewBag.admonish = admonish;

            //根据UserId查询廉政谈话
            List<DT_IncorruptTalk> incorrupt = itbll.SelectIncorruptByUid(tid);
            ViewBag.incorrupt = incorrupt;

            //根据UserId查询函询情况
            List<DT_ApplyByLetter> apply = albll.SelectApplyByUid(tid);
            ViewBag.apply = apply;

         
         
          

            //全部内部登录用户
            //List<DT_UserLoginRecord> allusers = umbll.SelectUsers();  
            //ViewBag.allusers = allusers;

            return View();
        }
        /// <summary>
        /// 审核用户审核个人基本信息页面
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkUserDetails(int tid=0)
        {             
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //根据Id查询全部基本信息表
            List<DT_UserInfo> uilist = ubll.SelectUInfoByid(tid);
            ViewBag.uilist = uilist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            return View();
        }
       
        /// <summary>
        /// 修改总表的userinfoid
        /// 审核基本信息表通过
        /// </summary>
        public void _UpdTotal(int id,string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoAdvice1 = advice;
            tl.UserInfoPeople1 = (string)Session["realname"];
            tl.UserInfoStatus1 = 1;//1：代表通过
           // tl.UserInfoTime1 = DateTime.Now;
    
           int count= tbll.UpdTotal(tl);
           if (count>0)
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
        /// 修改总表的userinfoid
        /// 审核基本信息表不通过
        /// </summary>
        public void _UpdTotal_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoAdvice1 = advice;
            tl.UserInfoPeople1 = (string)Session["realname"];
            tl.UserInfoStatus1 = 0;//0：代表不通过
            tl.UserInfoTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 审核用户提交党委修改
        /// </summary>
        public void _UpdTotal_Submit(int id)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;           
            tl.UserInfoPeople1 = (string)Session["realname"];
            tl.CheckStatus = "已提交";//审核通过 可以提交
            tl.FileStatus = "待归档";
            tl.ChkSubmitTime = DateTime.Now;//提交时间
           
            int count = tbll.UpdTotal(tl);
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
        /// 审核用户退回本人修改
        /// </summary>
        public void _UpdTotal_BackUpdate(int id)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoPeople1 = (string)Session["realname"];
            tl.CheckStatus = "已退回";//审核用户退回给本人修改  
            tl.Status = "被退回"; //普通用户就是被退回
            tl.BackTime = DateTime.Now;//退回时间
          
            int count = tbll.UpdTotal(tl);
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
  
        #endregion
      
        #region 审核用户审核家庭成员表
        /// <summary>
        /// 审核用户审核家庭成员表
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkFamily(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据id查询所有内部登录用户 
            List<DT_UserLoginRecord> ulist = umbll.QueryUinfoById(tid);
            ViewBag.ulist = ulist;
          
 
           //根据登录id查询家庭成员总表
          // List<DT_FamilyTotal> falist = ubll.SelectFaByUid(tid);
          // ViewBag.falist = falist;


           List<DT_FamilyTotal> falist = ubll.SelectFamilyByid(tid);
           ViewBag.falist = falist;

           //查询家庭分表
           List<DT_Family> flist = ubll.SelFamily(tid);
           ViewBag.flist = flist;

            return View();
        }

        /// <summary>
        /// 修改总表的FamilyId
        /// 审核家庭成员表通过
        /// </summary>
        public void _UpdTotalFamily(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.FamilyAdvice1 = advice;
            tl.FamilyPeople1 = (string)Session["realname"];
            tl.FamilyStatus1 = 1;//1：代表通过
            //tl.FamilyTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的FamilyId
        /// 审核家庭成员表不通过
        /// </summary>
        public void _UpdTotalFamily_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.FamilyAdvice1 = advice;
            tl.FamilyPeople1 = (string)Session["realname"];
            tl.FamilyStatus1 = 0;//0：代表不通过
            tl.FamilyTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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

        #endregion
  
        #region 审核用户审核营业持股表
        /// <summary>
        /// 审核用户审核用户审核营业持股表
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkProfit(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;


            //根据Id查询营利及兼职持股情况报告表
            List<DT_ProfitReport> plist = pbll.SelectProfitReportByid(tid);
            ViewBag.plist = plist;

            return View();
        }

        /// <summary>
        /// 修改总表的ProfitId
        /// 审核营利表通过
        /// </summary>
        public void _UpdTotalProfit(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ProfitAdvice1 = advice;
            tl.ProfitPeople1 = (string)Session["realname"];
            tl.ProfitStatus1 = 1;//1：代表通过
            //tl.ProfitTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的ProfitId
        /// 审核营利表不通过
        /// </summary>
        public void _UpdTotalProfit_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ProfitAdvice1 = advice;
            tl.ProfitPeople1 = (string)Session["realname"];
            tl.ProfitStatus1 = 0;//0：代表不通过
            tl.ProfitTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion

        #region 审核用户审核婚姻变化表
        /// <summary>
        /// 审核用户审核婚姻变化表
        /// </summary>
        /// <returns></returns> int id  int tid = 0
        public ActionResult ChkUserChkMarryChage(int tid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;
            
            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据id查询婚姻变化
           List<DT_MarryChange> marrylist= mcbll.SelectMarryByids(tid);
           ViewBag.marrylist = marrylist;

           return View();
        }

        /// <summary>
        /// 修改总表的MarryChangeId
        /// 审核婚姻变化表通过
        /// </summary>
        public void _UpdTotalMarryChage(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.MarryChgAdvice1 = advice;
            tl.MarryChgPeople1 = (string)Session["realname"];
            tl.MarryChgStatus1 = 1;//1：代表通过
           // tl.MarryChgTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的MarryChangeId
        /// 审核婚姻变化表不通过
        /// </summary>
        public void _UpdTotalMarryChage_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.MarryChgAdvice1 = advice;
            tl.MarryChgPeople1 = (string)Session["realname"];
            tl.MarryChgStatus1 = 0;//0：代表不通过
            tl.MarryChgTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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

        #endregion

        #region 审核用户审核犯罪表
        /// <summary>
        /// 审核用户审核犯罪表
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkCrime(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询干部配偶、子女涉嫌犯罪情况报告
           List<DT_CrimeReport> crimelist= cbll.SelectCrimeByid(tid);
           ViewBag.crimelist = crimelist;

            return View();
        }

        /// <summary>
        /// 修改总表的CrimeId
        /// 审核审核犯罪表通过
        /// </summary>
        public void _UpdTotalCrime(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.CrimeAdvice1 = advice;
            tl.CrimePeople1 = (string)Session["realname"];
            tl.CrimeStatus1 = 1;//1：代表通过
            //tl.CrimeTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的CrimeId
        /// 审核审核犯罪表不通过
        /// </summary>
        public void _UpdTotalCrime_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.CrimeAdvice1 = advice;
            tl.CrimePeople1 = (string)Session["realname"];
            tl.CrimeStatus1 = 0;//0：代表不通过
            tl.CrimeTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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

        #endregion

        #region 审核用户审核婚丧喜庆
        /// <summary>
        /// 审核用户审核婚丧喜庆
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkWeddingDie(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询干部婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wdbll.SelectWeddingDieByid(tid);  
            ViewBag.weddingdie = weddingdie;

            return View();
        }

        /// <summary>
        /// 修改总表的WeddingDieId
        /// 审核审核婚丧喜庆通过
        /// </summary>
        public void _UpdTotalWeddingDie(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.WeddDieAdvice1 = advice;
            tl.WeddDiePeople1 = (string)Session["realname"];
            tl.WeddDieStatus1 = 1;//1：代表通过
            //tl.WeddDieTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的WeddingDieId
        /// 审核审核婚丧喜庆不通过
        /// </summary>
        public void _UpdTotalWeddingDie_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.WeddDieAdvice1 = advice;
            tl.WeddDiePeople1 = (string)Session["realname"];
            tl.WeddDieStatus1 = 0;//0：代表不通过
            tl.WeddDieTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion
      
        #region 审核用户审核从业变更
        /// <summary>
        /// 审核用户审核从业变更
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkIndusChange(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询从业变更
            List<DT_IndustryChanges> industry = icbll.SelectIndustryChangesByid(tid);
            ViewBag.industry = industry;

            return View();
        }

        /// <summary>
        /// 修改总表的IndustryId
        /// 审核审核从业变更通过
        /// </summary>
        public void _UpdTotalIndustry(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.IndustryAdvice1 = advice;
            tl.IndustryPeople1 = (string)Session["realname"];
            tl.IndustryStatus1 = 1;//1：代表通过
            //tl.IndustryTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的IndustryId
        /// 审核审核从业变更不通过
        /// </summary>
        public void _UpdTotalIndustry_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.IndustryAdvice1 = advice;
            tl.IndustryPeople1 = (string)Session["realname"];
            tl.IndustryStatus1 = 0;//0：代表不通过
            tl.IndustryTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion

        #region 审核用户审核重大事项报告
        /// <summary>
        /// 审核用户审核重大事项报告
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkImportant(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询重大事项报告
            List<DT_Important>  important = imbll.SelectImportantByid(tid);
            ViewBag.important = important;

            return View();
        }

        /// <summary>
        /// 修改总表的IndustryId
        /// 审核审核重大事项报告通过
        /// </summary>
        public void _UpdTotalImportant(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ImportantAdvice1 = advice;
            tl.ImportantPeople1 = (string)Session["realname"];
            tl.ImportantStatus1 = 1;//1：代表通过
           // tl.ImportantTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的IndustryId
        /// 审核审核重大事项报告不通过
        /// </summary>
        public void _UpdTotalImportant_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ImportantAdvice1 = advice;
            tl.ImportantPeople1 = (string)Session["realname"];
            tl.ImportantStatus1 = 0;//0：代表不通过
            tl.ImportantTime1 = DateTime.Now;
            int count = tbll.UpdTotal(tl);
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


        #endregion

        #region 审核用户审核责任追究
        /// <summary>
        /// 审核用户审核责任追究
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkRespons(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询责任追究
            List<DT_Responsibility> respons = rsbll.SelectResponsByid(tid);  
            ViewBag.respons = respons;

            return View();
        }

        /// <summary>
        /// 修改总表的responsid
        /// 审核审核责任追究通过
        /// </summary>
        public void _UpdTotalRespons(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ResponsAdvice1 = advice;
            tl.ResponsPeople1 = (string)Session["realname"];
            tl.ResponsStatus1 = 1;//1：代表通过
            //tl.ResponsTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的responsid
        /// 审核审核责任追究不通过
        /// </summary>
        public void _UpdTotalRespons_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ResponsAdvice1 = advice;
            tl.ResponsPeople1 = (string)Session["realname"];
            tl.ResponsStatus1 = 0;//0：代表不通过
            tl.ResponsTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion

        #region 审核用户审核信访核查
        /// <summary>
        /// 审核用户审核信访核查
        /// </summary>
        /// <returns></returns> int id
        public ActionResult ChkUserChkLetterChk(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询信访核查
            List<DT_PetitionLetter> letter = lcbll.SelectLetterByid(tid);  
            ViewBag.letter = letter;

            return View();
        }

        /// <summary>
        /// 修改总表的letterid
        /// 审核审核信访核查通过
        /// </summary>
        public void _UpdTotalLetterChk(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.LetterAdvice1 = advice;
            tl.LetterPeople1 = (string)Session["realname"];
            tl.LetterStatus1 = 1;//1：代表通过
           // tl.LetterTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的letterid
        /// 审核审核信访核查不通过
        /// </summary>
        public void _UpdTotalLetterChk_No(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.LetterAdvice1 = advice;
            tl.LetterPeople1 = (string)Session["realname"];
            tl.LetterStatus1 = 0;//0：代表不通过
            tl.LetterTime1 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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

        #endregion

        #region 高级用户审核
        /// <summary>
        /// 高级用户审核页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //全部FileStatus不为空或“”的总表
            List<DT_Total> tlist = tbll.SelTotalsByFileStutus();//tbll.SelectTotal();
            ViewBag.tlist = tlist;
           
            //全部CheckStatus为"已提交"的总表
            //List<DT_Total> tlist = tbll.SelTotalsByChkStutus();
            //ViewBag.tlist = tlist;
          
            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //全部内部用户
            //List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
            //ViewBag.allusers = allusers;

            //全部单位
            List<DT_WorkUnit> units = wbll.SelUnitByParent();
            ViewBag.units = units;

            //全部科室
            List<DT_WorkUnit> depts = wbll.SelDeptByParent();
            ViewBag.depts = depts;

            return View();
        }
         /// <summary>
        /// 高级用户审核个人页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HighUserChkOne(int tid=0)
        {
            //根据总表id查询用户登录id
            ViewBag.t = tbll.SelUidByTid(tid);
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;
            //根据id查询所有内部登录用户
            List<DT_UserLoginRecord> ulist = umbll.QueryUinfoById(tid);
            ViewBag.ulist = ulist; 

            //根据id查询基本信息
            List<DT_UserInfo> uslist = ubll.SelectUserInfoByid(tid);
            ViewBag.SelInfoById = uslist;

            //根据登录id查询家庭表
            List<DT_FamilyTotal> falist = ubll.SelectFaByUid(tid);
            ViewBag.falist = falist;
           
            //查询家庭分表
            List<DT_Family> flist = ubll.SelFamily(tid);
            ViewBag.flist = flist;

            //根据登录id查询营利持股表
            List<DT_ProfitReport> profitlist = pbll.SelectProfitByid(tid);
            ViewBag.profitlist = profitlist;

            //根据登录id查询婚姻变化表
            List<DT_MarryChange> marry = mcbll.SelectMarryByUid(tid);
            ViewBag.marry = marry;

            //根据登录id查询犯罪表
            List<DT_CrimeReport> crime = cbll.SelectCrimeByUid(tid);
            ViewBag.crime = crime;


            //根据登录id查询近亲婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wdbll.SelectWeddingDieByUid(tid);
            ViewBag.weddingdie = weddingdie;

            //根据UserId查询从业变更
            List<DT_IndustryChanges> industry = icbll.SelectIndustryByUid(tid);
            ViewBag.industry = industry;

            //根据UserId查询重大事项
            List<DT_Important> important = imbll.SelectImportantByUid(tid);
            ViewBag.important = important;

            //根据UserId查询责任追究
            List<DT_Responsibility> respons = rsbll.SelectResponsByUid(tid);
            ViewBag.respons = respons;

            //根据UserId查询信访核查
            List<DT_PetitionLetter> letterchk = lcbll.SelectLetterChkByUid(tid);
            ViewBag.letterchk = letterchk;

            //根据UserId查询诫勉谈话
            List<DT_AdmonishingTalk> admonish = atbll.SelectAdmonishByUid(tid);
            ViewBag.admonish = admonish;

            //根据UserId查询廉政谈话
            List<DT_IncorruptTalk> incorrupt = itbll.SelectIncorruptByUid(tid);
            ViewBag.incorrupt = incorrupt;

            //根据UserId查询函询情况
            List<DT_ApplyByLetter> apply = albll.SelectApplyByUid(tid);
            ViewBag.apply = apply;



            //全部内部登录用户
            //List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
            //ViewBag.allusers = allusers;


            return View();
        }
        /// <summary>
        /// 高级用户审核个人详细页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HighUserChkDetails(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //根据Id查询全部基本信息表
            List<DT_UserInfo> uilist = ubll.SelectUInfoByid(tid);
            ViewBag.uilist = uilist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;


            return View();
        }

        /// <summary>
        /// 修改总表的userinfoid
        /// 高级用户审核基本信息表通过
        /// </summary>
        public void _UpdTotal_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoAdvice2 = advice;
            tl.UserInfoPeople2 = (string)Session["realname"];
            tl.UserInfoStatus2 = 1;//1：代表通过
            //tl.UserInfoTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的userinfoid
        /// 高级用户审核基本信息表不通过
        /// </summary>
        public void _UpdTotal_No_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoAdvice2 = advice;
            tl.UserInfoPeople2 = (string)Session["realname"];
            tl.UserInfoStatus2 = 0;//0：代表不通过
            tl.UserInfoTime2 = DateTime.Now;


            int count = tbll.UpdTotal(tl);
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
        /// 高级用户提交归档
        /// </summary>
        public void _UpdTotal_Submit_High(int id)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoPeople2 = (string)Session["realname"];
            tl.FileStatus = "已归档";//审核通过 可以归档
            tl.Status = "已归档";
            tl.CheckStatus = "已归档";
            tl.HighFileTime = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 高级用户退回给审核用户修改
        /// </summary>
        public void _UpdTotal_BackUpd_High(int id)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.UserInfoPeople2 = (string)Session["realname"];
            tl.FileStatus = "已退回";//高级用户退回给审核用户修改
            tl.CheckStatus = "被退回";//审核用户就是“被退回”
            tl.HighBackTime = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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

        #endregion

        #region 高级用户审核家庭成员表
        /// <summary>
        /// 高级用户审核家庭成员表
        /// </summary>
        /// <returns></returns> int id
        public ActionResult HighUserChkFamily(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist; 

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询家庭成员总表
           // List<DT_FamilyTotal> falist = ubll.SelectFamilyByid(tid);
          //  ViewBag.falist = falist;

            //根据登录id查询家庭成员总表
            List<DT_FamilyTotal> falist = ubll.SelectFaByUid(tid);
            ViewBag.falist = falist;
           

            //查询家庭分表
            List<DT_Family> flist = ubll.SelFamily(tid);
            ViewBag.flist = flist;

            return View();
        }

        /// <summary>
        /// 修改总表的FamilyId
        /// 审核家庭成员表通过
        /// </summary>
        public void _UpdTotalFamily_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.FamilyAdvice2 = advice;
            tl.FamilyPeople2 = (string)Session["realname"];
            tl.FamilyStatus2 = 1;//1：代表通过
            //tl.FamilyTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的FamilyId
        /// 审核家庭成员表不通过
        /// </summary>
        public void _UpdTotalFamily_No_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.FamilyAdvice2 = advice;
            tl.FamilyPeople2 = (string)Session["realname"];
            tl.FamilyStatus2 = 0;//0：代表不通过
            tl.FamilyTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion

        #region 高级用户审核营业持股表
        /// <summary>
        /// 高级用户审核用户审核营业持股表
        /// </summary>
        /// <returns></returns> int id
        public ActionResult HighUserChkProfit(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询营利及兼职持股情况报告表
            List<DT_ProfitReport> plist = pbll.SelectProfitReportByid(tid);
            ViewBag.plist = plist;

            return View();  
        }

        /// <summary>
        /// 修改总表的ProfitId
        /// 审核营利表通过
        /// </summary>
        public void _UpdTotalProfit_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ProfitAdvice2 = advice;
            tl.ProfitPeople2 = (string)Session["realname"];
            tl.ProfitStatus2 = 1;//1：代表通过
            //tl.ProfitTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的ProfitId
        /// 审核营利表不通过
        /// </summary>
        public void _UpdTotalProfit_No_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.ProfitAdvice2 = advice;
            tl.ProfitPeople2 = (string)Session["realname"];
            tl.ProfitStatus2 = 0;//0：代表不通过
            tl.ProfitTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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

        #endregion

        #region 高级用户审核婚姻变化表
        /// <summary>
        /// 高级用户审核婚姻变化表
        /// </summary>
        /// <returns></returns> int id  int tid = 0
        public ActionResult HighUserChkMarryChage(int tid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据id查询婚姻变化
            List<DT_MarryChange> marrylist = mcbll.SelectMarryByids(tid);
            ViewBag.marrylist = marrylist;

            return View();
        }

        /// <summary>
        /// 修改总表的MarryChangeId
        /// 审核婚姻变化表通过
        /// </summary>
        public void _UpdTotalMarryChage_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.MarryChgAdvice2 = advice;
            tl.MarryChgPeople2 = (string)Session["realname"];
            tl.MarryChgStatus2 = 1;//1：代表通过
           // tl.MarryChgTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的MarryChangeId
        /// 审核婚姻变化表不通过
        /// </summary>
        public void _UpdTotalMarryChage_No_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.MarryChgAdvice2 = advice;
            tl.MarryChgPeople2 = (string)Session["realname"];
            tl.MarryChgStatus2 = 0;//0：代表不通过
            tl.MarryChgTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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



        #endregion

        #region 高级用户审核犯罪表
        /// <summary>
        /// 高级用户审核犯罪表
        /// </summary>
        /// <returns></returns> int id
        public ActionResult HighUserChkCrime(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询干部配偶、子女涉嫌犯罪情况报告
            List<DT_CrimeReport> crimelist = cbll.SelectCrimeByid(tid);
            ViewBag.crimelist = crimelist;

            return View();
        }

        /// <summary>
        /// 修改总表的CrimeId
        /// 审核审核犯罪表通过
        /// </summary>
        public void _UpdTotalCrime_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.CrimeAdvice2 = advice;
            tl.CrimePeople2 = (string)Session["realname"];
            tl.CrimeStatus2 = 1;//1：代表通过
            //tl.CrimeTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的CrimeId
        /// 审核审核犯罪表不通过
        /// </summary>
        public void _UpdTotalCrime_No_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.CrimeAdvice2 = advice;
            tl.CrimePeople2 = (string)Session["realname"];
            tl.CrimeStatus2 = 0;//0：代表不通过
            tl.CrimeTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion

     
        #region 高级用户审核婚丧喜庆
        /// <summary>
        /// 审核用户审核婚丧喜庆
        /// </summary>
        /// <returns></returns> int id
        public ActionResult HighUserChkWeddingDie(int tid = 0)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询干部婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wdbll.SelectWeddingDieByid(tid);
            ViewBag.weddingdie = weddingdie;

            return View();
        }

        /// <summary>
        /// 修改总表的WeddingDieId
        /// 审核审核婚丧喜庆通过
        /// </summary>
        public void _UpdTotalWeddingDie_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.WeddDieAdvice2 = advice;
            tl.WeddDiePeople2 = (string)Session["realname"];
            tl.WeddDieStatus2 = 1;//1：代表通过
            //tl.WeddDieTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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
        /// 修改总表的WeddingDieId
        /// 审核审核婚丧喜庆不通过
        /// </summary>
        public void _UpdTotalWeddingDie_No_High(int id, string advice)
        {
            DT_Total tl = tbll.QueryTotalById(id);
            tl.Id = id;
            tl.WeddDieAdvice2 = advice;
            tl.WeddDiePeople2 = (string)Session["realname"];
            tl.WeddDieStatus2 = 0;//0：代表不通过
            tl.WeddDieTime2 = DateTime.Now;

            int count = tbll.UpdTotal(tl);
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


        #endregion

 

        #region 搜索框查询
        /// <summary>
        /// 搜索框查询
        /// </summary>
        /// <returns></returns>
        public ActionResult KeyWords()
        {
           //查询全部已归档
           List<DT_Total> totals= tbll.SelTotalsByFiled();
           ViewBag.totals = totals;

           //全部内部用户
           List<DT_UserLoginRecord> allusers = umbll.SelectUsers();
           ViewBag.allusers = allusers;

           //全部单位
           List<DT_WorkUnit> units = wbll.SelUnitByParent();
           ViewBag.units = units;

           //全部科室
           List<DT_WorkUnit> depts = wbll.SelDeptByParent();
           ViewBag.depts = depts;

            return View();
        }


        public void Search(string keywords)
        { 
               
            //List<DTO_UsersBulletin> dlist = bd.GetBulletinList(name, title, content);
            //JavaScriptSerializer jss = new JavaScriptSerializer();

            //Response.Write(jss.Serialize(dlist));
            //Response.End();

            List<DTO_SearchTotal> dtlist = umbll.SelectSearch(keywords); 
            JavaScriptSerializer jss = new JavaScriptSerializer();

            Response.Write(jss.Serialize(dtlist));
            Response.End();

        }

        
        public void _SelUnitByWord(string key)
        {
            umbll.SelUnitByWord(key);
            umbll.SelUserByWord(key);

        }

        #endregion


        #region 打印页面
        /// <summary>
        /// 基本信息表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintUserinfo(int uid)
        {
             
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //根据Id查询全部基本信息表
            List<DT_UserInfo> uilist = ubll.SelectUInfoByid(uid);
            ViewBag.uilist = uilist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            return View();
        }

        /// <summary>
        /// 打印家庭成员表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintFamily(int fid)
        {
            //根据登录id查询基本信息
            List<DT_UserInfo> uslist = ubll.SelectUserInfoByid(fid);
            ViewBag.SelInfoById = uslist;

            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //根据登录id查询家庭表
            List<DT_FamilyTotal> falist = ubll.SelectFaByUid(fid);
            ViewBag.falist = falist;

            //查询家庭分表
            List<DT_Family> flist = ubll.SelFamily(fid);
            ViewBag.flist = flist;

            return View();
        }

        /// <summary>
        /// 营利表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintProfit(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;


            //根据Id查询营利及兼职持股情况报告表
            List<DT_ProfitReport> plist = pbll.SelectProfitReportByid(pid);
            ViewBag.plist = plist;
         

            return View();
        }

        /// <summary>
        /// 婚姻变化表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintMarry(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据id查询婚姻变化
            List<DT_MarryChange> marrylist = mcbll.SelectMarryByids(pid);
            ViewBag.marrylist = marrylist;

            return View();
        }

        /// <summary>
        /// 犯罪表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintCrime(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询干部配偶、子女涉嫌犯罪情况报告
            List<DT_CrimeReport> crimelist = cbll.SelectCrimeByid(pid);
            ViewBag.crimelist = crimelist;

            return View();
        }

        /// <summary>
        /// 犯罪表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintWeddingDie(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询干部婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wdbll.SelectWeddingDieByid(pid);
            ViewBag.weddingdie = weddingdie;

            return View();
        }

        /// <summary>
        /// 从业变更表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintIndustryChg(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询从业变更
            List<DT_IndustryChanges> industry = icbll.SelectIndustryChangesByid(pid);
            ViewBag.industry = industry;

            return View();
        }


        /// <summary>
        /// 重大事项报告表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintImportant(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询重大事项报告
            List<DT_Important> important = imbll.SelectImportantByid(pid);
            ViewBag.important = important;


            return View();
        }


        /// <summary>
        /// 责任追究表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintResponse(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询责任追究
            List<DT_Responsibility> respons = rsbll.SelectResponsByid(pid);
            ViewBag.respons = respons;


            return View();
        }

        /// <summary>
        /// 信访核查表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult PrintLetterCheck(int pid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;

            //根据Id查询信访核查
            List<DT_PetitionLetter> letter = lcbll.SelectLetterByid(pid);
            ViewBag.letter = letter;


            return View();
        }





        #endregion
    }
}
