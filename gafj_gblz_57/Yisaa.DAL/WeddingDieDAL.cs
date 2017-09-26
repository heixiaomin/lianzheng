using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    public class WeddingDieDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 近亲婚丧喜庆
        /// <summary>
        /// 查询所有近亲婚丧喜庆
        /// </summary>
        /// <returns></returns>
        public List<DT_WeddingandDie> SelectWedding()
        {
            return ef.Select<DT_WeddingandDie>();

        }

        /// <summary>
        /// 添加近亲婚丧喜庆 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddWedding(DT_WeddingandDie u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改近亲婚丧喜庆
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdWedding(DT_WeddingandDie u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除近亲婚丧喜庆
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelWedding(DT_WeddingandDie u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询近亲婚丧喜庆(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_WeddingandDie QueryById(int id)
        {
            return ef.SelectByElement<DT_WeddingandDie>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Weddingid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelWeddingidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_WeddingandDie.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {
                
                throw;
            }
            
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

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.WeddingandDieId).FirstOrDefault();

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
        /// 根据UserId和年份查询近亲婚丧喜庆 注意年份 a.YearTable==DateTime.Now.Year
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_WeddingandDie> SelectWeddingDieByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_WeddingandDie>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
                return ef.SelectByElement<DT_WeddingandDie>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
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
                return ef.SelectByElement<DT_WeddingandDie>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
