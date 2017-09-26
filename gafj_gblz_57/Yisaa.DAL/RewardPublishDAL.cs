using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class RewardPublishDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 奖惩情况总表
        /// <summary>
        /// 查询所有奖惩情况
        /// </summary>
        /// <returns></returns>
        public List<DT_RewardPunishTotal> SelectRPTotal()
        {
            return ef.Select<DT_RewardPunishTotal>();

        }

        /// <summary>
        /// 添加奖惩情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRPTotal(DT_RewardPunishTotal u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改奖惩情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRPTotal(DT_RewardPunishTotal u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除奖惩情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRPTotal(DT_RewardPunishTotal u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询奖惩情况(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_RewardPunishTotal QueryById(int id)
        {
            return ef.SelectByElement<DT_RewardPunishTotal>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条RewardPunishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelRPTotalidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_RewardPunishTotal.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询RewardPunishid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? RPTotalIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.RewardId).FirstOrDefault();

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
        /// 根据UserId查询奖惩情况表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_RewardPunishTotal> SelectRPTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_RewardPunishTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询奖惩情况表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_RewardPunishTotal SelectOneRPTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_RewardPunishTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 获奖
        /// <summary>
        /// 查询所有获奖
        /// </summary>
        /// <returns></returns>
        public List<DT_Reward> SelectReward(int uid)
        {
            return ef.SelectByElement<DT_Reward>(a=>a.UserId==uid&&a.YearTable==DateTime.Now.Year);

        }

        /// <summary>
        /// 添加获奖
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddReward(DT_Reward u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改获奖
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdReward(DT_Reward u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除获奖
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelReward(DT_Reward u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询获奖(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Reward QueryRewardById(int id)
        {
            return ef.SelectByElement<DT_Reward>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Rewardid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelRewardidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_Reward.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询获奖表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Reward> SelectRewardByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Reward>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询获奖表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Reward SelectOneRewardByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Reward>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
       
        #region 惩罚
        /// <summary>
        /// 查询所有惩罚
        /// </summary>
        /// <returns></returns>
        public List<DT_Punish> SelectPunish(int uid)
        {
            return ef.SelectByElement<DT_Punish>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year);

        }

        /// <summary>
        /// 添加惩罚
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddPunish(DT_Punish u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改惩罚
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdPunish(DT_Punish u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除惩罚
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelPunish(DT_Punish u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询惩罚(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Punish QueryPunishById(int id)
        {
            return ef.SelectByElement<DT_Punish>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Punishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelPunishidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_Punish.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询惩罚表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Punish> SelectPunishByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Punish>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询惩罚表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Punish SelectOnePunishByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_Punish>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
