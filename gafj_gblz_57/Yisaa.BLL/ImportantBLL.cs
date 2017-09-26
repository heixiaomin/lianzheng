using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class ImportantBLL
    {
       ImportantDAL imdal = new ImportantDAL();

        #region 重大事项
        /// <summary>
        /// 查询所有重大事项
        /// </summary>
        /// <returns></returns>
        public List<DT_Important> SelectImportant()
        {
            return imdal.SelectImportant();

        }

        /// <summary>
        /// 添加重大事项 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddImportant(DT_Important u)
        {
            return imdal.AddImportant(u);
        }

        /// <summary>
        /// 修改重大事项
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdImportant(DT_Important u)
        {
            return imdal.UpdImportant(u);

        }
        /// <summary>
        /// 删除重大事项
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelImportant(DT_Important u)
        {
            return imdal.DelImportant(u);

        }

        /// <summary>
        /// 根据id查询重大事项(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Important QueryById(int id)
        {
            return imdal.QueryById(id);
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
                int userid = imdal.SelImportantidByUserid(uid);

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

                int? id = imdal.ImportantIdIsNull(uid);

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
                return imdal.SelectImportantByUid(uid);
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
        public DT_Important SelectOneImportantByUid(int uid)
        {
            try
            {
                return imdal.SelectOneImportantByUid(uid);
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
                return imdal.SelectImportantByid(id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
