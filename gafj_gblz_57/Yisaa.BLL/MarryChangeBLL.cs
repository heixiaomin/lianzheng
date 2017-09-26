using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class MarryChangeBLL
    {
       MarryChangeDAL mdal = new MarryChangeDAL();

        #region 婚姻变化
        /// <summary>
        /// 添加婚姻变化
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddMarry(DT_MarryChange m)
        {
            try
            {
                return mdal.AddMarry(m);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 修改婚姻变化
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateMarry(DT_MarryChange m)
        {
            try
            {
                return mdal.UpdateMarry(m);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据id查询婚姻变化
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_MarryChange SelectMarryByid(int id)
        {
            try
            {
                return mdal.SelectMarryByid(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 根据ids查询婚姻变化
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_MarryChange> SelectMarryByids(int id)
        {
            try
            {
                return mdal.SelectMarryByids(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询婚姻变化所有id
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<int> SelectMarryAllIds()
        {
            try
            {
                return mdal.SelectMarryAllIds();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询婚姻变化
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_MarryChange> SelectMarry()
        {
            try
            {
                return mdal.SelectMarry();
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 根据登录id查询最近一条MarryId
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelMarriddByUserid(int uid)
        {

            return mdal.SelMarriddByUserid(uid) ;
        }
        #endregion

        /// <summary>
        /// 根据登录id查询MarryChangeId是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? MarryidIsNull(int uid)
        {
            try
            {

                int? id = mdal.MarryidIsNull(uid);

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
        /// 根据UserId查询婚姻变化表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_MarryChange> SelectMarryByUid(int uid)
        {
            try
            {
                return mdal.SelectMarryByUid(uid);
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
        public DT_MarryChange SelMarryByUid(int uid)
        {
            return mdal.SelMarryByUid(uid);
        }

   }
}
