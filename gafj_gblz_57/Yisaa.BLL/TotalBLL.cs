using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
    public class TotalBLL
    {      
        TotalDAL tdal = new TotalDAL();

        #region 审核用户审核的四种状态
        /// <summary>
        /// 查询ChkStutus为“待审核”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelWaitStutus()
        {

            return tdal.SelWaitStutus();
        }

        /// <summary>
        /// 查询ChkStutus为“已退回”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelBackedStutus()
        {

            return tdal.SelBackedStutus();
        }

        /// <summary>
        /// 查询ChkStutus为“已提交”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelSubmitStutus()
        {

            return tdal.SelSubmitStutus();
        }

        /// <summary>
        /// 查询ChkStutus为“被退回”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelBeBackedStutus()
        {

            return tdal.SelBeBackedStutus();
        }
        #endregion

        /// <summary>
        /// 查询FileStutus为“已归档”的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelTotalsByFiled()
        {

            return tdal.SelTotalsByFiled();
        }

        /// <summary>
        /// 查询ChkStutus不为空的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelTotalsByChkStutus()
        {

            return tdal.SelTotalsByChkStutus();
        }

        /// <summary>
        /// 查询FileStutus不为空的总表 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Total> SelTotalsByFileStutus()
        {

            return tdal.SelTotalsByFileStutus();
        }

        /// <summary>
        /// 根据id查询总表(一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Total QueryTotalById(int id)
        {
            
            return tdal.QueryTotalById(id);
        }
 

        /// <summary>
        /// 根据userid查询总表(一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Total SelTotalById(int uid)
        {
            return tdal.SelTotalById(uid);
        }

        /// <summary>
        /// 根据总表id查询用户登录id
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int? SelUidByTid(int tid)
        {
            return tdal.SelUidByTid(tid);

        }

        /// <summary>
        /// 添加总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddTotal(DT_Total t)
        {
            return tdal.AddTotal(t);
        }

        /// <summary>
        /// 修改总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdTotal(DT_Total t)
        {
            return tdal.UpdTotal(t);
        }

        /// <summary>
        /// 查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<DT_Total> SelectTotal()
        {
            return tdal.SelectTotal();
        }

        /// <summary>
        /// 根据id查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DT_Total SelectOneTotal(int id)
        {
            return tdal.SelectOneTotal(id);
        }

        /// <summary>
        /// 查询总表所有为true的状态
        /// </summary>
        /// <returns></returns>
        public List<string> SelAllStatus()
        {
            return tdal.SelAllStatus();

        }

        /// <summary>
        /// 根据状态查询userid
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>bool status
        public int? SelUidByStatus()
        {
            return tdal.SelUidByStatus();


        }

        /// <summary>
        /// 根据总表的userid查询用户(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_UserLoginRecord QueryByUid(int uid)
        {
            return tdal.QueryByUid(uid);
        }

        public List<DT_UserLoginRecord> Query()
        {


            return tdal.Query();

        }


        /// <summary>
        /// 根据登录id和年份查询出年份
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int? SelectYear(int uid)
        {
            return tdal.SelectYear(uid);

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
                return tdal.IsExists(uid);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
