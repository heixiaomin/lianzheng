using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class IncorruptTalkBLL
    {
       IncorruptTalkDAL itdal = new IncorruptTalkDAL();

        #region  廉政谈话情况
        /// <summary>
        /// 查询所有廉政谈话
        /// </summary>
        /// <returns></returns>
        public List<DT_IncorruptTalk> SelectIncorrupt()
        {
            return itdal.SelectIncorrupt();

        }

        /// <summary>
        /// 添加廉政谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddIncorrupt(DT_IncorruptTalk u)
        {
            return itdal.AddIncorrupt(u);
        }

        /// <summary>
        /// 修改廉政谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdIncorrupt(DT_IncorruptTalk u)
        {
            return itdal.UpdIncorrupt(u);

        }
        /// <summary>
        /// 删除廉政谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelIncorrupt(DT_IncorruptTalk u)
        {
            return itdal.DelIncorrupt(u);

        }

        /// <summary>
        /// 根据id查询廉政谈话(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_IncorruptTalk QueryById(int id)
        {
            return itdal.QueryById(id);
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
                int userid = itdal.SelIncorruptidByUserid(uid);

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

                int? id = itdal.IncorruptIdIsNull(uid);

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
                return itdal.SelectIncorruptByUid(uid);
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
                return itdal.SelectOneIncorruptByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
