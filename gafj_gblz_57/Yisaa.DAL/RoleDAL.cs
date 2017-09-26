using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();
        
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public List<DT_Role> SelectRoles()
        {
            return ef.Select<DT_Role>();

        }
        /// <summary>
        /// 根据id得到角色名
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string GetRoleByid(int rid)
        {
            try
            {
                return gbe.DT_Role.Where(a => a.Id==rid).Select(a => a.Name).ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
          
        
        }


        #region 角色管理
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddRole(DT_Role r)
        {
            try
            {
                return ef.Add(r);
            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateRole(DT_Role r)
        {
            try
            {
                return ef.Update(r);
            }
            catch (Exception)
            {

                throw;
            }

        }
     
        /// <summary>
        /// 根据id查询角色
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_Role> SelectRoleByid(int id)
        {
            try 
            {
                return ef.SelectByElement<DT_Role>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据id查询角色(一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_Role SelectOneRoleByid(int id)
        {
            try
            {
                return ef.SelectByElement<DT_Role>(a => a.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelRole(DT_Role r)
        {
            return ef.Remove(r);

        }
 
        #endregion


    }
}
