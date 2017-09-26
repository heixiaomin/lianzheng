using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 出国
    /// </summary>
   public class AbroadDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 出国办企分表
        /// <summary>
        /// 查询所有办企
        /// </summary>
        /// <returns></returns>
        public List<DT_GoAbroadCompany> SelectCompany()
        {
            return ef.Select<DT_GoAbroadCompany>();

        }

        /// <summary>
        /// 添加办企
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddCompany(DT_GoAbroadCompany u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改办企
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdCompany(DT_GoAbroadCompany u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除办企
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelCompany(DT_GoAbroadCompany u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询办企(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadCompany QueryCompanyById(int id)
        {
            return ef.SelectByElement<DT_GoAbroadCompany>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Companyid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelCompanyidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_GoAbroadCompany.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询办企表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_GoAbroadCompany> SelectCompanyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadCompany>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询办企表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_GoAbroadCompany SelectOneCompanyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadCompany>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 出国留学分表
        /// <summary>
        /// 查询所有留学
        /// </summary>
        /// <returns></returns>
        public List<DT_GoAbroadStudy> SelectStudy()
        {
            return ef.Select<DT_GoAbroadStudy>();

        }

        /// <summary>
        /// 添加留学
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddStudy(DT_GoAbroadStudy u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改留学
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdStudy(DT_GoAbroadStudy u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除留学
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelStudy(DT_GoAbroadStudy u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询留学(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadStudy QueryStudyById(int id)
        {
            return ef.SelectByElement<DT_GoAbroadStudy>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Studyid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelStudyidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_GoAbroadStudy.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询留学表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_GoAbroadStudy> SelectStudyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadStudy>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询留学表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_GoAbroadStudy SelectOneStudyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadStudy>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 出国定居分表
        /// <summary>
        /// 查询所有定居
        /// </summary>
        /// <returns></returns>
        public List<DT_GoAbroadSettler> SelectSettle()
        {
            return ef.Select<DT_GoAbroadSettler>();

        }

        /// <summary>
        /// 添加定居
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddSettle(DT_GoAbroadSettler u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改定居
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdSettle(DT_GoAbroadSettler u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除定居
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelSettle(DT_GoAbroadSettler u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询定居(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadSettler QuerySettleById(int id)
        {
            return ef.SelectByElement<DT_GoAbroadSettler>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Settleid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelSettleidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_GoAbroadSettler.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询定居表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_GoAbroadSettler> SelectSettleByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadSettler>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询定居表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_GoAbroadSettler SelectOneSettleByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadSettler>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 出国情况报告总表
        /// <summary>
        /// 查询所有出国情况报告总
        /// </summary>
        /// <returns></returns>
        public List<DT_GoAbroadTotal> SelectAbroadTotal()
        {
            return ef.Select<DT_GoAbroadTotal>();

        }

        /// <summary>
        /// 添加出国情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddAbroadTotal(DT_GoAbroadTotal u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改出国情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdAbroadTotal(DT_GoAbroadTotal u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除出国情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelAbroadTotal(DT_GoAbroadTotal u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询出国情况报告总(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadTotal QueryTotalById(int id)
        {
            return ef.SelectByElement<DT_GoAbroadTotal>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Abroadid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelAbroadTotalidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_GoAbroadTotal.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询Abroadid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? AbroadTotalIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.GoAbroadId).FirstOrDefault();

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
        /// 根据UserId查询出国情况报告总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_GoAbroadTotal> SelectAbroadTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询出国情况报告总表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_GoAbroadTotal SelectOneAbroadTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_GoAbroadTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
