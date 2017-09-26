using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    public class RefuseGiftDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 拒收礼金分表
        /// <summary>
        /// 查询所有拒收礼金
        /// </summary>
        /// <returns></returns>
        public List<DT_RefuseGift> SelectRefuse()
        {
            return ef.Select<DT_RefuseGift>();

        }

        /// <summary>
        /// 添加拒收礼金
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRefuse(DT_RefuseGift u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改拒收礼金
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRefuse(DT_RefuseGift u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除拒收礼金
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRefuse(DT_RefuseGift u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询拒收礼金(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_RefuseGift QueryById(int id)
        {
            return ef.SelectByElement<DT_RefuseGift>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条RewardPunishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelRefuseidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_RefuseGift.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询拒收礼金表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_RefuseGift> SelectRefuseByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_RefuseGift>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询拒收礼金表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_RefuseGift SelectOneRefuseByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_RefuseGift>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 拒收礼金总表
        /// <summary>
        /// 查询所有拒收礼金总
        /// </summary>
        /// <returns></returns>
        public List<DT_RefuseGiftTotal> SelectRefuseTotal()
        {
            return ef.Select<DT_RefuseGiftTotal>();

        }

        /// <summary>
        /// 添加拒收礼金总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRefuseTotal(DT_RefuseGiftTotal u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改拒收礼金总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRefuseTotal(DT_RefuseGiftTotal u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除拒收礼金总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRefuseTotal(DT_RefuseGiftTotal u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询拒收礼金总(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_RefuseGiftTotal QueryTotalById(int id)
        {
            return ef.SelectByElement<DT_RefuseGiftTotal>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条RewardPunishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelRefuseTotalidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_RefuseGiftTotal.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

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
        public int? RefuseTotalIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.RefuseGiftId).FirstOrDefault();

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
        /// 根据UserId查询拒收礼金总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_RefuseGiftTotal> SelectRefuseTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_RefuseGiftTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询拒收礼金总表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_RefuseGiftTotal SelectOneRefuseTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_RefuseGiftTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
