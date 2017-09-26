using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 单位设置
    /// </summary>
   public class WorkUnitDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 单位设置     
        /// <summary>
        /// 查询所有单位
        /// </summary>
        /// <returns></returns>
        public List<DT_WorkUnit> SelUnitByParent()
        {
            return ef.SelectByElement<DT_WorkUnit>(a => a.ParentId == 0 || a.ParentId == null).ToList();

        }
       ///// <summary>
       ///// 查询出单位所有id
       ///// </summary>
       ///// <returns></returns>
       // public List<int> SelectIds()
       // {
       //     return ef.Select<DT_WorkUnit>().Select(a => a.Id).ToList();  
        
       // }

        /// <summary>
        /// 添加单位
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUnit(DT_WorkUnit w)
        {
            return ef.Add(w);
        }

        /// <summary>
        /// 修改单位
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdUnit(DT_WorkUnit w)
        {
            return ef.Update(w);

        }
        /// <summary>
        /// 删除单位
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelUnit(DT_WorkUnit w)
        {
            return ef.Remove(w);

        }

        /// <summary>
        /// 根据单位id查询单位(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_WorkUnit QueryById(int id)
        {
            return ef.SelectByElement<DT_WorkUnit>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 查询所有单位下的科室
        /// </summary>
        /// <returns></returns>
        public List<DT_WorkUnit> SelDeptByParent()
        {
            return ef.SelectByElement<DT_WorkUnit>(a => a.ParentId != 0 && a.ParentId != null).ToList();

        }


        #endregion

    }
}
