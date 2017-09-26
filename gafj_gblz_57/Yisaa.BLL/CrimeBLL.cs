using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class CrimeBLL
    {

       CrimeDAL cdal = new CrimeDAL();

        #region 涉嫌犯罪情况
        /// <summary>
        /// 查询所有犯罪
        /// </summary>
        /// <returns></returns>
        public List<DT_CrimeReport> SelectCrime()
        {
            return cdal.SelectCrime();

        }

        /// <summary>
        /// 添加犯罪
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddCrime(DT_CrimeReport u)
        {
            return cdal.AddCrime(u);
        }

        /// <summary>
        /// 修改犯罪
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdCrime(DT_CrimeReport u)
        {
            return cdal.UpdCrime(u);

        }
        /// <summary>
        /// 删除犯罪
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelCrime(DT_CrimeReport u)
        {
            return cdal.DelCrime(u);
        }

        /// <summary>
        /// 根据犯罪id查询犯罪(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_CrimeReport QueryById(int id)
        {
            return cdal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条CrimeId
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelCrimeiddByUserid(int uid)
        {
            return cdal.SelCrimeiddByUserid(uid);
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
                return cdal.SelectCrimeByid(id);
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

                int? id = cdal.CrimeIdIsNull(uid);

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
                return cdal.SelectCrimeByUid(uid);
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
            return cdal.SelCrimeByUid(uid);
        }

   }
}
