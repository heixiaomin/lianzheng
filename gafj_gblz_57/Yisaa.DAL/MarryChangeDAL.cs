using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 婚姻变化
    /// </summary>
   public class MarryChangeDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

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
                return ef.Add(m);
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
                return ef.Update(m);
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
                return ef.SelectByElement<DT_MarryChange>(a => a.Id == id).FirstOrDefault();
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
        public List<DT_MarryChange>  SelectMarryByids(int id)
        {
            try
            {
                return ef.SelectByElement<DT_MarryChange>(a => a.Id == id).ToList();
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
                return ef.Select<DT_MarryChange>().Select(a => a.Id).ToList();
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
                return ef.Select<DT_MarryChange>().ToList();
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
            int userid = gbe.DT_MarryChange.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

            return userid;
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

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.MarryChangeId).FirstOrDefault();

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
                return ef.SelectByElement<DT_MarryChange>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
            return ef.SelectByElement<DT_MarryChange>(a => a.UserId == uid&&a.YearTable==DateTime.Now.Year).FirstOrDefault();
        }

    }
}
