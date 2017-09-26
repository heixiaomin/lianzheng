using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class AdmonishTalkDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 诫勉谈话
        /// <summary>
        /// 查询所有诫勉谈话
        /// </summary>
        /// <returns></returns>
        public List<DT_AdmonishingTalk> SelectAdmonish()
        {
            return ef.Select<DT_AdmonishingTalk>();

        }

        /// <summary>
        /// 添加诫勉谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddAdmonish(DT_AdmonishingTalk u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改诫勉谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdAdmonish(DT_AdmonishingTalk u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除诫勉谈话
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelAdmonish(DT_AdmonishingTalk u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询诫勉谈话(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_AdmonishingTalk QueryById(int id)
        {
            return ef.SelectByElement<DT_AdmonishingTalk>(a => a.Id == id).FirstOrDefault();
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
                int userid = gbe.DT_AdmonishingTalk.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

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

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.AdmonishingTalkId).FirstOrDefault();

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
                return ef.SelectByElement<DT_AdmonishingTalk>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
        public  DT_AdmonishingTalk SelectOneAdmonishByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_AdmonishingTalk>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
