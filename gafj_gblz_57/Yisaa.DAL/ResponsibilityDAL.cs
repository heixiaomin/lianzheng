using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class ResponsibilityDAL
    {

        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 违规违纪责任追究
        /// <summary>
        /// 查询所有责任追究
        /// </summary>
        /// <returns></returns>
        public List<DT_Responsibility> SelectRespons()
        {
            return ef.Select<DT_Responsibility>();

        }

        /// <summary>
        /// 添加责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRespons(DT_Responsibility u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRespons(DT_Responsibility u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRespons(DT_Responsibility u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询责任追究(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Responsibility QueryById(int id)
        {
            return ef.SelectByElement<DT_Responsibility>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Responsid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelResponsidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_Responsibility.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询Responsid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? ResponsIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.ResponsibilityId).FirstOrDefault();

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
        /// 根据UserId查询责任追究表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Responsibility> SelectResponsByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Responsibility>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据UserId查询责任追究表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Responsibility SelectOneResponsByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Responsibility>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        /// <summary>
        /// 根据Id查询责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Responsibility> SelectResponsByid(int id)
        {
            try
            {
                return ef.SelectByElement<DT_Responsibility>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
