using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class HouseDAL
    {

        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 住房分表
        /// <summary>
        /// 查询所有住房
        /// </summary>
        /// <returns></returns>
        public List<DT_HousingHouse> SelectHouse()
        {
            return ef.Select<DT_HousingHouse>();

        }

        /// <summary>
        /// 添加住房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddHouse(DT_HousingHouse u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改住房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdHouse(DT_HousingHouse u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除住房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelHouse(DT_HousingHouse u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询住房(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_HousingHouse QueryHouseById(int id)
        {
            return ef.SelectByElement<DT_HousingHouse>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Houseid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelHouseidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_HousingHouse.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询住房表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_HousingHouse> SelectHouseByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingHouse>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询住房表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_HousingHouse SelectOneHouseByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingHouse>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 购房分表
        /// <summary>
        /// 查询所有购房
        /// </summary>
        /// <returns></returns>
        public List<DT_HousingBuy> SelectBuy()
        {
            return ef.Select<DT_HousingBuy>();

        }

        /// <summary>
        /// 添加购房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddBuy(DT_HousingBuy u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改购房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdBuy(DT_HousingBuy u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除购房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelBuy(DT_HousingBuy u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询购房(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_HousingBuy QueryBuyById(int id)
        {
            return ef.SelectByElement<DT_HousingBuy>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Buyid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelBuyidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_HousingBuy.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询购房表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_HousingBuy> SelectBuyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingBuy>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询购房表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_HousingBuy SelectOneBuyByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingBuy>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 售房分表
        /// <summary>
        /// 查询所有售房
        /// </summary>
        /// <returns></returns>
        public List<DT_HousingSell> SelectSell()
        {
            return ef.Select<DT_HousingSell>();

        }

        /// <summary>
        /// 添加售房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddSell(DT_HousingSell u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改售房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdSell(DT_HousingSell u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除售房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelSell(DT_HousingSell u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询售房(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_HousingSell QuerySellById(int id)
        {
            return ef.SelectByElement<DT_HousingSell>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条Sellid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelSellidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_HousingSell.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询售房表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_HousingSell> SelectSellByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingSell>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询售房表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_HousingSell SelectOneSellByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingSell>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 租房分表
        /// <summary>
        /// 查询所有租房
        /// </summary>
        /// <returns></returns>
        public List<DT_HousingRentout> SelectRentout() 
        {
            return ef.Select<DT_HousingRentout>();

        }

        /// <summary>
        /// 添加租房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddRentout(DT_HousingRentout u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改租房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdRentout(DT_HousingRentout u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除租房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRentout(DT_HousingRentout u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询租房(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        public DT_HousingRentout QueryRentoutById(int id)
        {
            return ef.SelectByElement<DT_HousingRentout>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条RewardPunishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelRentoutidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_HousingRentout.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询租房表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_HousingRentout> SelectRentoutByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingRentout>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询租房表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_HousingRentout SelectOneRentoutByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingRentout>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 建房分表
        /// <summary>
        /// 查询所有建房
        /// </summary>
        /// <returns></returns>
        public List<DT_HousingBuild> SelectBuild()
        {
            return ef.Select<DT_HousingBuild>();

        }

        /// <summary>
        /// 添加建房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddBuild(DT_HousingBuild u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改建房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdBuild(DT_HousingBuild u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除建房
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelBuild(DT_HousingBuild u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询建房(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_HousingBuild QueryBuildById(int id)
        {
            return ef.SelectByElement<DT_HousingBuild>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条RewardPunishid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelBuildidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_HousingBuild.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).FirstOrDefault();

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据UserId查询建房表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_HousingBuild> SelectBuildByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingBuild>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询建房表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_HousingBuild SelectOneBuildByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingBuild>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 住房情况报告总表
        /// <summary>
        /// 查询所有住房情况报告总
        /// </summary>
        /// <returns></returns>
        public List<DT_HousingTotal> SelectHousingTotal()
        {
            return ef.Select<DT_HousingTotal>();

        }

        /// <summary>
        /// 添加住房情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddHousingTotal(DT_HousingTotal u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改住房情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdHousingTotal(DT_HousingTotal u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除住房情况报告总
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelHousingTotal(DT_HousingTotal u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询住房情况报告总(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_HousingTotal QueryTotalById(int id)
        {
            return ef.SelectByElement<DT_HousingTotal>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据登录id查询最近一条HousingTotalid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelHousingTotalidByUserid(int uid)
        {
            try
            {
                int userid = gbe.DT_HousingTotal.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

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
        public int? HousingTotalIdIsNull(int uid)
        {
            try
            {

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.HousingId).FirstOrDefault();

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
        /// 根据UserId查询住房情况报告总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_HousingTotal> SelectHousingTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询住房情况报告总表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_HousingTotal SelectOneHousingTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_HousingTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
