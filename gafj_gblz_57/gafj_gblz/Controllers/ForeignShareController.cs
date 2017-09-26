using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class ForeignShareController : BaseController
    {
        //系统外人员
        // GET: /ForeignShare/
        TotalBLL tbll = new TotalBLL();
        UserBLL ubll = new UserBLL();
        ShareBLL sbll = new ShareBLL();
        UserManageBLL umbll = new UserManageBLL();

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

        public ActionResult Index()
        {
            List<DT_BeShared> beshared = sbll.SelBeShared();
            ViewBag.beshared = beshared;

            //FileStutus为“已归档”的总表 
            List<DT_Total> filedlist = tbll.SelTotalsByFiled();
            ViewBag.filedlist = filedlist;

            //全部基本信息表
            List<DT_UserInfo> userinfolist = ubll.SelectUserInfo();
            ViewBag.userinfolist = userinfolist;


            return View();
        }

        /// <summary>
        /// 共享信息
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public ActionResult SeeSingle(int tid)
        {
            //全部总表
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;
            //根据id查询所有内部登录用户
            List<DT_UserLoginRecord> ulist = umbll.QueryUinfoById(tid);
            ViewBag.ulist = ulist;

            //根据登录id查询基本信息
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


            return View();
        }

    }
}
