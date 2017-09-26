using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class WorkUnitBLL
    {
       WorkUnitDAL wdal = new WorkUnitDAL();

        #region 单位设置
        /// <summary>
        /// 查询所有单位
        /// </summary>
        /// <returns></returns>
        public List<DT_WorkUnit> SelUnitByParent()
        {
            return wdal.SelUnitByParent();

        }

        ///// <summary>
        ///// 查询出单位所有id
        ///// </summary>
        ///// <returns></returns>
        //public List<int> SelectIds()
        //{
        //    return wdal.SelectIds();
        //}

        /// <summary>
        /// 添加单位
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUnit(DT_WorkUnit w)
        {
            return wdal.AddUnit(w);
        }

        /// <summary>
        /// 修改单位
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdUnit(DT_WorkUnit w)
        {
            return wdal.UpdUnit(w);

        }
        /// <summary>
        /// 删除单位
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelUnit(DT_WorkUnit w)
        {
            return wdal.DelUnit(w);

        }

        /// <summary>
        /// 根据单位id查询单位(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_WorkUnit QueryById(int id)
        {
            return wdal.QueryById(id);
        }


        /// <summary>
        /// 查询所有单位下的科室
        /// </summary>
        /// <returns></returns>
        public List<DT_WorkUnit> SelDeptByParent()
        {
            return wdal.SelDeptByParent();

        }

        #endregion

    }
}
