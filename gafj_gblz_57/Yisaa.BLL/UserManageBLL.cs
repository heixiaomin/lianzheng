using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;
 

namespace Yisaa.BLL
{
    /// <summary>
    /// 用户管理
    /// </summary>
   public class UserManageBLL
    {
       UserManageDAL umdal = new UserManageDAL();

        #region 用户管理
       /// <summary>
       /// 查询所有用户
       /// </summary>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelectUsers()
       {
           return umdal.SelectUsers();

       }

       /// <summary>
       /// 获取指定行数的用户
       /// </summary>
       /// <param name="page">当前页数</param>
       /// <param name="rows">当页条数</param>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelectUsersPage(int page, int rows)
       {

           return umdal.SelectUsersPage(page,rows);
           
       }



        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUser(DT_UserLoginRecord u)
        {
            return umdal.AddUser(u);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdUser(DT_UserLoginRecord u)
        {
            return umdal.UpdUser(u);

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelUser(DT_UserLoginRecord u)
        {
            return umdal.DelUser(u);

        }

        /// <summary>
        /// 根据用户id查询用户(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_UserLoginRecord QueryById(int id)
        {
            return umdal.QueryById(id);
        }

        /// <summary>
        /// 根据用户id查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DT_UserLoginRecord> QueryUinfoById(int id)
        {
            return umdal.QueryUinfoById(id);
        }

        #endregion


        #region 修改密码
        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool IfRight(string tel, string pwd)
        {
          return  umdal.IfRight(tel,pwd);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string tel, string newpwd)
        {
            return umdal.UpdatePwd(tel,newpwd);
        }
        #endregion

        #region 搜索框查询
        public List<DT_WorkUnit> SelUnitByWord(string keywords)
        {
            return umdal.SelUnitByWord(keywords);

        }
        public List<DT_UserLoginRecord> SelUserByWord(string keywords)
        {
            return umdal.SelUserByWord(keywords);
        }

       //关键词
        public List<DTO_SearchTotal> SelectSearch(string keywords)
        {
            return umdal.SelectSearch(keywords);
        
        }

        #endregion


        #region 分页查询
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<DT_UserLoginRecord> SelectAllByPagerByFunc(int nowIndex, int pageLength)
        {
            return umdal.SelectAllByPagerByFunc(nowIndex,pageLength);

        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return umdal.GetCount();
        }

        #endregion
    }
}
