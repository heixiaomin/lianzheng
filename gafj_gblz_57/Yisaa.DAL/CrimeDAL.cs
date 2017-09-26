using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 干部配偶、子女涉嫌犯罪情况报告表
    /// </summary>
    public class CrimeDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 涉嫌犯罪情况
        /// <summary>
        /// 查询所有犯罪
        /// </summary>
        /// <returns></returns>
        public List<DT_CrimeReport> SelectCrime()
        {
            return ef.Select<DT_CrimeReport>();

        }

        /// <summary>
        /// 添加犯罪
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddCrime(DT_CrimeReport u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改犯罪
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdCrime(DT_CrimeReport u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除犯罪
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelCrime(DT_CrimeReport u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据犯罪id查询犯罪(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_CrimeReport QueryById(int id)
        {
            return ef.SelectByElement<DT_CrimeReport>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条CrimeId
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelCrimeiddByUserid(int uid)
        {
            int userid = gbe.DT_CrimeReport.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

            return userid;
        }
        #endregion
        
        /// <summary>
        /// 根据Id查询干部配偶、子女涉嫌犯罪情况报告
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_CrimeReport> SelectCrimeByid(int id)
        {
            try
            {
                return ef.SelectByElement<DT_CrimeReport>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// 根据登录id查询CrimeId是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? CrimeIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.CrimeId).FirstOrDefault();

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
        /// 根据UserId查询干部配偶、子女涉嫌犯罪情况报告
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_CrimeReport> SelectCrimeByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_CrimeReport>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

      
        /// <summary>
        /// 根据userid查询犯罪(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_CrimeReport SelCrimeByUid(int uid)
        {
            return ef.SelectByElement<DT_CrimeReport>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
        }

      
    }
}
