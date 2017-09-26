using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yisaa.DAL
{
    /// <summary>
    /// 用户管理
    /// </summary>
   public class UserManageDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

       
        #region 用户管理
       /// <summary>
       /// 查询所有用户
       /// </summary>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelectUsers()
       {
           return ef.Select<DT_UserLoginRecord>();
       
       }

       /// <summary>
       /// 获取指定行数的用户
       /// </summary>
       /// <param name="page">当前页数</param>
       /// <param name="rows">当页条数</param>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelectUsersPage(int page,int rows)
       {
           try
           {
               return gbe.DT_UserLoginRecord.OrderBy(a => a.Id).Skip((page - 1) * rows).Take(rows).ToList();
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               throw;
           }
          

       }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUser(DT_UserLoginRecord u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdUser(DT_UserLoginRecord u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelUser(DT_UserLoginRecord u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据用户id查询用户(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_UserLoginRecord QueryById(int id)
        {
            return ef.SelectByElement<DT_UserLoginRecord>(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据用户id查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DT_UserLoginRecord> QueryUinfoById(int id)
        {
            return ef.SelectByElement<DT_UserLoginRecord>(a => a.Id == id);
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
            Tools tl = new Tools();

            string md5 = tl.GetMd5(pwd);
            try
            {
                int count = gbe.DT_UserLoginRecord.Where(a => a.Telphone == tel && a.Password == md5).Count();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {                
                throw;
            }            
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string tel, string newpwd)
        {
            Tools tl = new Tools();
            try
            {
                DT_UserLoginRecord user = gbe.DT_UserLoginRecord.Where(a=>a.Telphone==tel).FirstOrDefault();
                user.Password = tl.GetMd5(newpwd);
                gbe.Entry<DT_UserLoginRecord>(user).State = System.Data.EntityState.Modified;
                int count = gbe.SaveChanges();

                return count;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region 搜索框查询
        public List<DT_WorkUnit>  SelUnitByWord(string keywords)
        {
            return gbe.DT_WorkUnit.Where(a => a.UnitName == keywords).ToList();
        
        }
        public List<DT_UserLoginRecord>  SelUserByWord(string keywords)
        {
            return gbe.DT_UserLoginRecord.Where(a => a.RealName == keywords || a.Telphone == keywords).ToList();
        }


        public List<DTO_SearchTotal> SelectSearch(string keywords)
        {
  
            //---------------------
            //List<DTO_Search> dt = new List<DTO_Search>();
            //dt = gbe.DT_UserLoginRecord.Join(gbe.DT_Total, a => a.Id, b => b.UserId, (m, n) =>
            //    new DTO_Search()
            //    {
            //        userid =(int)n.UserId,
            //        realname = m.RealName,
            //        unitname = m.WorkUnitId,                  
            //        tel = m.Telphone,
            //        status=n.FileStatus

            //    }).ToList();

            //List<DTO_Search> sear = dt.Where(a =>((string.IsNullOrEmpty(keywords) || a.realname.Contains(keywords)) || (string.IsNullOrEmpty(keywords) || a.tel.Contains(keywords))) &&a.status=="已归档").ToList();
            //return sear;


            List<DTO_Search> dt = new List<DTO_Search>();
            dt = gbe.DT_UserLoginRecord.Join(gbe.DT_Total, a => a.Id, b => b.UserId, (m, n) =>
                new DTO_Search()
                {
                    userid = (int)n.UserId,
                    realname = m.RealName,
                    unitname = m.WorkUnitId,
                    tel = m.Telphone,
                    status = n.FileStatus

                }).ToList();

            List<DTO_Search> sear = dt.Where(a => ((string.IsNullOrEmpty(keywords) || a.realname.Contains(keywords)) || (string.IsNullOrEmpty(keywords) || a.tel.Contains(keywords))) && a.status == "已归档").ToList();

            List<DTO_SearchTotal> dttotal = new List<DTO_SearchTotal>();
            dttotal = dt.Join(gbe.DT_WorkUnit, a => a.userid, b =>b.Id , (m, n) =>
                new DTO_SearchTotal() 
                {
                    userid = m.userid,
                    realname = m.realname,
                    unitname = n.UnitName,
                    tel = m.tel,
                   
                
                }).ToList();
            List<DTO_SearchTotal> dtlist = dttotal.Where(a=>(string.IsNullOrEmpty(keywords)||a.unitname.Contains(keywords))||a.realname.Contains(keywords)).ToList();

            return dtlist;


        }

        #endregion

        #region 分页查询
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="nowIndex">当前页</param>
        /// <param name="pageLength">每页条数</param>
        /// <returns></returns>
        public List<DT_UserLoginRecord> SelectAllByPagerByFunc(int nowIndex, int pageLength)
        {
            try
            {
                return ef.GetListByPager<DT_UserLoginRecord, int>(h => 1 == 1, a => a.Id, nowIndex, pageLength, 1).Select(a => new DT_UserLoginRecord { Id = a.Id, RealName = a.RealName, WorkUnitId = a.WorkUnitId, DeptId = a.DeptId,IsCadre=a.IsCadre,Telphone=a.Telphone,Password=a.Password,RoleId=a.RoleId }).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

      


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            try
            {
                return gbe.DT_UserLoginRecord.Where(a => a.IsInner == true).Count();  //.Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
                throw;
            }
            
        }


        /// <summary>
        /// Mvc 分页
        /// </summary>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //public IPagedList<T> getMvcPageDataList(Func<T, bool> where, Func<T, object> order, int pageIndex, int pageSize)
        //{
        //    //这里为了方便直接用的EF测试，其实这里可以直接用一个获得的list比如：userInfoList.ToPagedList(page, pageSize));
        //    return context.Set<T>().Where<T>(where).OrderByDescending(order).ToPagedList(pageIndex, pageSize);
        //}
        
        #endregion

    }
}
