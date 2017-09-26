using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class RefuseGiftBLL
    {
       RefuseGiftDAL rgdal = new RefuseGiftDAL();

        #region 拒收礼金分表
        /// <summary>
        /// 查询所有拒收礼金
        /// </summary>
        /// <returns></returns>
        public List<DT_RefuseGift> SelectRefuse()
        {
            return rgdal.SelectRefuse();

        }

        /// <summary>
        /// 添加拒收礼金
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRefuse(DT_RefuseGift u)
        {
            return rgdal.AddRefuse(u);
        }

        /// <summary>
        /// 修改拒收礼金
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRefuse(DT_RefuseGift u)
        {
            return rgdal.UpdRefuse(u);

        }
        /// <summary>
        /// 删除拒收礼金
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRefuse(DT_RefuseGift u)
        {
            return rgdal.DelRefuse(u);

        }

        /// <summary>
        /// 根据id查询拒收礼金(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_RefuseGift QueryById(int id)
        {
            return rgdal.QueryById(id);
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
                int userid = rgdal.SelRefuseidByUserid(uid);

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
                return rgdal.SelectRefuseByUid(uid);
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
                return rgdal.SelectOneRefuseByUid(uid);
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
            return rgdal.SelectRefuseTotal();

        }

        /// <summary>
        /// 添加拒收礼金总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRefuseTotal(DT_RefuseGiftTotal u)
        {
            return rgdal.AddRefuseTotal(u);
        }

        /// <summary>
        /// 修改拒收礼金总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRefuseTotal(DT_RefuseGiftTotal u)
        {
            return rgdal.UpdRefuseTotal(u);

        }
        /// <summary>
        /// 删除拒收礼金总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRefuseTotal(DT_RefuseGiftTotal u)
        {
            return rgdal.DelRefuseTotal(u);

        }

        /// <summary>
        /// 根据id查询拒收礼金总(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_RefuseGiftTotal QueryTotalById(int id)
        {
            return rgdal.QueryTotalById(id);
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
                int userid = rgdal.SelRefuseTotalidByUserid(uid);

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

                int? id = rgdal.RefuseTotalIdIsNull(uid);

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
                return rgdal.SelectRefuseTotalByUid(uid);
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
                return rgdal.SelectOneRefuseTotalByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
