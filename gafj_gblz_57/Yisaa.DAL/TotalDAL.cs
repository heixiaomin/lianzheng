using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    public class TotalDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 审核用户审核的四种状态       
        /// <summary>
        /// 查询ChkStutus为“待审核”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelWaitStutus()
        {

            return ef.SelectByElement<DT_Total>(a => a.CheckStatus == "待审核");
        }

        /// <summary>
        /// 查询ChkStutus为“已退回”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelBackedStutus()
        {

            return ef.SelectByElement<DT_Total>(a => a.CheckStatus == "已退回");
        }

        /// <summary>
        /// 查询ChkStutus为“已提交”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelSubmitStutus()
        {

            return ef.SelectByElement<DT_Total>(a => a.CheckStatus == "已提交");
        }

        /// <summary>
        /// 查询ChkStutus为“被退回”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelBeBackedStutus()
        {

            return ef.SelectByElement<DT_Total>(a => a.CheckStatus == "被退回");
        }
        #endregion

        /// <summary>
        /// 查询FileStutus为“已归档”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelTotalsByFiled()
        {

            return ef.SelectByElement<DT_Total>(a => a.FileStatus == "已归档" && a.YearTable == DateTime.Now.Year);
        }


        /// <summary>
        /// 查询ChkStutus不为空的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelTotalsByChkStutus()
        {

            return ef.SelectByElement<DT_Total>(a => (a.CheckStatus != "" || a.CheckStatus != null) && a.YearTable == DateTime.Now.Year);
        }

        /// <summary>
        /// 查询FileStutus不为空的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelTotalsByFileStutus()
        {

            return ef.SelectByElement<DT_Total>(a => (a.FileStatus != "" || a.FileStatus != null) && a.YearTable == DateTime.Now.Year);
        }



        /// <summary>
        /// 根据id查询总表(一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Total QueryTotalById(int id)
        {

            return ef.SelectByElement<DT_Total>(a => a.Id == id && a.YearTable == DateTime.Now.Year).FirstOrDefault();
        }


        /// <summary>
        /// 根据userid查询总表(一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Total SelTotalById(int uid)
        {
                           
            return ef.SelectByElement<DT_Total>(a => a.UserId == uid&&a.YearTable==DateTime.Now.Year).FirstOrDefault();
        }

        /// <summary>
        /// 根据总表id查询用户登录id
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int? SelUidByTid(int tid)
        {
            try
            {
                return gbe.DT_Total.Where(a => a.Id == tid && a.YearTable == DateTime.Now.Year).Select(a => a.UserId).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }
        
        /// <summary>
        /// 添加总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddTotal(DT_Total t)
        {
            return ef.Add(t);
        }

        /// <summary>
        /// 修改总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdTotal(DT_Total t)
        {
            return ef.Update(t);
        }

        /// <summary>
        /// 查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<DT_Total> SelectTotal()
        {
            return ef.Select<DT_Total>();
        }

        /// <summary>
        /// 根据UserInfoId查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DT_Total SelectOneTotal(int id)
        {
            return ef.SelectByElement<DT_Total>(a => a.UserInfoId == id && a.YearTable == DateTime.Now.Year).FirstOrDefault();
        }

        /// <summary>
        /// 查询总表所有为true的状态
        /// </summary>
        /// <returns></returns>
        public List<string> SelAllStatus()
        {
            try
            {
                return gbe.DT_Total.Select(a => a.Status).ToList(); 
            }
            catch (Exception)
            {
                
                throw;
            }
           
        
        }

        /// <summary>
        /// 根据userinfoid查询总表所有审核状态
        /// </summary>
        /// <returns></returns>
        public string SelUserStatus(int id)
        {
            try
            {
                return gbe.DT_Total.Where(a => a.UserId == id && a.YearTable == DateTime.Now.Year).Select(a => a.Status).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
           

        }

        /// <summary>
        /// 根据状态查询userid
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>bool status
        public int? SelUidByStatus()
        {
            try
            {
                return gbe.DT_Total.Where(a => a.Status == "已提交" && a.YearTable == DateTime.Now.Year).Select(a => a.UserId).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
            
                
        }


        /// <summary>
        /// 根据总表的userid查询用户(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_UserLoginRecord QueryByUid(int uid)
        {
            try
            {
                return gbe.DT_UserLoginRecord.Where(a=>a.Id==uid).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
            
                
           //ef.SelectByElement<DT_UserLoginRecord>(a => a.Id == uid).FirstOrDefault();
        }
            //int uid
        public List<DT_UserLoginRecord> Query()
        {
            try
            {
                int? userid = gbe.DT_Total.Where(a => a.Status == "未提交" && a.YearTable == DateTime.Now.Year).Select(a => a.UserId).FirstOrDefault();

                List<DT_UserLoginRecord> ulist = gbe.DT_UserLoginRecord.Where(a => a.Id == userid).ToList();

                return ulist;
            }
            catch (Exception)
            {
                
                throw;
            }
         
         
        }


        /// <summary>
        /// 根据登录id和年份查询出年份
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int? SelectYear(int uid)
        {
            try
            {
                return gbe.DT_Total.Where(a=>a.UserId==uid&&a.YearTable==DateTime.Now.Year).Select(a=>a.YearTable).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        
        }

        /// <summary>
        /// 判断总表里是否存在该用户userid
        /// </summary>解决录入时必须先录入第一张表
        /// <param name="uid"></param>
        /// <returns></returns>
        public int? IsExists(int uid)
        {
            try
            {
                return gbe.DT_Total.Where(a=>a.UserId==uid&&a.YearTable==DateTime.Now.Year).Count();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
