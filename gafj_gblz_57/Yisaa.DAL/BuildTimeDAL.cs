using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 建档时间管理
    /// </summary>
  public  class BuildTimeDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 建档时间管理
        /// <summary>
        /// 查询所有建档时间
        /// </summary>
        /// <returns></returns>
        public List<DT_BuildTime> SelectTimes()
        {
            return ef.Select<DT_BuildTime>();

        }

        /// <summary>
        /// 添加建档时间
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddTime(DT_BuildTime b)
        {
            return ef.Add(b);
        }

        /// <summary>
        /// 修改建档时间
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdTime(DT_BuildTime b)
        {
            return ef.Update(b);

        }
        /// <summary>
        /// 删除建档时间
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelTime(DT_BuildTime b)
        {
            return ef.Remove(b);

        }

        /// <summary>
        /// 根据id查询建档时间(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_BuildTime QueryById(int id)
        {
            return ef.SelectByElement<DT_BuildTime>(a => a.Id == id).FirstOrDefault();
        }

        #endregion

        #region 分页
        

        //public List<GoodsInfo> GetGoodsList(int _page, int _rows, string name, out int _allcount)
        //{
        //    se.Configuration.ProxyCreationEnabled = false;

        //    var listtemp = se.GoodsInfo.Where(a => a.goodsName.Contains(name) || string.IsNullOrEmpty(name));
        //    _allcount = listtemp.Count();
        //    return listtemp.OrderBy(a => a.goodsId).Skip((_page - 1) * _rows).Take(_rows).ToList();
        //}

      /// <summary>
      /// 得到时间列表
      /// </summary>
      /// <param name="_page">当前页</param>
      /// <param name="_rows">每页的条数</param>
      /// <param name="_allcount">总条数</param>
      /// <returns></returns>
        public List<DT_BuildTime> GetTimeList(int _page,int _rows,out int _allcount)
        {
            var listtemp = gbe.DT_BuildTime.ToList();
            _allcount = listtemp.Count();


            try
            {
                return listtemp.OrderBy(a => a.Id).Skip((_page - 1) * _rows).Take(_rows).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
            

        
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
               if (gbe.DT_BuildTime.OrderByDescending(a => a.AddTime).FirstOrDefault()==null)
                {
                    return null;
                }
               else
               {
                   return gbe.DT_BuildTime.OrderByDescending(a => a.AddTime).FirstOrDefault();
               }
               
            }
            catch (Exception)   
            {
                
                throw;
            }
           
        }


    }
}
