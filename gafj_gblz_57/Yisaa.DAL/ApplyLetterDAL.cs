using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class ApplyLetterDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 函询情况表
        /// <summary>
        /// 查询所有函询情况
        /// </summary>
        /// <returns></returns>
        public List<DT_ApplyByLetter> SelectApplyLetter()
        {
            return ef.Select<DT_ApplyByLetter>();

        }

        /// <summary>
        /// 添加函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddApplyLetter(DT_ApplyByLetter u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdApplyLetter(DT_ApplyByLetter u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除函询情况
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelApplyLetter(DT_ApplyByLetter u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询函询情况(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_ApplyByLetter QueryById(int id)
        {
            return ef.SelectByElement<DT_ApplyByLetter>(a => a.Id == id).FirstOrDefault();
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
                int userid = gbe.DT_ApplyByLetter.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

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

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.ApplyByLetterId).FirstOrDefault();

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
                return ef.SelectByElement<DT_ApplyByLetter>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
        public  DT_ApplyByLetter SelectOneApplyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_ApplyByLetter>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
