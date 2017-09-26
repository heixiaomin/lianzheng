using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class ResponsibilityBLL
    {
       ResponsibilityDAL rsdal = new ResponsibilityDAL();

        #region 违规违纪责任追究
        /// <summary>
        /// 查询所有责任追究
        /// </summary>
        /// <returns></returns>
        public List<DT_Responsibility> SelectRespons()
        {
            return rsdal.SelectRespons();

        }

        /// <summary>
        /// 添加责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRespons(DT_Responsibility u)
        {
            return rsdal.AddRespons(u);
        }

        /// <summary>
        /// 修改责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRespons(DT_Responsibility u)
        {
            return rsdal.UpdRespons(u);

        }
        /// <summary>
        /// 删除责任追究
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRespons(DT_Responsibility u)
        {
            return rsdal.DelRespons(u);

        }

        /// <summary>
        /// 根据id查询责任追究(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Responsibility QueryById(int id)
        {
            return rsdal.QueryById(id);
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
                int userid = rsdal.SelResponsidByUserid(uid);

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

                int? id = rsdal.ResponsIdIsNull(uid);

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
                return rsdal.SelectResponsByUid(uid);
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
                return rsdal.SelectOneResponsByUid(uid);
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
                return rsdal.SelectResponsByid(id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
