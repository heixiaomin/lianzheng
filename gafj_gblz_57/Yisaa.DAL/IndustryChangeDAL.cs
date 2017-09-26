using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class IndustryChangeDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 从业变更
        /// <summary>
        /// 查询所有从业变更
        /// </summary>
        /// <returns></returns>
        public List<DT_IndustryChanges> SelectIndustry()
        {
            return ef.Select<DT_IndustryChanges>();

        }

        /// <summary>
        /// 添加从业变更 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddIndustry(DT_IndustryChanges u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改从业变更
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdIndustry(DT_IndustryChanges u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除从业变更
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelIndustry(DT_IndustryChanges u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询从业变更(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_IndustryChanges QueryById(int id)
        {
            return ef.SelectByElement<DT_IndustryChanges>(a => a.Id == id).FirstOrDefault();
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
                int userid = gbe.DT_IndustryChanges.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

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

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.IndustryChangesId).FirstOrDefault();

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
                return ef.SelectByElement<DT_IndustryChanges>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
                return ef.SelectByElement<DT_IndustryChanges>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
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
                return ef.SelectByElement<DT_IndustryChanges>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
