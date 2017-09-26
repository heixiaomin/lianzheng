using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 参与营利及兼职持股情况报告表
    /// </summary>
   public class ProfitReportDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 营利管理
        /// <summary>
        /// 查询所有营利
        /// </summary>
        /// <returns></returns>
        public List<DT_ProfitReport> SelectProfit()
        {
            return ef.Select<DT_ProfitReport>();

        }


        /// <summary>
        /// 添加营利
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddProfit(DT_ProfitReport u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改营利
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdProfit(DT_ProfitReport u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除营利
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelProfit(DT_ProfitReport u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据营利id查询营利(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_ProfitReport QueryById(int id)
        {
            return ef.SelectByElement<DT_ProfitReport>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Profitid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelProidByUid(int uid)
        {
            int userid = gbe.DT_ProfitReport.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

            return userid;
        }
       

        #endregion

        /// <summary>
        /// 根据Id查询营利及兼职持股情况报告表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_ProfitReport> SelectProfitReportByid(int id)
        {
            try
            {
                return ef.SelectByElement<DT_ProfitReport>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }



        /// <summary>
        /// 根据登录id查询ProfitId是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? ProfitidIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.ProfitId).FirstOrDefault();

                if (id == null)
                {
                    return null;
                }
                else
                {
                    return id;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 根据UserId查询兼职持股情况报告表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_ProfitReport> SelectProfitByid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_ProfitReport>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 根据userid查询营利(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_ProfitReport SelProByUid(int uid)
        {
            return ef.SelectByElement<DT_ProfitReport>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
        }

    }
}
