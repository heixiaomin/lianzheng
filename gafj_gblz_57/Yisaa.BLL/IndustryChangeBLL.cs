using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class IndustryChangeBLL
    {
       IndustryChangeDAL icdal = new IndustryChangeDAL();

        #region 从业变更
        /// <summary>
        /// 查询所有从业变更
        /// </summary>
        /// <returns></returns>
        public List<DT_IndustryChanges> SelectIndustry()
        {
            return icdal.SelectIndustry();

        }

        /// <summary>
        /// 添加从业变更 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddIndustry(DT_IndustryChanges u)
        {
            return icdal.AddIndustry(u);
        }

        /// <summary>
        /// 修改从业变更
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdIndustry(DT_IndustryChanges u)
        {
            return icdal.UpdIndustry(u);

        }
        /// <summary>
        /// 删除从业变更
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelIndustry(DT_IndustryChanges u)
        {
            return icdal.DelIndustry(u);

        }

        /// <summary>
        /// 根据id查询从业变更(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_IndustryChanges QueryById(int id)
        {
            return icdal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条Industryid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelIndustryidByUserid(int uid)
        {
            try
            {
                int userid = icdal.SelIndustryidByUserid(uid);

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询Industryid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? IndustryIdIsNull(int uid)
        {
            try
            {

                int? id = icdal.IndustryIdIsNull(uid);

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
        /// 根据UserId查询从业变更表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_IndustryChanges> SelectIndustryByUid(int uid)
        {
            try
            {
                return icdal.SelectIndustryByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询从业变更表(返回一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_IndustryChanges SelectOneIndustryByUid(int uid)
        {
            try
            {
                return icdal.SelectOneIndustryByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        /// <summary>
        /// 根据Id查询从业变更
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_IndustryChanges> SelectIndustryChangesByid(int id)
        {
            try
            {
                return icdal.SelectIndustryChangesByid(id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
