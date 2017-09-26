using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class AdmonishTalkBLL
    {
       AdmonishTalkDAL atdal = new AdmonishTalkDAL();

        #region 诫勉谈话
        /// <summary>
        /// 查询所有诫勉谈话
        /// </summary>
        /// <returns></returns>
        public List<DT_AdmonishingTalk> SelectAdmonish()
        {
            return atdal.SelectAdmonish();

        }

        /// <summary>
        /// 添加诫勉谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddAdmonish(DT_AdmonishingTalk u)
        {
            return atdal.AddAdmonish(u);
        }

        /// <summary>
        /// 修改诫勉谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdAdmonish(DT_AdmonishingTalk u)
        {
            return atdal.UpdAdmonish(u);

        }
        /// <summary>
        /// 删除诫勉谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelAdmonish(DT_AdmonishingTalk u)
        {
            return atdal.DelAdmonish(u);

        }

        /// <summary>
        /// 根据id查询诫勉谈话(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_AdmonishingTalk QueryById(int id)
        {
            return atdal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条Admonishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelAdmonishidByUserid(int uid)
        {
            try
            {
                int userid = atdal.SelAdmonishidByUserid(uid);

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// 根据登录id查询Admonishid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? AdmonishIdIsNull(int uid)
        {
            try
            {

                int? id = atdal.AdmonishIdIsNull(uid);

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
        /// 根据UserId查询诫勉谈话表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_AdmonishingTalk> SelectAdmonishByUid(int uid)
        {
            try
            {
                return atdal.SelectAdmonishByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据UserId查询诫勉谈话表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_AdmonishingTalk SelectOneAdmonishByUid(int uid)
        {
            try
            {
                return atdal.SelectOneAdmonishByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
