using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class EnterFileController : BaseController
    {
        //录入档案
        // GET: /EnterFile/

        #region BLL
        UserBLL ubll = new UserBLL();
        MarryChangeBLL mbll = new MarryChangeBLL();
        ProfitReportBLL pbll = new ProfitReportBLL();
        UserManageBLL umbll = new UserManageBLL();
        CrimeBLL cbll = new CrimeBLL();
        TotalBLL tbll = new TotalBLL();
        WeddingDieBLL wbll = new WeddingDieBLL();
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

        #endregion

        #region 录入档案首页
        /// <summary>
        /// 录入档案首页
        /// </summary>int id=0
        /// <returns></returns>
        public ActionResult Index()
        {

            //根据UserId查询出国总
            List<DT_GoAbroadTotal> abroadtotal = abll.SelectAbroadTotalByUid(Convert.ToInt32(Session["id"]));
            ViewBag.abroadtotal = abroadtotal;

            #region 根据UserId查询出国分
            //根据UserId查询出国办企
            List<DT_GoAbroadCompany> company = abll.SelectCompanyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.company = company;

            //根据UserId查询出国留学
            List<DT_GoAbroadStudy> study = abll.SelectStudyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.study = study;

            //根据UserId查询出国定居
            List<DT_GoAbroadSettler> settle = abll.SelectSettleByUid(Convert.ToInt32(Session["id"]));
            ViewBag.settle = settle;

            #endregion

            //根据UserId查询住房总
            List<DT_HousingTotal> housetotal = hbll.SelectHousingTotalByUid(Convert.ToInt32(Session["id"]));
            ViewBag.housetotal = housetotal;

            #region 根据UserId查询住房分
            //根据UserId查询住房
            List<DT_HousingHouse> house = hbll.SelectHouseByUid(Convert.ToInt32(Session["id"]));
            ViewBag.house = house;

            //根据UserId查询购房
            List<DT_HousingBuy> housebuy = hbll.SelectBuyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.housebuy = housebuy;

            //根据UserId查询售房
            List<DT_HousingSell> housesell = hbll.SelectSellByUid(Convert.ToInt32(Session["id"]));
            ViewBag.housesell = housesell;

            //根据UserId查询租房
            List<DT_HousingRentout> houserent = hbll.SelectRentoutByUid(Convert.ToInt32(Session["id"]));
            ViewBag.houserent = houserent;
            //根据UserId查询建房
            List<DT_HousingBuild> housebuild = hbll.SelectBuildByUid(Convert.ToInt32(Session["id"]));
            ViewBag.housebuild = housebuild;


            #endregion

            //根据UserId查询拒收礼金总
            List<DT_RefuseGiftTotal> refusetotal = rgbll.SelectRefuseTotalByUid(Convert.ToInt32(Session["id"]));
            ViewBag.refusetotal = refusetotal;

            #region 根据UserId查询拒收礼金分
            //根据UserId查询拒收礼金分
            List<DT_RefuseGift> refuse = rgbll.SelectRefuseByUid(Convert.ToInt32(Session["id"]));  
            ViewBag.refuse = refuse;


            #endregion

            //根据UserId查询奖惩情况总
            List<DT_RewardPunishTotal> rewardtotal = rpbll.SelectRPTotalByUid(Convert.ToInt32(Session["id"]));
            ViewBag.rewardtotal = rewardtotal;

            #region 根据UserId查询奖惩情况分
            //根据UserId查询奖励
            List<DT_Reward> reward = rpbll.SelectRewardByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.reward = reward;

            //根据UserId查询惩罚
            List<DT_Punish> punish = rpbll.SelectPunishByUid(Convert.ToInt32(Session["id"]));
            ViewBag.punish = punish;

            #endregion


            //根据UserId查询函询情况
            List<DT_ApplyByLetter> apply = albll.SelectApplyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.apply = apply;

            //根据UserId查询廉政谈话
            List<DT_IncorruptTalk> incorrupt = itbll.SelectIncorruptByUid(Convert.ToInt32(Session["id"]));
            ViewBag.incorrupt = incorrupt;

            //根据UserId查询诫勉谈话
            List<DT_AdmonishingTalk> admonish = atbll.SelectAdmonishByUid(Convert.ToInt32(Session["id"]));
            ViewBag.admonish = admonish;

            //根据UserId查询信访核查
            List<DT_PetitionLetter> letterchk = lcbll.SelectLetterChkByUid(Convert.ToInt32(Session["id"]));
            ViewBag.letterchk = letterchk;

            //根据UserId查询责任追究
            List<DT_Responsibility> respons = rsbll.SelectResponsByUid(Convert.ToInt32(Session["id"]));
            ViewBag.respons = respons;

            //根据UserId查询重大事项
            List<DT_Important> important = imbll.SelectImportantByUid(Convert.ToInt32(Session["id"]));
            ViewBag.important = important;

            //根据UserId查询从业变更
            List<DT_IndustryChanges> industry = icbll.SelectIndustryByUid(Convert.ToInt32(Session["id"]));
            ViewBag.industry = industry;

            // 根据UserId查询近亲婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wbll.SelectWeddingDieByUid(Convert.ToInt32(Session["id"]));
            ViewBag.weddingdie = weddingdie;

            // 根据UserId查询犯罪情况报告
            List<DT_CrimeReport> crime = cbll.SelectCrimeByUid(Convert.ToInt32(Session["id"]));
            ViewBag.crime = crime;

            //根据UserId查询婚姻变化表
            List<DT_MarryChange> marry = mbll.SelectMarryByUid(Convert.ToInt32(Session["id"]));
            ViewBag.marry = marry;

            //根据userid查看兼职持股情况报告表
            List<DT_ProfitReport> profit = pbll.SelectProfitByid(Convert.ToInt32(Session["id"]));
            ViewBag.profit = profit;

            //根据userid查看家庭成员分表
            List<DT_Family> falist = ubll.SelFamily(Convert.ToInt32(Session["id"]));
            // List<DT_Family> falist = ubll.SelectFamByid(Convert.ToInt32(Session["id"]));
            ViewBag.falist = falist;

            //根据userid查看家庭成员总表
            List<DT_FamilyTotal> FamilyTotal = ubll.SelectFaByUid(Convert.ToInt32(Session["id"]));
            ViewBag.FamilyTotal = FamilyTotal;
            
            //根据userid查看基本信息表
            List<DT_UserInfo> ulist = ubll.SelectUserInfoByid(Convert.ToInt32(Session["id"]));
            ViewBag.UpdUserinfo = ulist;


            //查询家庭成员总表
            List<DT_FamilyTotal> fatotal = ubll.SelFamilyTotal();
            ViewBag.fatotal = fatotal;


            #region 根据登录id查询各Id是否为空
            
            //根据登录id查询UserInfoId是否为空
            ViewBag.isnull = ubll.IsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询FamilyId是否为空
            ViewBag.FamidIsNull = ubll.FamidIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询Profitid是否为空
            ViewBag.ProfitidIsNull = pbll.ProfitidIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询Marryid是否为空
            ViewBag.MarryidIsNull = mbll.MarryidIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询CrimeId是否为空
            ViewBag.CrimeIdIsNull = cbll.CrimeIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询WeddingId是否为空
            ViewBag.WeddingIdIsNull = wbll.WeddingIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询IndustryId是否为空
            ViewBag.IndustryIdIsNull = icbll.IndustryIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询ImportantId是否为空
            ViewBag.ImportantIdIsNull = imbll.ImportantIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询ResponsId是否为空
            ViewBag.ResponsIdIsNull = rsbll.ResponsIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询LetterChkId是否为空
            ViewBag.LetterChkIdIsNull = lcbll.LetterChkIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询AdmonishId是否为空
            ViewBag.AdmonishIdIsNull = atbll.AdmonishIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询WeddingId是否为空
            ViewBag.IncorruptIdIsNull = itbll.IncorruptIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询ApplyLetterId是否为空
            ViewBag.ApplyLetterIdIsNull = albll.ApplyLetterIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询Rewardid是否为空
            ViewBag.RPTotalIdIsNull = rpbll.RPTotalIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询Refuseid是否为空
            ViewBag.RefuseTotalIdIsNull = rgbll.RefuseTotalIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询houseid是否为空
            ViewBag.HousetotalIdIsNull = hbll.HousingTotalIdIsNull(Convert.ToInt32(Session["id"]));

            //根据登录id查询abroadid是否为空
            ViewBag.AbroadtotalIdIsNull = abll.AbroadTotalIdIsNull(Convert.ToInt32(Session["id"])); 


            #endregion

            //根据id查询所有内部登录用户
            List<DT_UserLoginRecord> urlist = umbll.QueryUinfoById(Convert.ToInt32(Session["id"]));
            ViewBag.urlist = urlist;

            //全部总表 审核记录
            List<DT_Total> tlist = tbll.SelectTotal();
            ViewBag.tlist = tlist;

            //查询状态
            ViewBag.status = ubll.SelStatus(Convert.ToInt32(Session["id"]));

            //根据登录id查询最近一条UserInfoId
            int newuid = ubll.SelIdByUserid(Convert.ToInt32(Session["id"]));
          
            //表一所有ids             
            foreach (var t in ubll.GetTableId())
            {
                ViewBag.tableids = t;
            }

            return View();
        }
        #endregion    



        #region 总表

        #region 总表Ids
        /// <summary>
        /// 添加uid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _AddTotalUserId(int uid)
        {
            DT_Total to = new DT_Total();
            to.YearTable = DateTime.Now.Year;
            to.UserId = Convert.ToInt32(Session["id"]);
            to.UserInfoId = uid;
            to.AddTime = DateTime.Now;
            int count = tbll.AddTotal(to);

        }
        /// <summary>
        /// 修改总表的fid
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalFid(int fid)
        {
            //int newfid = ubll.SelFaidByUserid(Convert.ToInt32(Session["id"]));           
            //DT_Total to = tbll.SelTotalById(newfid);

            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.FamilyId = fid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        /// 修改总表的pid 
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalProfitid(int pid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.ProfitId = pid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        ///  修改mid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalMarryid(int mid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.MarryChangeId = mid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        ///  修改cid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalCrimeid(int cid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.CrimeId = cid;
            //这里录入表的顺序是从上到下，第一张必须先填写，最后一张必须最后填写才能提交（存在判断问题,做完之后调整）
            //最后一张表填完保存之后，状态变为“未提交”,提交按钮显示,可以提交全部表
            to.Status = "未提交";
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改wid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalWeddDieid(int wid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.WeddingandDieId = wid;
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改sid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalIndustryid(int sid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.IndustryChangesId = sid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        ///  修改Importantid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalImportantid(int imid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.ImportantId = imid;
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改rid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalResponsid(int rid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.ResponsibilityId = rid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        ///  修改LetterChkid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalLetterChkid(int lid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.PetitionLetterId = lid;
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改aid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalAdmonishid(int aid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.AdmonishingTalkId = aid;
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改tid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalIncorruptid(int tid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.IncorruptTalkId = tid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        ///  修改alid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalApplyLetterid(int alid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.ApplyByLetterId = alid;
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改rpid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalRewardPunishid(int rpid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.RewardId = rpid;
            int count = tbll.UpdTotal(to);
        }

        /// <summary>
        ///  修改rfid到总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdTotalRefuseid(int rfid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.RefuseGiftId = rfid;
            int count = tbll.UpdTotal(to);
        }
      
        /// <summary>
        /// 修改hoid到总表
        /// </summary>住房
        /// <param name="hoid"></param>
        public void _UpdTotalHouseid(int hoid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.HousingId = hoid;
            int count = tbll.UpdTotal(to);
        }
        /// <summary>
        ///  修改abid到总表
        /// </summary>出国
        /// <param name="abid"></param>
        public void _UpdTotalAbroadid(int abid)
        {
            DT_Total to = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            to.GoAbroadId = abid;
            int count = tbll.UpdTotal(to);
        }

        #endregion

        #region 总表状态
        /// <summary>
        /// 修改总表状态
        /// </summary>
        /// <param name="id"></param>
        public void _UpdStatus()
        {
            DT_Total to = ubll.QueryToById(Convert.ToInt32(Session["id"]));
            to.Status = "已提交";
            to.CheckStatus = "待审核";

            int count = ubll.UpdTotal(to);
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
        /// 被退回后 修改总表状态
        /// </summary>
        /// <param name="id"></param>
        public void _UpdStatusback()
        {
            DT_Total to = ubll.QueryToById(Convert.ToInt32(Session["id"]));
            to.Status = "未提交";

            int count = ubll.UpdTotal(to);
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

        #endregion

        #region 表1：基本信息登记表1（DT_UserInfo）

        /// <summary>
        /// 基本情况登记表1添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBaseInfo1() 
        {           
            return View();     
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        public void UpLoad()
        {
            if (Request.Files.Count > 0)
            {
                string url = Server.MapPath("~") + "/Content/Upload/Images/" + Request.Files[0].FileName;
                Request.Files[0].SaveAs(url);
            }
        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <param name="imgurl">图片路径</param>
        /// <returns></returns>
        public string geturlimg(string imgurl)
        {
            List<string> fnamelist = imgurl.Split('\\').ToList();
            string filename = fnamelist[fnamelist.Count - 1];
            return filename;
        }
   
        /// <summary>
        /// 基本情况登记表1修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdBaseInfo1(int id)
        {    
            //根据id查询基本信息
            List<DT_UserInfo> ulist = ubll.SelectUserInfoByid(id);
            ViewBag.UpdUserinfo = ulist;
            //根据登录id查询总表status的状态  这里主要是根据status为“被退回”来判断
            //修改二次修改,点击“保存”时,同时修改status为“未提交”,可再次提交 (注意年份)
            ViewBag.status = ubll.SelStatus(Convert.ToInt32(Session["id"]));
            return View();
            
        }


        /// <summary>
        /// 添加基本情况登记表1
        /// </summary>
        /// <param name="u"></param>
        public void _AddBaseInfo1(DT_UserInfo u)
        {
            DT_UserInfo user = new DT_UserInfo();
            user.UserId = Convert.ToInt32(Session["id"]);
            user.YearTable = DateTime.Now.Year;
            user.Id = u.Id;
            user.RealName = u.RealName;
            user.Sex = u.Sex;
            user.NativePlace = u.NativePlace;
            //对图片路径做处理
            user.Photo =geturlimg(u.Photo); 
            user.Birthday = u.Birthday;
            user.IdCardNum = u.IdCardNum;
            user.Outlook = u.Outlook;
            user.PartyTime = u.PartyTime;
            user.Nation = u.Nation;
            user.Property = u.Property;
            user.JobTime = u.JobTime;
            user.Education = u.Education;
            user.WorkUnit = u.WorkUnit;
            user.Post = u.Post;
            user.PostStatus = u.PostStatus;
            user.PostTime = u.PostTime;
            user.DoWork = u.DoWork;
            user.UserAddress = u.UserAddress;
            user.Introduction = u.Introduction;
            user.FillTime = DateTime.Now;
            int count = ubll.AddUserInfo(user);

            //根据登录id查询最近一条UserInfoId
            int newuid = ubll.SelIdByUserid(Convert.ToInt32(Session["id"]));
            _AddTotalUserId(newuid);

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
        /// 修改基本情况登记表1
        /// </summary>
        /// <param name="u"></param>
        public void _UpdBaseInfo1(DT_UserInfo u)
        {
            DT_UserInfo user = ubll.SelUserinfoById(Convert.ToInt32(Session["id"]));
            user.RealName = u.RealName;
            user.Sex = u.Sex;
            user.NativePlace = u.NativePlace;
            user.Photo =geturlimg(u.Photo);
            user.Birthday = u.Birthday;
            user.IdCardNum = u.IdCardNum;
            user.Outlook = u.Outlook;
            user.PartyTime = u.PartyTime;
            user.Nation = u.Nation;
            user.Property = u.Property;
            user.JobTime = u.JobTime;
            user.Education = u.Education;
            user.WorkUnit = u.WorkUnit;
            user.Post = u.Post;
            user.PostStatus = u.PostStatus;
            user.PostTime = u.PostTime;
            user.DoWork = u.DoWork;
            user.UserAddress = u.UserAddress;
            user.Introduction = u.Introduction;

            int count = ubll.UpdateUserInfo(user);

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
        /// （被退回时）修改基本情况登记表1
        /// </summary>
        /// <param name="u"></param>
        public void _UpdBaseInfoback(DT_UserInfo u)
        {
            DT_UserInfo user = ubll.SelUserinfoById(Convert.ToInt32(Session["id"]));
            user.RealName = u.RealName;
            user.Sex = u.Sex;
            user.NativePlace = u.NativePlace;
            user.Photo = geturlimg(u.Photo);
            user.Birthday = u.Birthday;
            user.IdCardNum = u.IdCardNum;
            user.Outlook = u.Outlook;
            user.PartyTime = u.PartyTime;
            user.Nation = u.Nation;
            user.Property = u.Property;
            user.JobTime = u.JobTime;
            user.Education = u.Education;
            user.WorkUnit = u.WorkUnit;
            user.Post = u.Post;
            user.PostStatus = u.PostStatus;
            user.PostTime = u.PostTime;
            user.DoWork = u.DoWork;
            user.UserAddress = u.UserAddress;
            user.Introduction = u.Introduction;

            int count = ubll.UpdateUserInfo(user);

            //退回修改状态
           // _UpdStatusback();
           
            //修改总表基本信息表状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.UserInfoStatus1 = null;
            tbll.UpdTotal(tl);

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

        #region 表2：基本信息登记分表2（家庭成员表）（DT_FamilyTotal）

        #region 家庭成员总表
        /// <summary>
        /// 家庭成员总表
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBaseInfo2()
        {
            //查询家庭成员分表
            List<DT_Family> flist = ubll.SelFamily(Convert.ToInt32(Session["id"]));
            ViewBag.flist = flist;

            //查询家庭成员总表
            List<DT_FamilyTotal> fatotal = ubll.SelFamilyTotal();
            ViewBag.fatotal = fatotal;

            //查询家庭总表id
            ViewBag.SelFamilyIds = ubll.SelFamilyIds(Convert.ToInt32(Session["id"])) == null ? null : ubll.SelFamilyIds(Convert.ToInt32(Session["id"]));

            return View();
        }
        /// <summary>
        /// 修改家庭成员总表
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdBaseInfo2(int id)
        {
            //根据userid查询家庭成员分表
            List<DT_Family> flist = ubll.SelFamily(Convert.ToInt32(Session["id"]));
            ViewBag.flist = flist;
          
            //根据userid查看家庭成员总表
            List<DT_FamilyTotal> FamilyTotal = ubll.SelectFaByUid(Convert.ToInt32(Session["id"]));
            ViewBag.FamilyTotal = FamilyTotal;

            return View();  
        }

        /// <summary>
        /// 添加家庭成员总表
        /// </summary>
        /// <param name="u"></param>
        public void _AddFamilyTotal(DT_FamilyTotal f)
        {
            DT_FamilyTotal ft = new DT_FamilyTotal();
            ft.UserId = Convert.ToInt32(Session["id"]);
            ft.YearTable = DateTime.Now.Year;
            ft.other = f.other;
            ft.FillTime = DateTime.Now;
            int count = ubll.AddFamilyTotal(ft);

            //根据登录id查询最近一条FamilyId
            int newfid = ubll.SelFaidByUserid(Convert.ToInt32(Session["id"]));
            //_UpdateFamTotalId(newfid);
            //修改总表fid 
            _UpdTotalFid(newfid);

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
        /// 修改家庭成员总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdFamilyTotal(DT_FamilyTotal f)
        {
            DT_FamilyTotal ft = ubll.SelectFaTotalByUid(Convert.ToInt32(Session["id"]));  
            ft.other = f.other;
            ft.UpdateTime = DateTime.Now;
            int count = ubll.UpdateFamilyTotal(ft); 

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

        #region 家庭成员分表
        /// <summary>
        /// 添加基本情况登记表2
        /// </summary>
        /// <param name="u"></param>
        public void _AddFamily(DT_Family f)
        {
            DT_Family fa = new DT_Family();
            fa.UserId = Convert.ToInt32(Session["id"]);
            fa.YearTable = DateTime.Now.Year;
            fa.Name = f.Name;
            fa.Relation = f.Relation;
            fa.Outlook = f.Outlook;
            fa.WorkUnit = f.WorkUnit;
            fa.Post = f.Post;
            fa.FamilyTotalId = f.FamilyTotalId;

            int count = ubll.AddFamily(fa);
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
        /// 修改基本情况登记表2
        /// </summary>
        /// <param name="u"></param>
        public void _UpdateFamily(DT_Family f)
        {
            DT_Family fa = ubll.SelFaById(f.Id);
            fa.Name = f.Name;
            fa.Relation = f.Relation;
            fa.Outlook = f.Outlook;
            fa.WorkUnit = f.WorkUnit;
            fa.Post = f.Post;
            int count = ubll.UpdateFamily(fa);
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
        /// 删除基本情况登记表2
        /// </summary>
        /// <param name="u"></param>
        public void _DelFamily(DT_Family f)
        {
            DT_Family fa = ubll.SelFaById(f.Id);

            int count = ubll.DelFamily(fa);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/AddBaseInfo2';</script>");
            }
            Response.End();
        }

        /// <summary>
        /// 修改基本情况登记表2的familytotalId
        /// </summary>
        /// <param name="u"></param>  int fid
        public void _UpdateFamTotalId(int uid)
        {
            DT_Family fa = new DT_Family();
            fa.FamilyTotalId = uid;

            ubll.UpdFaIds(fa);

        }

        #endregion

        /// <summary>
        /// 被退回时修改家庭成员表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdFamily_Back(DT_FamilyTotal f)
        {
            _UpdFamilyTotal(f);

            //退回修改状态
            //_UpdStatusback();

            //修改总表婚姻变化状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.FamilyStatus1 = null;
            tbll.UpdTotal(tl);
 
        }


        #endregion

        #region 表5:从事或参与营业性活动及兼职持股情况报告表（DT_ProfitReport）

        /// <summary>
        ///  添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProfit()
        {
            return View();
        }

        /// <summary>
        ///  修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdProfit(int uid)
        {
            List<DT_ProfitReport> plist = pbll.SelectProfit();
            ViewBag.plist = plist;

            //根据userid查看兼职持股情况报告表
            List<DT_ProfitReport> profit = pbll.SelectProfitByid(Convert.ToInt32(Session["id"]));
            ViewBag.profit = profit;

            return View();
        }

        /// <summary>
        /// 添加营业性活动及兼职持股情况报告
        /// </summary>
        /// <param name="u"></param>
        public void _AddProfit(DT_ProfitReport p)
        {
            DT_ProfitReport pr = new DT_ProfitReport();
            pr.UserId = Convert.ToInt32(Session["id"]);
            pr.YearTable = DateTime.Now.Year;
            pr.CompanyName = p.CompanyName;
            pr.BusinessScope = p.BusinessScope;
            pr.RegisterMoney = p.RegisterMoney;
            pr.InvestmentRate = p.InvestmentRate;
            pr.YearProfit = p.YearProfit;
            pr.ParttimeUnit = p.ParttimeUnit;
            pr.ParttimeUnitNature = p.ParttimeUnitNature;
            pr.ParttimePost = p.ParttimePost;
            pr.YearMoney = p.YearMoney;
            pr.InvestUnit = p.InvestUnit;
            pr.InvestUnitNature = p.InvestUnitNature;
            pr.InvestWay = p.InvestWay;
            pr.InvestMoney = p.InvestMoney;
            pr.YearIncome = p.YearIncome;
            pr.Other = p.Other;
            pr.FillTime = DateTime.Now;

            int count = pbll.AddProfit(pr);
            //根据登录id查询最近一条Proid
            int newpid = pbll.SelProidByUid(Convert.ToInt32(Session["id"]));
            _UpdTotalProfitid(newpid);

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
        /// 修改营业性活动及兼职持股情况报告
        /// </summary>  [HttpPost]
        /// <param name="u"></param>ActionResult    
        public void _UpdProfit()
        {
            DT_ProfitReport pr = pbll.SelProByUid(Convert.ToInt32(Session["id"]));
            pr.UserId = Convert.ToInt32(Session["id"]);
            pr.CompanyName = Request["comname"];
            pr.BusinessScope = Request["scope"];
            pr.RegisterMoney = Request["regmoney"];
            pr.InvestmentRate = Request["investrate"];
            pr.YearProfit = Request["yearprofit"];
            pr.ParttimeUnit = Request["partunit"];
            pr.ParttimeUnitNature = Request["partproperty"];
            pr.ParttimePost = Request["partpost"];
            pr.YearMoney = Request["yearmoney"];
            pr.InvestUnit = Request["investunit"];
            pr.InvestUnitNature = Request["investproperty"];
            pr.InvestWay = Request["investway"];
            pr.InvestMoney = Request["investmoney"];
            pr.YearIncome = Request["yearincome"];
            pr.Other = Request["other"];
            pr.UpdateTime = DateTime.Now;

            int count = pbll.UpdProfit(pr);
            //return RedirectToAction("Index","EnterFile"); 
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }
            Response.End();
        }


        /// <summary>
        /// 退回时 修改营业性活动及兼职持股情况报告
        /// </summary>  [HttpPost]
        /// <param name="u"></param>ActionResult    
        public void _UpdProfit_Back()
        {
            _UpdProfit();

            //退回修改状态
           // _UpdStatusback();

            //修改总表婚姻变化状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.ProfitStatus1 = null;
            tbll.UpdTotal(tl);

        }



        #endregion

        #region 表7：婚姻变化情况表（DT_MarryChange）
        /// <summary>
        ///添加婚姻变化情况
        /// </summary>int id=0
        /// <returns></returns>
        public ActionResult AddMarryChange()
        {
            return View();
        }
        /// <summary>
        /// 修改婚姻变化情况
        /// </summary>int id=0
        /// <returns></returns>
        public ActionResult UpdMarryChange(int id)
        {
            List<DT_MarryChange> mlist = mbll.SelectMarryByUid(Convert.ToInt32(Session["id"]));
            ViewBag.mlist = mlist;

            return View();
        }

        /// <summary>
        /// 添加婚姻变化情况
        /// </summary>
        /// <param name="u"></param>
        public void _AddMarry(DT_MarryChange m)
        {
            DT_MarryChange marry = new DT_MarryChange();
            marry.Id = m.Id;
            marry.UserId = Convert.ToInt32(Session["id"]);
            marry.YearTable = DateTime.Now.Year;
            marry.IsMarryChange = m.IsMarryChange;
            marry.LastPartner = m.LastPartner;
            marry.LastRegisterTime = m.LastRegisterTime;
            marry.LastEndTime = m.LastEndTime;
            marry.NowPartner = m.NowPartner;
            marry.NowPolitical = m.NowPolitical;
            marry.NowRegisterTime = m.NowRegisterTime;
            marry.NowUnit = m.NowUnit;
            marry.NowPost = m.NowPost;
            marry.Other = m.Other;
            marry.FillTime = DateTime.Now;
            int count = mbll.AddMarry(marry);
            //根据登录id查询最近一条marrid
            int newpid = mbll.SelMarriddByUserid(Convert.ToInt32(Session["id"]));
            _UpdTotalMarryid(newpid);

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
        /// 修改婚姻变化情况
        /// </summary>
        /// <param name="u"></param>
        public void _UpdMarry(DT_MarryChange m)
        {
            DT_MarryChange marry = mbll.SelMarryByUid(Convert.ToInt32(Session["id"]));
            marry.IsMarryChange = m.IsMarryChange;
            marry.LastPartner = m.LastPartner;
            marry.LastRegisterTime = m.LastRegisterTime;
            marry.LastEndTime = m.LastEndTime;
            marry.NowPartner = m.NowPartner;
            marry.NowPolitical = m.NowPolitical;
            marry.NowRegisterTime = m.NowRegisterTime;
            marry.NowUnit = m.NowUnit;
            marry.NowPost = m.NowPost;
            marry.Other = m.Other;
            marry.UpdateTime = DateTime.Now;
            int count = mbll.UpdateMarry(marry);

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
        /// 被退回时修改婚姻变化情况
        /// </summary>
        /// <param name="u"></param>
        public void _UpdMarry_Back(DT_MarryChange m)
        {
            DT_MarryChange marry = mbll.SelMarryByUid(Convert.ToInt32(Session["id"]));
            marry.IsMarryChange = m.IsMarryChange;
            marry.LastPartner = m.LastPartner;
            marry.LastRegisterTime = m.LastRegisterTime;
            marry.LastEndTime = m.LastEndTime;
            marry.NowPartner = m.NowPartner;
            marry.NowPolitical = m.NowPolitical;
            marry.NowRegisterTime = m.NowRegisterTime;
            marry.NowUnit = m.NowUnit;
            marry.NowPost = m.NowPost;
            marry.Other = m.Other;
            marry.UpdateTime = DateTime.Now;
            int count = mbll.UpdateMarry(marry);

            //退回修改状态
           // _UpdStatusback();

            //修改总表婚姻变化状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.MarryChgStatus1 = null;          
            tbll.UpdTotal(tl);


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

        #region 表9：干部配偶、子女涉嫌犯罪情况报告表（DT_CrimeReport）
        /// <summary>
        /// 犯罪情况页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Crime()
        {
            return View();
        }

        /// <summary>
        /// 犯罪情况修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdCrime(int id)
        {
            List<DT_CrimeReport> crime = cbll.SelectCrimeByUid(Convert.ToInt32(Session["id"]));
            ViewBag.crime = crime;

            return View();
        }

        /// <summary>
        /// 添加犯罪情况
        /// </summary>
        /// <param name="u"></param>
        public void _AddCrime(DT_CrimeReport c)
        {
            DT_CrimeReport cr = new DT_CrimeReport();
            cr.Id = c.Id;
            cr.UserId = Convert.ToInt32(Session["id"]);
            cr.YearTable = DateTime.Now.Year;
            cr.CrimerName = c.CrimerName;
            cr.Relation = c.Relation;
            cr.CrimerUnit = c.CrimerUnit;
            cr.LawAgency = c.LawAgency;
            cr.Result = c.Result;
            cr.Remark = c.Remark;
            cr.FillTime = DateTime.Now;
            int count = cbll.AddCrime(cr);

            //根据登录id查询最近一条UserInfoId
            int newuid = cbll.SelCrimeiddByUserid(Convert.ToInt32(Session["id"]));

            _UpdTotalCrimeid(newuid);

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
        /// 修改犯罪情况
        /// </summary>
        /// <param name="u"></param> 
        public void _UpdCrime()
        {
            DT_CrimeReport cr = cbll.SelCrimeByUid(Convert.ToInt32(Session["id"]));
            //cr.Id = c.Id;
            cr.UserId = Convert.ToInt32(Session["id"]);
            cr.CrimerName = Request["name"];
            cr.Relation = Request["relation"];
            cr.CrimerUnit = Request["unit"];
            cr.LawAgency = Request["law"];
            cr.Result = Request["result"];
            cr.Remark = Request["remark"];
            cr.UpdateTime = DateTime.Now;
            int count = cbll.UpdCrime(cr);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }
            Response.End();

        }

        /// <summary>
        /// 退回时 修改犯罪情况
        /// </summary>
        /// <param name="u"></param> 
        public void _UpdCrime_Back()
        {
            _UpdCrime();

            //退回修改状态
           // _UpdStatusback();

            //修改总表犯罪状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.CrimeStatus1 = null;
            tbll.UpdTotal(tl);

        }

        #endregion

        #region 干部操办本人及近亲婚丧喜庆事宜情况报告表（DT_WeddingandDie）
        /// <summary>
        /// 添加近亲婚丧
        /// </summary>
        /// <returns></returns>
        public ActionResult AddWeddingandDie()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        public void _AddWedding()
        {
            //DT_WeddingandDie wd = new DT_WeddingandDie();
            //wd.Arrange = w.Arrange;
            //wd.ManageTime = w.ManageTime;
            //wd.ManageAddress = w.ManageAddress;
            //wd.PartyObject = w.PartyObject;
            //wd.PartyNum = w.PartyNum;
            //wd.AcceptingMoney = w.AcceptingMoney;
            //wd.AcceptingCount = w.AcceptingCount;
            //wd.AcceptingValue = w.AcceptingValue;
            //wd.HandleStatus = w.HandleStatus;

            //wd.FillTime = DateTime.Now;

            //wbll.AddWedding(w);

            DT_WeddingandDie wd = new DT_WeddingandDie();
            wd.UserId = Convert.ToInt32(Session["id"]);
            wd.YearTable = DateTime.Now.Year;
            wd.Arrange = Request["arrange"];
            wd.ManageTime = Request["time"];
            wd.ManageAddress = Request["address"];
            wd.PartyObject = Request["object"];
            wd.PartyNum = Request["joincount"];
            wd.AcceptingMoney = Request["money"];
            wd.AcceptingCount = Request["giftcount"];
            wd.AcceptingValue = Request["giftvalue"];
            wd.HandleStatus = Request["result"];

            wd.Adivce = Request["advice"];

            wd.FillTime = DateTime.Now;

            if (Request["arrange"] == null || Request["arrange"] == "" || Request["time"] == null || Request["time"] == "" || Request["address"] == null || Request["address"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('信息不能为空！');location.href='/EnterFile/AddWeddingandDie';</script>");
            }
            else
            {
                int count = wbll.AddWedding(wd);

                //根据登录id查询最近一条WeddingId
                int newfid = wbll.SelWeddingidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表WeddingId 
                _UpdTotalWeddDieid(newfid);


                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }
            }


            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdWeddingandDie()
        {
            // 根据UserId查询近亲婚丧喜庆
            List<DT_WeddingandDie> weddingdie = wbll.SelectWeddingDieByUid(Convert.ToInt32(Session["id"]));
            ViewBag.weddingdie = weddingdie;
            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdWedding()
        {

            DT_WeddingandDie wd = wbll.SelectOneWeddingByUid(Convert.ToInt32(Session["id"]));
            wd.UserId = Convert.ToInt32(Session["id"]);
            wd.YearTable = DateTime.Now.Year;
            wd.Arrange = Request["arrange"];
            wd.ManageTime = Request["time"];
            wd.ManageAddress = Request["address"];
            wd.PartyObject = Request["object"];
            wd.PartyNum = Request["joincount"];
            wd.AcceptingMoney = Request["money"];
            wd.AcceptingCount = Request["giftcount"];
            wd.AcceptingValue = Request["giftvalue"];
            wd.HandleStatus = Request["result"];

            wd.Adivce = Request["advice"];

            wd.FillTime = DateTime.Now;

            if (Request["arrange"] == null || Request["arrange"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('信息不能为空！');location.href='/EnterFile/AddWeddingandDie';</script>");
            }
            else
            {
                int count = wbll.UpdWedding(wd);

                //根据登录id查询最近一条WeddingId
                //int newfid = wbll.SelWeddingidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表WeddingId 
                //_UpdTotalWeddDieid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
                }
            }


            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdWedding_Back()
        {
            _UpdWedding();

            //退回修改状态
            //_UpdStatusback();

            //修改总表犯罪状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.CrimeStatus1 = null;
            tbll.UpdTotal(tl);
            

        }


        #endregion

        #region 干部本人、配偶从业变更情况报告表（DT_IndustryChanges）
        /// <summary>
        /// 添加从业变更
        /// </summary>
        /// <returns></returns>
        public ActionResult AddIndustryChange()
        {
            return View();
        }

        public ActionResult UpdIndustryChange()
        {
            //根据UserId查询从业变更
            List<DT_IndustryChanges> industry = icbll.SelectIndustryByUid(Convert.ToInt32(Session["id"]));
            ViewBag.industry = industry;

            return View();
        }


        /// <summary>
        /// 添加
        /// </summary>
        public void _AddIndustryChange()
        {
            DT_IndustryChanges ic = new DT_IndustryChanges();
            ic.UserId = Convert.ToInt32(Session["id"]);
            ic.YearTable = DateTime.Now.Year;
            ic.Name = Request["name"];
            ic.Relation = Request["relation"];
            ic.ChangeTime = Request["time"];
            ic.LastUnit = Request["before_unit"];
            ic.NowUnit = Request["behind_unit"];
            ic.Reason = Request["reason"];
            ic.Remark = Request["remark"];
            ic.FillTime = DateTime.Now;

            if (Request["name"] == null || Request["name"] == "" || Request["relation"] == null || Request["relation"] == "" || Request["time"] == null || Request["time"] == "" || Request["before_unit"] == null || Request["before_unit"] == "" || Request["behind_unit"] == null || Request["behind_unit"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('请将信息填写完整！');location.href='/EnterFile/AddIndustryChange';</script>");
            }
            else
            {
                int count = icbll.AddIndustry(ic);

                //根据登录id查询最近一条IndustryId
                int newfid = icbll.SelIndustryidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表fid           
                _UpdTotalIndustryid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }

            }
            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdIndustryChange()
        {

            DT_IndustryChanges ic = icbll.SelectOneIndustryByUid(Convert.ToInt32(Session["id"]));
            ic.UserId = Convert.ToInt32(Session["id"]);
            ic.YearTable = DateTime.Now.Year;
            ic.Name = Request["name"];
            ic.Relation = Request["relation"];
            ic.ChangeTime = Request["time"];
            ic.LastUnit = Request["before_unit"];
            ic.NowUnit = Request["behind_unit"];
            ic.Reason = Request["reason"];
            ic.Remark = Request["remark"];
            ic.FillTime = DateTime.Now;

            int count = icbll.UpdIndustry(ic);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }

            Response.End();

        }


        /// <summary>
        /// 退回时 修改
        /// </summary>
        public void _UpdIndustryChange_Back()
        {

            _UpdIndustryChange();

            //退回修改状态
           // _UpdStatusback();

            //修改总表从业变更状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.IndustryStatus1 = null;
            tbll.UpdTotal(tl);


        }


        #endregion

        #region 干部其他重大事项报告表（DT_Important）
        /// <summary>
        /// 添加其他重大事项
        /// </summary>
        /// <returns></returns>
        public ActionResult AddImportant()
        {

            return View();
        }

        public ActionResult UpdImportant()
        {
            //根据UserId查询重大事项
            List<DT_Important> important = imbll.SelectImportantByUid(Convert.ToInt32(Session["id"]));
            ViewBag.important = important;

            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public void _AddImportant()
        {
            DT_Important im = new DT_Important();
            im.UserId = Convert.ToInt32(Session["id"]);
            im.YearTable = DateTime.Now.Year;
            im.Report = Request["report"];
            im.Remark = Request["remark"];
            im.FillTime = DateTime.Now;


            if (Request["report"] == null || Request["report"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('请将信息填写完整！');location.href='/EnterFile/AddImportant';</script>");
            }
            else
            {
                int count = imbll.AddImportant(im);
                //根据登录id查询最近一条Importantid
                int newfid = imbll.SelImportantidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表Importantid        
                _UpdTotalImportantid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }
            }
            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdImportant()
        {
            DT_Important im = imbll.SelectOneImportantByUid(Convert.ToInt32(Session["id"]));
            im.UserId = Convert.ToInt32(Session["id"]);
            im.YearTable = DateTime.Now.Year;
            im.Report = Request["report"];
            im.Remark = Request["remark"];
            im.FillTime = DateTime.Now;
            int count = imbll.UpdImportant(im);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }

            Response.End();

        }

        /// <summary>
        /// 退出时 修改
        /// </summary>
        public void _UpdImportant_Back()
        {
            _UpdImportant();

            //退回修改状态
           // _UpdStatusback();

            //修改总表重大事项状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
            tl.ImportantStatus1 = null;
            tbll.UpdTotal(tl);
        }

        #endregion

        #region 干部违纪违规处理及追究责任报告表（DT_Responsibility）
        /// <summary>
        /// 添加违纪违规处理
        /// </summary>
        /// <returns></returns>
        public ActionResult AddResponsibility()
        {

            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdResponsibility()
        {
            //根据UserId查询责任追究
            List<DT_Responsibility> respons = rsbll.SelectResponsByUid(Convert.ToInt32(Session["id"]));
            ViewBag.respons = respons;

            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public void _AddRespons()
        {
            DT_Responsibility rs = new DT_Responsibility();
            rs.UserId = Convert.ToInt32(Session["id"]);
            rs.YearTable = DateTime.Now.Year;
            rs.Nature = Request["nature"];
            rs.ResTime = Request["time"];
            rs.HandleOffice = Request["handleoffice"];
            rs.Fact = Request["fact"];
            rs.HandleStatus = Request["result"];
            rs.Remark = Request["remark"];
            rs.FillTime = DateTime.Now;

            if (Request["nature"] == null || Request["nature"] == "" || Request["time"] == null || Request["time"] == "" || Request["handleoffice"] == null || Request["handleoffice"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('请将信息填写完整！');location.href='/EnterFile/AddResponsibility';</script>");
            }
            else
            {
                int count = rsbll.AddRespons(rs);

                //根据登录id查询最近一条Responsid
                int newfid = rsbll.SelResponsidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表Responsid        
                _UpdTotalResponsid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }
            }
            Response.End();

        }


        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdRespons(DT_Responsibility r)
        {
            DT_Responsibility rs = rsbll.SelectOneResponsByUid(Convert.ToInt32(Session["id"]));

            rs.Nature = r.Nature;
            rs.ResTime = r.ResTime;
            rs.HandleOffice = r.HandleOffice;
            rs.Fact = r.Fact;
            rs.HandleStatus = r.HandleStatus;
            rs.Remark = r.Remark;
            rs.UpdateTime = DateTime.Now;

            int count = rsbll.UpdRespons(rs);

            //根据登录id查询最近一条Responsid
            int newfid = rsbll.SelResponsidByUserid(Convert.ToInt32(Session["id"]));
            //修改总表Responsid        
            _UpdTotalResponsid(newfid);

          
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
        /// 修改
        /// </summary>
        public void _UpdRespons_Back(DT_Responsibility r)
        {
            DT_Responsibility rs = rsbll.SelectOneResponsByUid(Convert.ToInt32(Session["id"]));

            rs.Nature = r.Nature;
            rs.ResTime = r.ResTime;
            rs.HandleOffice = r.HandleOffice;
            rs.Fact = r.Fact;
            rs.HandleStatus = r.HandleStatus;
            rs.Remark = r.Remark;
            rs.UpdateTime = DateTime.Now;

            int count = rsbll.UpdRespons(rs);

            //根据登录id查询最近一条Responsid
            int newfid = rsbll.SelResponsidByUserid(Convert.ToInt32(Session["id"]));
            //修改总表Responsid        
            _UpdTotalResponsid(newfid);

            //退回修改状态
           // _UpdStatusback();

            //修改总表责任追究状态为空
            DT_Total tl = tbll.SelTotalById(Convert.ToInt32(Session["id"]));
           // tl.Status = "未提交";
            tl.ResponsStatus1 = null;
            tbll.UpdTotal(tl);

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

        #region 干部信访核查情况表（DT_PetitionLetter）
        /// <summary>
        /// 添加信访核查
        /// </summary>
        /// <returns></returns>
        public ActionResult AddLetterChk()
        {


            return View();
        }

        public ActionResult UpdLetterChk()
        {
            //根据UserId查询信访核查
            List<DT_PetitionLetter> letterchk = lcbll.SelectLetterChkByUid(Convert.ToInt32(Session["id"]));
            ViewBag.letterchk = letterchk;

            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public void _AddLetterChk()
        {
            DT_PetitionLetter pl = new DT_PetitionLetter();
            pl.UserId = Convert.ToInt32(Session["id"]);
            pl.YearTable = DateTime.Now.Year;
            pl.RecordNum = Request["num"];
            pl.LetterTime = Request["time"];
            pl.FromUnit = Request["comeunit"];
            pl.ByManName = Request["bename"];
            pl.ByManPost = Request["bepost"];
            pl.ByManUnit = Request["beunit"];
            pl.ManName = Request["name"];
            pl.ManPost = Request["post"];
            pl.ManUnit = Request["unit"];
            pl.ManTel = Request["tel"];
            pl.Content = Request["content"];
            pl.SurveyResult = Request["checkresult"];
            pl.HandleResult = Request["handleresult"];
            pl.Remark = Request["remark"];
            pl.FillTime = DateTime.Now;

            if (Request["num"] == null || Request["num"] == "" || Request["time"] == null || Request["time"] == "" || Request["comeunit"] == null || Request["comeunit"] == "" || Request["bename"] == null || Request["bename"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('请将信息填写完整！');location.href='/EnterFile/AddLetterChk';</script>");
            }
            else
            {
                int count = lcbll.AddLetterChk(pl);

                //根据登录id查询最近一条LetterChkid
                int newfid = lcbll.SelLetterChkidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表LetterChkid        
                _UpdTotalLetterChkid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }
            }
            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdLetterChk()
        {
            DT_PetitionLetter pl = lcbll.SelectOneChkByUid(Convert.ToInt32(Session["id"]));
            pl.UserId = Convert.ToInt32(Session["id"]);
            pl.YearTable = DateTime.Now.Year;
            pl.RecordNum = Request["num"];
            pl.LetterTime = Request["time"];
            pl.FromUnit = Request["comeunit"];
            pl.ByManName = Request["bename"];
            pl.ByManPost = Request["bepost"];
            pl.ByManUnit = Request["beunit"];
            pl.ManName = Request["name"];
            pl.ManPost = Request["post"];
            pl.ManUnit = Request["unit"];
            pl.ManTel = Request["tel"];
            pl.Content = Request["content"];
            pl.SurveyResult = Request["checkresult"];
            pl.HandleResult = Request["handleresult"];
            pl.Remark = Request["remark"];
            pl.FillTime = DateTime.Now;

            int count = lcbll.UpdLetterChk(pl);


            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }

            Response.End();

        }

        #endregion

        #region 干部接受诫勉谈话表（DT_AdmonishingTalk）
        /// <summary>
        /// 添加诫勉谈话
        /// </summary>
        /// <returns></returns> 
        public ActionResult AddAdmonishTalk()
        {


            return View();
        }

        public ActionResult UpdAdmonishTalk()
        {
            //根据UserId查询诫勉谈话
            List<DT_AdmonishingTalk> admonish = atbll.SelectAdmonishByUid(Convert.ToInt32(Session["id"]));
            ViewBag.admonish = admonish;

            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public void _AddAdmonishTalk()
        {
            DT_AdmonishingTalk at = new DT_AdmonishingTalk();
            at.UserId = Convert.ToInt32(Session["id"]);
            at.YearTable = DateTime.Now.Year;
            at.BeLordTalk = Request["bename"];
            at.BeUnit = Request["beunit"];
            at.BePost = Request["bepost"];
            at.TalkReason = Request["reason"];
            at.LordTalk = Request["name"];
            at.Post = Request["post"];
            at.TalkTime = Request["time"];
            at.TalkAddress = Request["address"];
            at.Content = Request["content"];
            at.ObjectAdvice = Request["objectadvice"];
            at.LordTalkAdvice = Request["advice"];
            at.Remark = Request["remark"];
            at.FillTime = DateTime.Now;

            if (Request["bename"] == null || Request["bename"] == "" || Request["beunit"] == null || Request["beunit"] == "" || Request["bepost"] == null || Request["bepost"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');location.href='/EnterFile/AddAdmonishTalk';</script>");
            }
            else
            {
                int count = atbll.AddAdmonish(at);

                //根据登录id查询最近一条Admonishid
                int newfid = atbll.SelAdmonishidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表Admonishid        
                _UpdTotalAdmonishid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }
            }
            Response.End();

        }

        /// <summary>
        /// 添加
        /// </summary>
        public void _UpdAdmonishTalk()
        {
            DT_AdmonishingTalk at = atbll.SelectOneAdmonishByUid(Convert.ToInt32(Session["id"]));
            at.UserId = Convert.ToInt32(Session["id"]);
            at.YearTable = DateTime.Now.Year;
            at.BeLordTalk = Request["bename"];
            at.BeUnit = Request["beunit"];
            at.BePost = Request["bepost"];
            at.TalkReason = Request["reason"];
            at.LordTalk = Request["name"];
            at.Post = Request["post"];
            at.TalkTime = Request["time"];
            at.TalkAddress = Request["address"];
            at.Content = Request["content"];
            at.ObjectAdvice = Request["objectadvice"];
            at.LordTalkAdvice = Request["advice"];
            at.Remark = Request["remark"];
            at.FillTime = DateTime.Now;

            int count = atbll.UpdAdmonish(at);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }

            Response.End();

        }

        #endregion

        #region 干部接受廉政谈话表（DT_IncorruptTalk）
        /// <summary>
        /// 添加廉政谈话
        /// </summary>
        /// <returns></returns> 
        public ActionResult AddIncorruptTalk()
        {
            return View();
        }

        /// <summary>
        /// 修改廉政谈话
        /// </summary>
        /// <returns></returns> 
        public ActionResult UpdIncorruptTalk()
        {
            //根据UserId查询廉政谈话
            List<DT_IncorruptTalk> incorrupt = itbll.SelectIncorruptByUid(Convert.ToInt32(Session["id"]));
            ViewBag.incorrupt = incorrupt;

            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public void _AddIncorruptTalk()
        {
            DT_IncorruptTalk it = new DT_IncorruptTalk();
            it.UserId = Convert.ToInt32(Session["id"]);
            it.YearTable = DateTime.Now.Year;
            it.TalkReason = Request["reason"];
            it.TalkTime = Request["time"];
            it.TalkAddress = Request["address"];
            it.LordTalk = Request["lordtalk"];
            it.RecordPerson = Request["recordperson"];
            it.Content = Request["content"];
            it.Remark = Request["remark"];
            it.FillTime = DateTime.Now;

            if (Request["reason"] == null || Request["reason"] == "" || Request["time"] == null || Request["time"] == "" || Request["address"] == null || Request["address"] == "" || Request["lordtalk"] == null || Request["lordtalk"] == "" || Request["recordperson"] == null || Request["recordperson"] == "" || Request["content"] == null || Request["content"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('请将信息填写完整！');location.href='/EnterFile/AddIncorruptTalk';</script>");
            }
            else
            {
                int count = itbll.AddIncorrupt(it);

                //根据登录id查询最近一条Incorruptid
                int newfid = itbll.SelIncorruptidByUserid(Convert.ToInt32(Session["id"]));
                //修改总表Incorruptid        
                _UpdTotalIncorruptid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }

            }
            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdIncorruptTalk()
        {
            DT_IncorruptTalk it = itbll.SelectOneIncorruptByUid(Convert.ToInt32(Session["id"]));
            it.UserId = Convert.ToInt32(Session["id"]);
            it.YearTable = DateTime.Now.Year;
            it.TalkReason = Request["reason"];
            it.TalkTime = Request["time"];
            it.TalkAddress = Request["address"];
            it.LordTalk = Request["lordtalk"];
            it.RecordPerson = Request["recordperson"];
            it.Content = Request["content"];
            it.Remark = Request["remark"];
            it.FillTime = DateTime.Now;

            int count = itbll.UpdIncorrupt(it);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }

            Response.End();

        }

        #endregion

        #region 干部接受函询情况登记表（DT_ApplyByLetter）
        /// <summary>
        /// 添加函询
        /// </summary>
        /// <returns></returns> 
        public ActionResult AddApplyLetter()
        {
            return View();
        }

        /// <summary>
        /// 修改函询
        /// </summary>
        /// <returns></returns> 
        public ActionResult UpdApplyLetter()
        {
            //根据UserId查询函询情况
            List<DT_ApplyByLetter> apply = albll.SelectApplyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.apply = apply;

            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        public void _AddApplyLetter()
        {
            DT_ApplyByLetter al = new DT_ApplyByLetter();
            al.UserId = Convert.ToInt32(Session["id"]);
            al.YearTable = DateTime.Now.Year;
            al.ApplyTime = Request["time"];
            al.Reason = Request["reason"];
            al.Answer = Request["answer"];
            al.Remark = Request["remark"];
            al.FillTime = DateTime.Now;

            if (Request["time"] == null || Request["time"] == "" || Request["reason"] == null || Request["reason"] == "" || Request["answer"] == null || Request["answer"] == "")
            {
                Response.Write("<script type='text/javascript'>alert('请将信息填写完整！');location.href='/EnterFile/AddApplyLetter';</script>");
            }
            else
            {
                int count = albll.AddApplyLetter(al);

                //根据登录id查询最近一条ApplyLetterid
                int newfid = albll.SelApplyLetteridByUserid(Convert.ToInt32(Session["id"]));
                //修改总表ApplyLetterid        
                _UpdTotalApplyLetterid(newfid);

                if (count > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功！');location.href='/EnterFile/Index';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试！');</script>");
                }
            }
            Response.End();

        }

        /// <summary>
        /// 修改
        /// </summary>
        public void _UpdApplyLetter()
        {
            DT_ApplyByLetter al = albll.SelectOneApplyByUid(Convert.ToInt32(Session["id"]));
            al.UserId = Convert.ToInt32(Session["id"]);
            al.YearTable = DateTime.Now.Year;
            al.ApplyTime = Request["time"];
            al.Reason = Request["reason"];
            al.Answer = Request["answer"];
            al.Remark = Request["remark"];
            al.FillTime = DateTime.Now;

            int count = albll.UpdApplyLetter(al);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('修改成功！');location.href='/EnterFile/Index';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('修改失败，请重试！');</script>");
            }

            Response.End();

        }

        #endregion

        #region 奖惩情况表（DT_RewardPunishTotal）
        /// <summary>
        /// 奖惩情况表
        /// </summary>
        /// <returns></returns>
        public ActionResult RewardPunish()
        {
            //所有获奖
            List<DT_Reward> rewardlist = rpbll.SelectReward(Convert.ToInt32(Session["id"]));
            ViewBag.rewardlist = rewardlist;

            //所有惩罚
            List<DT_Punish> punishlist = rpbll.SelectPunish(Convert.ToInt32(Session["id"]));
            ViewBag.punishlist = punishlist;

            return View();
        }

        /// <summary>
        /// 修改奖惩情况表
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdRewardPunish(int id)
        {
            //所有奖惩
            List<DT_RewardPunishTotal> rttotal = rpbll.SelectRPTotalByUid(Convert.ToInt32(Session["id"]));
            ViewBag.rttotal = rttotal;

            //所有获奖
            List<DT_Reward> rewardlist = rpbll.SelectReward(Convert.ToInt32(Session["id"]));
            ViewBag.rewardlist = rewardlist;

            //所有惩罚
            List<DT_Punish> punishlist = rpbll.SelectPunish(Convert.ToInt32(Session["id"]));
            ViewBag.punishlist = punishlist;

            return View();
        }

        /// <summary>
        /// 添加奖惩总表
        /// </summary>
        /// <param name="r"></param>
        public void _AddRewardPunish(DT_RewardPunishTotal r)
        {
            DT_RewardPunishTotal rp = new DT_RewardPunishTotal();
            rp.UserId = Convert.ToInt32(Session["id"]);
            rp.YearTable = DateTime.Now.Year;

            rp.FillTime = DateTime.Now;

            int count = rpbll.AddRPTotal(rp);

            //根据登录id查询最近一条Rewardid
            int newfid = rpbll.SelRPTotalidByUserid(Convert.ToInt32(Session["id"]));
            //修改总表Rewardid     
            _UpdTotalRewardPunishid(newfid);

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
        /// 修改奖惩总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdRewardPunish(DT_RewardPunishTotal r)
        {
            DT_RewardPunishTotal rp = rpbll.SelectOneRPTotalByUid(Convert.ToInt32(Session["id"]));           
            rp.UpdateTime = DateTime.Now;
            int count = rpbll.UpdRPTotal(rp); 

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


        #region 获奖
        /// <summary>
        /// 添加获奖
        /// </summary>
        /// <param name="r"></param>
        public void _AddReward(DT_Reward r)
        {
            DT_Reward re = new DT_Reward();
            re.UserId = Convert.ToInt32(Session["id"]);
            re.YearTable = DateTime.Now.Year;
            re.RewardsTime = r.RewardsTime;
            re.RewardsDptandName = r.RewardsDptandName;
            re.Remark = r.Remark;

            int count = rpbll.AddReward(re);
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
        /// 修改获奖
        /// </summary>
        /// <param name="r"></param>
        public void _UpdReward(DT_Reward r)
        {
            DT_Reward re = rpbll.QueryRewardById(r.Id);
            re.RewardsTime = r.RewardsTime;
            re.RewardsDptandName = r.RewardsDptandName;
            re.Remark = r.Remark;

            int count = rpbll.UpdReward(re);
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
        /// 删除获奖
        /// </summary>
        /// <param name="r"></param>
        public void _DelReward(DT_Reward r)
        {
            DT_Reward re = rpbll.QueryRewardById(r.Id);

            int count = rpbll.DelReward(re);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/RewardPunish';</script>");
            }
            Response.End();

        }

        #endregion

        #region 惩处
        /// <summary>
        /// 添加惩处
        /// </summary>
        /// <param name="r"></param>
        public void _AddPunish(DT_Punish p)
        {
            DT_Punish pu = new DT_Punish();
            pu.UserId = Convert.ToInt32(Session["id"]);
            pu.YearTable = DateTime.Now.Year;
            pu.PunishTime = p.PunishTime;
            pu.PunishName = p.PunishName;
            pu.PunishReason = p.PunishReason;
            pu.PunishDpt = p.PunishDpt;
            pu.Remark = p.Remark;

            int count = rpbll.AddPunish(pu);
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
        /// 修改惩处
        /// </summary>
        /// <param name="r"></param>
        public void _UpdPunish(DT_Punish p)
        {
            DT_Punish pu = rpbll.QueryPunishById(p.Id);
            pu.UserId = Convert.ToInt32(Session["id"]);
            pu.YearTable = DateTime.Now.Year;
            pu.PunishTime = p.PunishTime;
            pu.PunishName = p.PunishName;
            pu.PunishReason = p.PunishReason;
            pu.PunishDpt = p.PunishDpt;
            pu.Remark = p.Remark;

            int count = rpbll.UpdPunish(pu);
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
        /// 删除惩处
        /// </summary>
        /// <param name="r"></param>
        public void _DelPunish(DT_Punish p)
        {
            DT_Punish pu = rpbll.QueryPunishById(p.Id);

            int count = rpbll.DelPunish(pu);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/RewardPunish';</script>");
            }
            Response.End();

        }

        #endregion

      
        #endregion

        #region 拒收或上交礼金登记表（DT_RefuseGiftTotal）
        /// <summary>
        /// 拒收或上交礼金
        /// </summary>
        /// <returns></returns>
        public ActionResult RefuseGift()
        {
            //所有拒收上交礼金
            List<DT_RefuseGift> relist = rgbll.SelectRefuseByUid(Convert.ToInt32(Session["id"]));

            ViewBag.relist=relist;

            return View();
        }

        /// <summary>
        /// 修改拒收或上交礼金表
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdRefuseGift(int id)
        {
            //所有拒收上交礼金
            List<DT_RefuseGift> relist = rgbll.SelectRefuseByUid(Convert.ToInt32(Session["id"]));

            ViewBag.relist = relist;

            return View();
        }

        /// <summary>
        /// 添加总表
        /// </summary>
        /// <param name="r"></param>
        public void _AddRefuseTotal(DT_RefuseGiftTotal r)
        {
            DT_RefuseGiftTotal re = new DT_RefuseGiftTotal();
            re.UserId = Convert.ToInt32(Session["id"]);
            re.YearTable = DateTime.Now.Year;
            re.FillTime = r.FillTime;
            re.Remark = r.Remark;

            int count = rgbll.AddRefuseTotal(re);

            //根据登录id查询最近一条RefuseGiftid
            int newfid = rgbll.SelRefuseTotalidByUserid(Convert.ToInt32(Session["id"]));
            //修改总表RefuseGiftid     
            _UpdTotalRefuseid(newfid);

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
        /// 修改拒收礼金总表
        /// </summary>
        /// <param name="u"></param>
        public void _UpdRefuseTotal(DT_RefuseGiftTotal r)
        {
            DT_RefuseGiftTotal rg = rgbll.SelectOneRefuseTotalByUid(Convert.ToInt32(Session["id"])); 
            rg.UpdateTime = DateTime.Now;
            int count = rgbll.UpdRefuseTotal(rg);

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



        #region 拒收礼金分表       
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddRefuse(DT_RefuseGift r)
        {
            DT_RefuseGift re = new DT_RefuseGift();
            re.UserId = Convert.ToInt32(Session["id"]);
            re.YearTable = DateTime.Now.Year;
            re.HandInMoney = r.HandInMoney;
            re.HandInName = r.HandInName;
            re.HandInCount = r.HandInCount;
            re.HandInTime = r.HandInTime;
            re.HandInDpt = r.HandInDpt;
            re.Remark = r.Remark;

            int count = rgbll.AddRefuse(re);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdRefuse(DT_RefuseGift r)
        {
            DT_RefuseGift re = rgbll.QueryById(r.Id);
            re.HandInMoney = r.HandInMoney;
            re.HandInName = r.HandInName;
            re.HandInCount = r.HandInCount;
            re.HandInTime = r.HandInTime;
            re.HandInDpt = r.HandInDpt;
            re.Remark = r.Remark;

            int count = rgbll.UpdRefuse(re);
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelRefuse(DT_RefuseGift r)
        {
            DT_RefuseGift re = rgbll.QueryById(r.Id);

            int count = rgbll.DelRefuse(re);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/RefuseGift';</script>");
            }
            Response.End();

        }

        #endregion

        #endregion

        #region 子女住房情况报告表（DT_HousingTotal）
      

        #region 住房总表
        /// <summary>
        /// 子女住房情况
        /// </summary>
        /// <returns></returns>
        public ActionResult Housing()
        {
            //住房
            List<DT_HousingHouse> houselist = hbll.SelectHouseByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.houselist = houselist;
            //购房
            List<DT_HousingBuy> buylist = hbll.SelectBuyByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.buylist = buylist;
            //售房
            List<DT_HousingSell> selllist = hbll.SelectSellByUid(Convert.ToInt32(Session["id"]));
            ViewBag.selllist = selllist;
            //租房
            List<DT_HousingRentout> rentoutlist = hbll.SelectRentoutByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.rentoutlist = rentoutlist;
            //建房
            List<DT_HousingBuild> buildlist = hbll.SelectBuildByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.buildlist = buildlist;

            return View();
        }

        /// <summary>
        /// 修改住房总表
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdHousing(int id)
        {
            //住房
            List<DT_HousingHouse> houselist = hbll.SelectHouseByUid(Convert.ToInt32(Session["id"]));
            ViewBag.houselist = houselist;
            //购房
            List<DT_HousingBuy> buylist = hbll.SelectBuyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.buylist = buylist;
            //售房
            List<DT_HousingSell> selllist = hbll.SelectSellByUid(Convert.ToInt32(Session["id"]));
            ViewBag.selllist = selllist;
            //租房
            List<DT_HousingRentout> rentoutlist = hbll.SelectRentoutByUid(Convert.ToInt32(Session["id"]));
            ViewBag.rentoutlist = rentoutlist;
            //建房
            List<DT_HousingBuild> buildlist = hbll.SelectBuildByUid(Convert.ToInt32(Session["id"]));
            ViewBag.buildlist = buildlist;

            //住房总表
            List<DT_HousingTotal> housetotallist = hbll.SelectHousingTotalByUid(Convert.ToInt32(Session["id"]));  
            ViewBag.housetotallist = housetotallist;



            return View();
        }


        /// <summary>
        /// 添加总表
        /// </summary>
        /// <param name="r"></param>
        public void _AddHouseTotal(DT_HousingTotal h)
        {
            DT_HousingTotal ho = new DT_HousingTotal();
            ho.UserId = Convert.ToInt32(Session["id"]);
            ho.YearTable = DateTime.Now.Year;
            ho.PartnerName = h.PartnerName;
            ho.PartnerUnit = h.PartnerUnit;
            ho.PartnerPost = h.PartnerPost;
            ho.Other = h.Other;
            ho.FillTime = DateTime.Now;

            //根据登录id查询最近一条HousingTotalid
            int newfid = hbll.SelHousingTotalidByUserid(Convert.ToInt32(Session["id"]));
            //修改总表HousingTotalid     
            _UpdTotalHouseid(newfid);

            int count = hbll.AddHousingTotal(ho);
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
        /// 修改总表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdHouseTotal(DT_HousingTotal h)
        {
            DT_HousingTotal ho = hbll.SelectOneHousingTotalByUid(Convert.ToInt32(Session["id"]));  
            ho.PartnerName = h.PartnerName;
            ho.PartnerUnit = h.PartnerUnit;
            ho.PartnerPost = h.PartnerPost;
            ho.Other = h.Other;
            ho.UpdateTime = DateTime.Now;

            int count = hbll.UpdHousingTotal(ho);
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

        #region 住房
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddHouse(DT_HousingHouse h)
        {
            DT_HousingHouse ho = new DT_HousingHouse();
            ho.UserId = Convert.ToInt32(Session["id"]);
            ho.YearTable = DateTime.Now.Year;
            ho.HouseAddress = h.HouseAddress;
            ho.Area = h.Area;
            ho.HouseNature = h.HouseNature;
            ho.HouseFrom = h.HouseFrom;
            ho.PropertyOwner = h.PropertyOwner;

            int count = hbll.AddHouse(ho);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateHouse(DT_HousingHouse h)
        {
            DT_HousingHouse ho = hbll.QueryHouseById(h.Id);
            ho.HouseAddress = h.HouseAddress;
            ho.Area = h.Area;
            ho.HouseNature = h.HouseNature;
            ho.HouseFrom = h.HouseFrom;
            ho.PropertyOwner = h.PropertyOwner;

            int count = hbll.UpdHouse(ho);  
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelHouse(DT_HousingHouse h)
        {
            DT_HousingHouse re = hbll.QueryHouseById(h.Id);

            int count = hbll.DelHouse(re); 

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/Housing';</script>");
            }
            Response.End();

        }
        #endregion

        #region 购房
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddBuy(DT_HousingBuy h)
        {
            DT_HousingBuy ho = new DT_HousingBuy();
            ho.UserId = Convert.ToInt32(Session["id"]);
            ho.YearTable = DateTime.Now.Year;
            ho.BuyHouseAddress = h.BuyHouseAddress;
            ho.BuyHouseArea = h.BuyHouseArea;
            ho.BuyHouseMoney = h.BuyHouseMoney;
            ho.BuyHouseIncome = h.BuyHouseIncome;
            ho.BuyHouseTime = h.BuyHouseTime;

            int count = hbll.AddBuy(ho);  
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateBuy(DT_HousingBuy h)
        {
            DT_HousingBuy ho = hbll.QueryBuyById(h.Id);
            ho.BuyHouseAddress = h.BuyHouseAddress;
            ho.BuyHouseArea = h.BuyHouseArea;
            ho.BuyHouseMoney = h.BuyHouseMoney;
            ho.BuyHouseIncome = h.BuyHouseIncome;
            ho.BuyHouseTime = h.BuyHouseTime;

            int count = hbll.UpdBuy(ho); 
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelBuy(DT_HousingBuy h)
        {
            DT_HousingBuy re = hbll.QueryBuyById(h.Id);

            int count = hbll.DelBuy(re); 

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/Housing';</script>");
            }
            Response.End();

        }
        #endregion

        #region 售房
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddSell(DT_HousingSell h)
        {
            DT_HousingSell ho = new DT_HousingSell();
            ho.UserId = Convert.ToInt32(Session["id"]);
            ho.YearTable = DateTime.Now.Year;
            ho.SellHouseAddress = h.SellHouseAddress;
            ho.SellHouseArea = h.SellHouseArea;
            ho.SellHouseNature = h.SellHouseNature;
            ho.SellHouseTime = h.SellHouseTime;
            ho.SellHouseMoney = h.SellHouseMoney;

            int count = hbll.AddSell(ho);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateSell(DT_HousingSell h)
        {
            DT_HousingSell ho = hbll.QuerySellById(h.Id);  
            ho.SellHouseAddress = h.SellHouseAddress;
            ho.SellHouseArea = h.SellHouseArea;
            ho.SellHouseNature = h.SellHouseNature;
            ho.SellHouseTime = h.SellHouseTime;
            ho.SellHouseMoney = h.SellHouseMoney;

            int count = hbll.UpdSell(ho); 
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelSell(DT_HousingSell h)
        {
            DT_HousingSell re = hbll.QuerySellById(h.Id);

            int count = hbll.DelSell(re); 

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/Housing';</script>");
            }
            Response.End();

        }
        #endregion

        #region 租房
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddRentOut(DT_HousingRentout h)
        {
            DT_HousingRentout ho = new DT_HousingRentout();
            ho.UserId = Convert.ToInt32(Session["id"]);
            ho.YearTable = DateTime.Now.Year;
            ho.RentoutAddress = h.RentoutAddress;
            ho.RentoutArea = h.RentoutArea;
            ho.RentoutNature = h.RentoutNature;
            ho.RentoutTime = h.RentoutTime;
            ho.RentoutMoney = h.RentoutMoney;

            int count = hbll.AddRentout(ho);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateRentOut(DT_HousingRentout h)
        {
            DT_HousingRentout ho = hbll.QueryRentoutById(h.Id);
            ho.RentoutAddress = h.RentoutAddress;
            ho.RentoutArea = h.RentoutArea;
            ho.RentoutNature = h.RentoutNature;
            ho.RentoutTime = h.RentoutTime;
            ho.RentoutMoney = h.RentoutMoney;

            int count = hbll.UpdRentout(ho); 
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelRentOut(DT_HousingRentout h)
        {
            DT_HousingRentout re = hbll.QueryRentoutById(h.Id);

            int count = hbll.DelRentout(re);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/Housing';</script>");
            }
            Response.End();

        }
        #endregion

        #region 建房
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddBuild(DT_HousingBuild h)
        {
            DT_HousingBuild ho = new DT_HousingBuild();
            ho.UserId = Convert.ToInt32(Session["id"]);
            ho.YearTable = DateTime.Now.Year;
            ho.BuildHousesAddress = h.BuildHousesAddress;
            ho.BuildHousesArea = h.BuildHousesArea;
            ho.BuildHousesUnit = h.BuildHousesUnit;
            ho.BuildHousesTotal = h.BuildHousesTotal;
            ho.Payment = h.Payment;

            int count = hbll.AddBuild(ho);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateBuild(DT_HousingBuild h)
        {
            DT_HousingBuild ho = hbll.QueryBuildById(h.Id);  
            ho.BuildHousesAddress = h.BuildHousesAddress;
            ho.BuildHousesArea = h.BuildHousesArea;
            ho.BuildHousesUnit = h.BuildHousesUnit;
            ho.BuildHousesTotal = h.BuildHousesTotal;
            ho.Payment = h.Payment;


            int count = hbll.UpdBuild(ho);
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelBuild(DT_HousingBuild h)
        {
            DT_HousingBuild re = hbll.QueryBuildById(h.Id);

            int count = hbll.DelBuild(re);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/Housing';</script>");
            }
            Response.End();

        }
        #endregion

        #endregion

        #region 出国情况报告表（DT_GoAbroadTotal）
      
        #region 出国总表
        /// <summary>
        /// 出国情况报告表
        /// </summary>
        /// <returns></returns>
        public ActionResult GoAbroad()
        {
            //办企
            List<DT_GoAbroadCompany> companylist = abll.SelectCompanyByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.companylist = companylist;
            //留学
            List<DT_GoAbroadStudy> studylist = abll.SelectStudyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.studylist = studylist;
            //定居
            List<DT_GoAbroadSettler> settlelist = abll.SelectSettleByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.settlelist = settlelist;
            //出国总表
            List<DT_GoAbroadTotal> abroadlist = abll.SelectAbroadTotalByUid(Convert.ToInt32(Session["id"])); 
            ViewBag.abroadlist = abroadlist;

            return View();
        }

        /// <summary>
        /// 修改出国情况报告表
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdGoAbroad(int id)
        {
            //办企
            List<DT_GoAbroadCompany> companylist = abll.SelectCompanyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.companylist = companylist;
            //留学
            List<DT_GoAbroadStudy> studylist = abll.SelectStudyByUid(Convert.ToInt32(Session["id"]));
            ViewBag.studylist = studylist;
            //定居
            List<DT_GoAbroadSettler> settlelist = abll.SelectSettleByUid(Convert.ToInt32(Session["id"]));
            ViewBag.settlelist = settlelist;
            //出国总表
            List<DT_GoAbroadTotal> abroadlist = abll.SelectAbroadTotalByUid(Convert.ToInt32(Session["id"]));
            ViewBag.abroadlist = abroadlist;

            return View();
        }

        /// <summary>
        /// 添加总表
        /// </summary>
        /// <param name="r"></param>
        public void _AddAbroadTotal(DT_GoAbroadTotal a)
        {
            DT_GoAbroadTotal ab = new DT_GoAbroadTotal();
            ab.UserId = Convert.ToInt32(Session["id"]);
            ab.YearTable = DateTime.Now.Year;
            ab.LandingPaper = a.LandingPaper;
            ab.HKCertificate = a.HKCertificate;
            ab.MarryName = a.MarryName;
            ab.MarryUnit = a.MarryUnit;
            ab.RegisterTime = a.RegisterTime;
            ab.MarryPartner = a.MarryPartner;
            ab.PartnerNational = a.PartnerNational;
            ab.FillTime = DateTime.Now;
            int count = abll.AddAbroadTotal(ab);

            //根据登录id查询最近一条Abroadid
            int newfid = abll.SelAbroadTotalidByUserid(Convert.ToInt32(Session["id"])); 
            //修改总表Abroadid     
            _UpdTotalAbroadid(newfid);

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
        /// 修改总表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdAbroadTotal(DT_GoAbroadTotal a)
        {
            DT_GoAbroadTotal ab = abll.SelectOneAbroadTotalByUid(Convert.ToInt32(Session["id"])); 
            ab.LandingPaper = a.LandingPaper;
            ab.HKCertificate = a.HKCertificate;
            ab.MarryName = a.MarryName;
            ab.MarryUnit = a.MarryUnit;
            ab.RegisterTime = a.RegisterTime;
            ab.MarryPartner = a.MarryPartner;
            ab.PartnerNational = a.PartnerNational;
            ab.FillTime = DateTime.Now;

            int count = abll.UpdAbroadTotal(ab);
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

        #region 办企
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddCompany(DT_GoAbroadCompany c)
        {
            DT_GoAbroadCompany co = new DT_GoAbroadCompany();
            co.UserId = Convert.ToInt32(Session["id"]);
            co.YearTable = DateTime.Now.Year;
            co.BuildCompanyName = c.BuildCompanyName;
            co.BuildCompanyTitle = c.BuildCompanyTitle;
            co.BuildCompanyAddress = c.BuildCompanyAddress;
            co.CompanyName = c.CompanyName;

            int count = abll.AddCompany(co);  
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateCompany(DT_GoAbroadCompany c)
        {
            DT_GoAbroadCompany co = abll.QueryCompanyById(c.Id);
            co.BuildCompanyName = c.BuildCompanyName;
            co.BuildCompanyTitle = c.BuildCompanyTitle;
            co.BuildCompanyAddress = c.BuildCompanyAddress;
            co.CompanyName = c.CompanyName;

            int count = abll.UpdCompany(co);
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelCompany(DT_GoAbroadCompany c)
        {
            DT_GoAbroadCompany co = abll.QueryCompanyById(c.Id);

            int count = abll.DelCompany(co);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/GoAbroad';</script>");
            }
            Response.End();

        }
        #endregion

        #region 留学
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddStudy(DT_GoAbroadStudy s)
        {
            DT_GoAbroadStudy st = new DT_GoAbroadStudy();
            st.UserId = Convert.ToInt32(Session["id"]);
            st.YearTable = DateTime.Now.Year;
            st.StudyName = s.StudyName;
            st.StudyTitle = s.StudyTitle;
            st.StudyTime = s.StudyTime;
            st.StudyAddress = s.StudyAddress;
            st.StudyMoney = s.StudyMoney;

            int count = abll.AddStudy(st);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateStudy(DT_GoAbroadStudy s)
        {
            DT_GoAbroadStudy st = abll.QueryStudyById(s.Id);
            st.StudyName = s.StudyName;
            st.StudyTitle = s.StudyTitle;
            st.StudyTime = s.StudyTime;
            st.StudyAddress = s.StudyAddress;
            st.StudyMoney = s.StudyMoney;

            int count = abll.UpdStudy(st);
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelStudy(DT_GoAbroadStudy s)
        {
            DT_GoAbroadStudy st = abll.QueryStudyById(s.Id);

            int count = abll.DelStudy(st);
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/GoAbroad';</script>");
            }
            Response.End();

        }
        #endregion

        #region 定居
        /// <summary>
        /// 添加分表
        /// </summary>
        /// <param name="r"></param>
        public void _AddSettle(DT_GoAbroadSettler s)
        {
            DT_GoAbroadSettler se = new DT_GoAbroadSettler();
            se.UserId = Convert.ToInt32(Session["id"]);
            se.YearTable = DateTime.Now.Year;
            se.Settler = s.Settler;
            se.SettlerTitle = s.SettlerTitle;
            se.SettleTime = s.SettleTime;
            se.SettleAddress = s.SettleAddress;
            se.SettlerWork = s.SettlerWork;

            int count = abll.AddSettle(se);
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
        /// 修改分表
        /// </summary>
        /// <param name="r"></param>
        public void _UpdateSettle(DT_GoAbroadSettler s)
        {
            DT_GoAbroadSettler se = abll.QuerySettleById(s.Id);
            se.Settler = s.Settler;
            se.SettlerTitle = s.SettlerTitle;
            se.SettleTime = s.SettleTime;
            se.SettleAddress = s.SettleAddress;
            se.SettlerWork = s.SettlerWork;

            int count = abll.UpdSettle(se);
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
        /// 删除分表
        /// </summary>
        /// <param name="r"></param>
        public void _DelSettle(DT_GoAbroadSettler s)
        {
            DT_GoAbroadSettler se = abll.QuerySettleById(s.Id);

            int count = abll.DelSettle(se);

            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
                Response.Write("<script type='text/javascript'>window.location.href='/EnterFile/GoAbroad';</script>");
            }
            Response.End();

        }
        #endregion

        #endregion


        #region 上传图片
        /// <summary>
        /// 附件上传 ActionResult
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        public void AjaxUpload()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //if (files.Count == 0) return Json("Faild", JsonRequestBehavior.AllowGet);
            if (files.Count != 0)
            {
                MD5 md5Hasher = new MD5CryptoServiceProvider();
                /*计算指定Stream对象的哈希值*/
                byte[] arrbytHashValue = md5Hasher.ComputeHash(files[0].InputStream);
                /*由以连字符分隔的十六进制对构成的String，其中每一对表示value中对应的元素；例如“F-2C-4A”*/
                string strHashData = System.BitConverter.ToString(arrbytHashValue).Replace("-", "");
                string FileEextension = Path.GetExtension(files[0].FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                string virtualPath = string.Format("../Content/Upload/Images/{0}/{1}{2}", uploadDate, strHashData, FileEextension);
                string fullFileName = Server.MapPath(virtualPath);
                //创建文件夹，保存文件
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    files[0].SaveAs(fullFileName);
                }
                string fileName = files[0].FileName.Substring(files[0].FileName.LastIndexOf("\\") + 1, files[0].FileName.Length - files[0].FileName.LastIndexOf("\\") - 1);
                string fileSize = GetFileSize(files[0].ContentLength);

            }

            // return Json(new { FileName = fileName, FilePath = virtualPath, FileSize = fileSize }, "text/html", JsonRequestBehavior.AllowGet);

            //return RedirectToAction("AddBaseInfo1","EnterFile");
        }
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string GetFileSize(long bytes)
        {
            long kblength = 1024;
            long mbLength = 1024 * 1024;
            if (bytes < kblength)
                return bytes.ToString() + "B";
            if (bytes < mbLength)
                return decimal.Round(decimal.Divide(bytes, kblength), 2).ToString() + "KB";
            else
                return decimal.Round(decimal.Divide(bytes, mbLength), 2).ToString() + "MB";
        }


        #endregion


        #region 判断总表里是否存在该用户userid
        public void IsExistsUser()
        {
          int? count= tbll.IsExists(Convert.ToInt32(Session["id"]));
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


        #endregion

    }
}
