using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class ImportantDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 重大事项
        /// <summary>
        /// 查询所有重大事项
        /// </summary>
        /// <returns></returns>
        public List<DT_Important> SelectImportant()
        {
            return ef.Select<DT_Important>();

        }

        /// <summary>
        /// 添加重大事项 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddImportant(DT_Important u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改重大事项
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdImportant(DT_Important u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除重大事项
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelImportant(DT_Important u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询重大事项(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Important QueryById(int id)
        {
            return ef.SelectByElement<DT_Important>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Importantid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelImportantidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_Important.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询Importantid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? ImportantIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.ImportantId).FirstOrDefault();

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
        /// 根据UserId查询重大事项表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Important> SelectImportantByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Important>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据UserId查询重大事项表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public  DT_Important SelectOneImportantByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Important>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 根据Id查询重大事项
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Important> SelectImportantByid(int id)
        {
            try
            {
                return ef.SelectByElement<DT_Important>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
