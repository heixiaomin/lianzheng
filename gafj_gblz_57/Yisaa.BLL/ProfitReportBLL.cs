using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class ProfitReportBLL
    {
       ProfitReportDAL pdal = new ProfitReportDAL();

        #region 营利管理
        /// <summary>
        /// 查询所有营利
        /// </summary>
        /// <returns></returns>
        public List<DT_ProfitReport> SelectProfit()
        {
            return pdal.SelectProfit();

        }

        /// <summary>
        /// 添加营利
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddProfit(DT_ProfitReport u)
        {
            return pdal.AddProfit(u);
        }

        /// <summary>
        /// 修改营利
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdProfit(DT_ProfitReport u)
        {
            return pdal.UpdProfit(u);

        }
        /// <summary>
        /// 删除营利
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelProfit(DT_ProfitReport u)
        {
            return pdal.DelProfit(u);

        }

        /// <summary>
        /// 根据营利id查询营利(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_ProfitReport QueryById(int id)
        {
            return pdal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条Profitid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelProidByUid(int uid)
        {
            return pdal.SelProidByUid(uid);
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
                return pdal.SelectProfitReportByid(id);
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

                int? id = pdal.ProfitidIsNull(uid);

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
                return pdal.SelectProfitByid(uid);
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
            return pdal.SelProByUid(uid);
        }


    }
}
