using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yisaa.BLL;
using Yisaa.DAL;

namespace gafj_gblz.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //短信验证码接口的测试数据（天下畅通平台给参数）  
        public static String url = "http://service.winic.org:8009/sys_port/gateway/index.asp";
        public static String userid = "1";
        public static String account = "大白";
        public static String password = "15957178843";

        #region 短信验证码

        #region GetCode()-获取验证码
        /// <summary>
        /// 返回json到界面
        /// </summary>
        /// <returns>string</returns>
        public ActionResult GetCode()
        {
            try
            {
                bool result;
                string code = "";
                //随机生成6位短信验证码    
                Random rand = new Random();
                for (int i = 0; i < 6; i++)
                {
                    code += rand.Next(0, 10).ToString();
                }


                //bool result;
                //接收前台传过来的参数。短信验证码和手机号码
               // string code = Request["Code"];
                string phoNum = Request["tel"];

                // 短信验证码存入session(session的默认失效时间30分钟) 
                //也可存入Memcached缓存
                Session.Add("code", code);

                // 短信内容+随机生成的6位短信验证码    
                String content = "【欢迎登录】 您的登录验证码为:" + code + "，如非本人操作请忽略。有疑问请联系我们：http://blog.csdn.net/u010028869";

                // 单个手机号发送短信
                if (!SendMessage(content, phoNum, url, userid, password, account))
                {
                    result = false;// 失败    
                }
                else
                {
                    result = true;// 成功    
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 短信发送方法
        /// <summary>
        /// 短信发送方法
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="phoNum">手机号码</param>
        /// <param name="url">请求地址</param>
        /// <param name="userid">企业id</param>
        /// <param name="password">密码</param>
        /// <param name="account">用户帐号</param>
        /// <returns>bool 是否发送成功</returns>
        public bool SendMessage(string content, string phoNum, string url, string userid, string password, string account)
        {
            try
            {
                Encoding myEncoding = Encoding.GetEncoding("UTF-8");
                //按照平台给定格式，组装发送参数 包括用户id，密码，账户，短信内容，账户等等信息
                string param = "action=send&userid=" + userid + "&account=" + HttpUtility.UrlEncode(account, myEncoding) + "&password=" + HttpUtility.UrlEncode(password, myEncoding) + "&mobile=" + phoNum + "&content=" + HttpUtility.UrlEncode(content, myEncoding) + "&sendTime=";

                //发送请求
                byte[] postBytes = Encoding.ASCII.GetBytes(param);
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                req.ContentLength = postBytes.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(postBytes, 0, postBytes.Length);
                }


                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                //获取返回的结果 
                using (WebResponse wr = req.GetResponse()) 
                {
                    StreamReader sr = new StreamReader(wr.GetResponseStream(), System.Text.Encoding.UTF8);
                    System.IO.StreamReader xmlStreamReader = sr;
                    //加载XML文档
                    xmlDoc.Load(xmlStreamReader);
                }
                //解析XML文档，进行相应判断
                if (xmlDoc == null)
                {
                    return false;
                }
                else
                {
                    String message = xmlDoc.GetElementsByTagName("message").Item(0).InnerText.ToString();
                    if (message == "ok")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion

        #region CheckCode()-检查验证码是否正确 

        public ActionResult CheckCode()
        {
            bool result = false;
            //用户输入的验证码
            string checkCode = Request["CheckCode"].Trim();
            //取出存在session中的验证码
            string code = Session["code"].ToString();
            try
            {
                //验证是否一致
                if (checkCode != code)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception("短信验证失败", e);
            }
        }
        #endregion

        #endregion

        #region 填档未开始/已结束
          /// <summary>
        /// 填档未开始
        /// </summary>
        /// <returns></returns>
        public ActionResult NoStart()
        {
            return View();
        }
        /// <summary>
        /// 填档已经结束
        /// </summary>
        /// <returns></returns>
        public ActionResult HasStop()
        {
            return View();
        }
        #endregion

        #region 登录/退出
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 安全退出
        /// </summary>       
        public ActionResult LogOut()
        {
            Session["user"] = null;

            Session.Abandon(); //清空用户登陆之后的所有session对象

            return RedirectToAction("Login", "Home"); //跳转至登陆页面
        }

       #region 登录记录
            /// <summary>
           /// 登录记录
           /// </summary>
           /// <param name="id"></param>
           /// <param name="num"></param>
           /// <returns></returns>
            public int GetLoginRecord(int id,int num)
            {
                UserBLL ubll = new UserBLL();
                //登录IP
                string ip = Request.UserHostAddress;
                string remark = "正常登录";
           

                DT_UserLoginRecord ulr = ubll.QueryOneUser(id);
                ulr.LoginTime = DateTime.Now;
                ulr.LoginIp = ip;
                ulr.LoginNum = num+1;
                ulr.Remark = remark;

               return ubll.UpdUserLoginRecord(ulr);  

        
            }
           #endregion

        #endregion

      
        /// <summary>
        /// 执行登录
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>ActionResult
        [HttpPost]
        public void ExcLogin()
        {
          
            UserBLL ubll = new UserBLL();

            string tel = Request["telphone"];
            string pwd = Request["password"];

            Tools t = new Tools();
            pwd = t.GetMd5(pwd);

            DT_UserLoginRecord u = ubll.Login(tel, pwd);

            if (u != null)
            {
                Session["user"] = u;
                Session["id"] = u.Id;
                Session["realname"] = u.RealName;
                Session["roleid"] = u.RoleId;
                Session["unitid"] = u.WorkUnitId;
                Session["tel"] = u.Telphone;
                Session["sharestatus"]=u.ShareStatus;
                Session["count"] = u.LoginNum;
       
                //登录IP
                string ip = Request.UserHostAddress.ToString();
                string remark = "正常登录";

                DT_UserLoginRecord ulr = ubll.QueryOneUser(u.Id);
                ulr.LoginTime = DateTime.Now;  //登录时间
                ulr.LoginIp = ip;  //登录IP
                ulr.LoginNum = (u.LoginNum==null?0:u.LoginNum) + 1; //登录次数
                ulr.Remark = remark;
                ubll.UpdUserLoginRecord(ulr);

             // GetLoginRecord(u.Id,u.LoginNum);

                if (u.Status != null)
                {
                    if (u.Status == true)
                    {
                        if (u.RoleId != null)
                        {
                            if (u.IsCadre != null)
                            {
                                if (u.IsCadre == true)
                                {
                                    if (u.RoleId == 1 || u.RoleId == 2)
                                    {
                                        BuildTimeBLL bbll = new BuildTimeBLL();
                                        //填档开始时间
                                        DateTime? starttime = bbll.GetLastTime().BuildStartTime;
                                        //填档结束时间              
                                        DateTime? endtime = bbll.GetLastTime().BuildEndTime;
                                        //这里目前设置的是本地时间
                                        DateTime time = DateTime.Now;
                                        //是科级干部的普通用户或审核用户在填档有效期内时间判断
                                        if (time < starttime)
                                        {
                                            Response.Write("<script type='text/javascript'>alert('很抱歉，填档时间未开始！');location.href='/Home/NoStart';</script>");
                                        }
                                        else if (time > endtime)
                                        {
                                            Response.Write("<script type='text/javascript'>alert('很抱歉，填档时间已结束！');location.href='/Home/HasStop';</script>");
                                        }
                                        else
                                        {
                                            if (u.RoleId == 1) 
                                            {
                                                Response.Write("<script type='text/javascript'>alert('登录成功');location.href='/EnterFile/Index';</script>");
                                            }
                                            else if (u.RoleId == 2)
                                            {
                                                Response.Write("<script type='text/javascript'>alert('登录成功');location.href='/Main/Index';</script>");
                                            }
                                        }
                                    }
                                    else if (u.RoleId == 3 || u.RoleId == 4)
                                    {
                                        Response.Write("<script type='text/javascript'>alert('登录成功');location.href='/Main/Index';</script>");

                                    }
                                    else if ((u.RoleId == 1 || u.RoleId == 2 || u.RoleId == 3 || u.RoleId == 4)&&u.ShareStatus=="是")   
                                    {
                                      ShareBLL sbll = new ShareBLL();
                                      //共享开始时间
                                      DateTime? sharebegintime=sbll.GetLastRecord().ShareBeginTime;
                                      //共享结束时间
                                      DateTime? shareendtime = sbll.GetLastRecord().ShareEndTime;
                                      DateTime? time = DateTime.Now;
                                      if (time<sharebegintime)
                                      {
                                          Response.Write("<script type='text/javascript'>alert('很抱歉，共享时间未开始！');location.href='/Home/NoStart';</script>");
                                      }
                                      else if (time > shareendtime)
                                      {
                                          Response.Write("<script type='text/javascript'>alert('很抱歉，共享时间已结束！');location.href='/Home/HasStop';</script>");
                                      }
                                      else if(time<=shareendtime&&time>=sharebegintime)
                                      {
                                          Response.Write("<script type='text/javascript'>alert('登录成功');location.href='/ForeignShare/Index';</script>");
                                      }
                                        
                                    }
                                    else
                                    {
                                        Response.Write("<script type='text/javascript'>alert('你无权登录该系统！');location.href='/Home/Login';</script>");
                                    }

                                }

                            }
                            else
                            {
                                //科级干部为空或者不是科级干部的用户
                                if (u.RoleId == 1)
                                {
                                    Response.Write("<script type='text/javascript'>alert('你无权登录该系统！');location.href='/Home/Login';</script>");
                                }
                                else if (u.RoleId == 2 || u.RoleId == 3 || u.RoleId == 4)
                                {

                                    Response.Write("<script type='text/javascript'>alert('登录成功');location.href='/Main/Index';</script>");
                                }
                                else if (u.RoleId == 0 && u.IsInner == false&&u.ShareStatus=="是") 
                                {
                                    ShareBLL sbll = new ShareBLL();
                                    //共享开始时间
                                    DateTime? sharebegintime = sbll.GetLastRecord().ShareBeginTime;
                                    //共享结束时间
                                    DateTime? shareendtime = sbll.GetLastRecord().ShareEndTime;
                                    DateTime? time = DateTime.Now;
                                    if (time < sharebegintime)
                                    {
                                        Response.Write("<script type='text/javascript'>alert('很抱歉，共享时间未开始！');location.href='/Home/NoStart';</script>");
                                    }
                                    else if (time > shareendtime)
                                    {
                                        Response.Write("<script type='text/javascript'>alert('很抱歉，共享时间已结束！');location.href='/Home/HasStop';</script>");
                                    }
                                    else if (time <= shareendtime && time >= sharebegintime)
                                    {
                                        Response.Write("<script type='text/javascript'>alert('登录成功');location.href='/ForeignShare/Index';</script>");
                                    }
                                        
                                }
                                else
                                {
                                    Response.Write("<script type='text/javascript'>alert('你无权登录该系统！');location.href='/Home/Login';</script>");
                                }

                            }


                        }
                        else
                        {

                            Response.Write("<script type='text/javascript'>alert('你无权登录该系统！');location.href='/Home/Login';</script>");

                        }
                    }
                    else
                    {
                        //ubll.UpdUserLoginRecord(u.Id, ip, remark2);                        
                        Response.Write("<script type='text/javascript'>alert('该用户账号已被禁用,请联系高级用户！');;location.href='/Home/Login';</script>");//账号被禁用

                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('你无权登录该系统！');location.href='/Home/Login';</script>");

                }

            }
            else
            {

                Response.Write("<script>alert('登录失败！');location.href='/Home/Login';</script>");//登录失败


            }
            Response.End();

        }

     


       

    }
}
