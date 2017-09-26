using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class ApplyLetterBLL
    {
       ApplyLetterDAL aldal = new ApplyLetterDAL();

        #region 函询情况表
        /// <summary>
        /// 查询所有函询情况
        /// </summary>
        /// <returns></returns>
        public List<DT_ApplyByLetter> SelectApplyLetter()
        {
            return aldal.SelectApplyLetter();

        }

        /// <summary>
        /// 添加函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddApplyLetter(DT_ApplyByLetter u)
        {
            return aldal.AddApplyLetter(u);
        }

        /// <summary>
        /// 修改函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdApplyLetter(DT_ApplyByLetter u)
        {
            return aldal.UpdApplyLetter(u);

        }
        /// <summary>
        /// 删除函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelApplyLetter(DT_ApplyByLetter u)
        {
            return aldal.DelApplyLetter(u);

        }

        /// <summary>
        /// 根据id查询函询情况(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_ApplyByLetter QueryById(int id)
        {
            return aldal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条ApplyLetterid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelApplyLetteridByUserid(int uid)
        {
            try
            {
                int userid = aldal.SelApplyLetteridByUserid(uid);

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询ApplyLetterid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? ApplyLetterIdIsNull(int uid)
        {
            try
            {

                int? id = aldal.ApplyLetterIdIsNull(uid);

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
        /// 根据UserId查询函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_ApplyByLetter> SelectApplyByUid(int uid)
        {
            try
            {
                return aldal.SelectApplyByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据UserId查询函询情况（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_ApplyByLetter SelectOneApplyByUid(int uid)
        {
            try
            {
                return aldal.SelectOneApplyByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
