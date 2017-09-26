using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
    public class RoleBLL
    {
        RoleDAL rdal = new RoleDAL();
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public List<DT_Role> SelectRoles()
        {
            return rdal.SelectRoles();

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
                return rdal.GetRoleByid(rid);
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
                return rdal.AddRole(r);
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
                return rdal.UpdateRole(r);
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
                return rdal.SelectRoleByid(id);
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
                return rdal.SelectOneRoleByid(id);
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
            return rdal.DelRole(r);

        }

        #endregion


    }
}
