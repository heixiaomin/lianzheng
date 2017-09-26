using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
    public class AbroadBLL
    {
        AbroadDAL adal = new AbroadDAL();

        #region 出国办企分表
        /// <summary>
        /// 查询所有办企
        /// </summary>
        /// <returns></returns>
        public List<DT_GoAbroadCompany> SelectCompany()
        {
            return adal.SelectCompany();

        }

        /// <summary>
        /// 添加办企
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddCompany(DT_GoAbroadCompany u)
        {
            return adal.AddCompany(u);
        }

        /// <summary>
        /// 修改办企
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdCompany(DT_GoAbroadCompany u)
        {
            return adal.UpdCompany(u);

        }
        /// <summary>
        /// 删除办企
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelCompany(DT_GoAbroadCompany u)
        {
            return adal.DelCompany(u);

        }

        /// <summary>
        /// 根据id查询办企(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadCompany QueryCompanyById(int id)
        {
            return adal.QueryCompanyById(id);
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
                int userid = adal.SelCompanyidByUserid(uid);

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
                return adal.SelectCompanyByUid(uid);
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
                return adal.SelectOneCompanyByUid(uid);
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
            return adal.SelectStudy();

        }

        /// <summary>
        /// 添加留学
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddStudy(DT_GoAbroadStudy u)
        {
            return adal.AddStudy(u);
        }

        /// <summary>
        /// 修改留学
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdStudy(DT_GoAbroadStudy u)
        {
            return adal.UpdStudy(u);

        }
        /// <summary>
        /// 删除留学
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelStudy(DT_GoAbroadStudy u)
        {
            return adal.DelStudy(u);

        }

        /// <summary>
        /// 根据id查询留学(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadStudy QueryStudyById(int id)
        {
            return adal.QueryStudyById(id);
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
                int userid = adal.SelStudyidByUserid(uid);

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
                return adal.SelectStudyByUid(uid);
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
                return adal.SelectOneStudyByUid(uid);
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
            return adal.SelectSettle();

        }

        /// <summary>
        /// 添加定居
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddSettle(DT_GoAbroadSettler u)
        {
            return adal.AddSettle(u);
        }

        /// <summary>
        /// 修改定居
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdSettle(DT_GoAbroadSettler u)
        {
            return adal.UpdSettle(u);

        }
        /// <summary>
        /// 删除定居
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelSettle(DT_GoAbroadSettler u)
        {
            return adal.DelSettle(u);

        }

        /// <summary>
        /// 根据id查询定居(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadSettler QuerySettleById(int id)
        {
            return adal.QuerySettleById(id);
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
                int userid = adal.SelSettleidByUserid(uid);

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
                return adal.SelectSettleByUid(uid);
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
                return adal.SelectOneSettleByUid(uid);
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
            return adal.SelectAbroadTotal();

        }

        /// <summary>
        /// 添加出国情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddAbroadTotal(DT_GoAbroadTotal u)
        {
            return adal.AddAbroadTotal(u);
        }

        /// <summary>
        /// 修改出国情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdAbroadTotal(DT_GoAbroadTotal u)
        {
            return adal.UpdAbroadTotal(u);

        }
        /// <summary>
        /// 删除出国情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelAbroadTotal(DT_GoAbroadTotal u)
        {
            return adal.DelAbroadTotal(u);

        }

        /// <summary>
        /// 根据id查询出国情况报告总(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_GoAbroadTotal QueryTotalById(int id)
        {
            return adal.QueryTotalById(id);
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
                int userid = adal.SelAbroadTotalidByUserid(uid);

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

                int? id = adal.AbroadTotalIdIsNull(uid);

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
                return adal.SelectAbroadTotalByUid(uid);
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
                return adal.SelectOneAbroadTotalByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
