using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class IncorruptTalkDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region  廉政谈话情况 
        /// <summary>
        /// 查询所有廉政谈话
        /// </summary>
        /// <returns></returns>
        public List<DT_IncorruptTalk> SelectIncorrupt()
        {
            return ef.Select<DT_IncorruptTalk>();

        }

        /// <summary>
        /// 添加廉政谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddIncorrupt(DT_IncorruptTalk u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改廉政谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdIncorrupt(DT_IncorruptTalk u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除廉政谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelIncorrupt(DT_IncorruptTalk u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询廉政谈话(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_IncorruptTalk QueryById(int id)
        {
            return ef.SelectByElement<DT_IncorruptTalk>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Incorruptid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelIncorruptidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_IncorruptTalk.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询Incorruptid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? IncorruptIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.IncorruptTalkId).FirstOrDefault();

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
        /// 根据UserId查询廉政谈话表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_IncorruptTalk> SelectIncorruptByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_IncorruptTalk>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据UserId查询廉政谈话表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_IncorruptTalk SelectOneIncorruptByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_IncorruptTalk>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
