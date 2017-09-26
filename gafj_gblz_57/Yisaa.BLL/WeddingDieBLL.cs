using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class WeddingDieBLL
    {

       WeddingDieDAL wdal = new WeddingDieDAL();

        #region 近亲婚丧喜庆
        /// <summary>
        /// 查询所有近亲婚丧喜庆
        /// </summary>
        /// <returns></returns>
        public List<DT_WeddingandDie> SelectWedding()
        {
            return wdal.SelectWedding();

        }

        /// <summary>
        /// 添加近亲婚丧喜庆 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddWedding(DT_WeddingandDie u)
        {
            return wdal.AddWedding(u);
        }

        /// <summary>
        /// 修改近亲婚丧喜庆
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdWedding(DT_WeddingandDie u)
        {
            return wdal.UpdWedding(u);

        }
        /// <summary>
        /// 删除近亲婚丧喜庆
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelWedding(DT_WeddingandDie u)
        {
            return wdal.DelWedding(u);

        }

        /// <summary>
        /// 根据id查询近亲婚丧喜庆(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_WeddingandDie QueryById(int id)
        {
            return wdal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条CrimeId
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelWeddingidByUserid(int uid)
        {
            int userid = wdal.SelWeddingidByUserid(uid);

            return userid;
        }

        /// <summary>
        /// 根据登录id查询Weddingid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? WeddingIdIsNull(int uid)
        {
            try
            {

                int? id = wdal.WeddingIdIsNull(uid);  

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
        /// 根据UserId和年份查询近亲婚丧喜庆  注意年份 a.YearTable==DateTime.Now.Year
        /// </summary>
        /// <param name="u"></param> 
        /// <returns></returns> 
        public List<DT_WeddingandDie> SelectWeddingDieByUid(int uid)
        {
            try
            {
                return wdal.SelectWeddingDieByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 根据userid查询近亲婚丧喜庆(返回一条数据)  
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_WeddingandDie SelectOneWeddingByUid(int uid)
        {
            try
            {
                return wdal.SelectOneWeddingByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        /// <summary>
        /// 根据Id查询婚丧喜庆
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_WeddingandDie> SelectWeddingDieByid(int id)
        {
            try
            {
                return wdal.SelectWeddingDieByid(id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
