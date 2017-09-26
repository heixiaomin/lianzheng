using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
    /// <summary>
    /// 建档时间管理
    /// </summary>
   public class BuildTimeBLL
    {
       BuildTimeDAL bdal = new BuildTimeDAL();

        #region 建档时间管理
        /// <summary>
        /// 查询所有建档时间
        /// </summary>
        /// <returns></returns>
        public List<DT_BuildTime> SelectTimes()
        {
            return bdal.SelectTimes();

        }

        /// <summary>
        /// 添加建档时间
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddTime(DT_BuildTime b)
        {
            return bdal.AddTime(b);
        }

        /// <summary>
        /// 修改建档时间
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdTime(DT_BuildTime b)
        {
            return bdal.UpdTime(b);

        }
        /// <summary>
        /// 删除建档时间
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelTime(DT_BuildTime b)
        {
            return bdal.DelTime(b);

        }

        /// <summary>
        /// 根据用户id查询建档时间(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_BuildTime QueryById(int id)
        {
            return bdal.QueryById(id);
        }

        #endregion


        #region 分页

        /// <summary>
        /// 得到时间列表
        /// </summary>
        /// <param name="_page">当前页</param>
        /// <param name="_rows">每页的条数</param>
        /// <param name="_allcount">总条数</param>
        /// <returns></returns>
        public List<DT_BuildTime> GetTimeList(int _page, int _rows, out int _allcount)
        {
            return bdal.GetTimeList(_page,_rows,out _allcount);

        }
        #endregion


        /// <summary>
        /// 根据添加时间获取最新的建档时间
        /// </summary>
        /// <returns></returns>
        public DT_BuildTime GetLastTime() 
        {
            try
            {
                return bdal.GetLastTime();
            }
            catch (Exception)
            {

                throw;
            }



        }

    }
}
