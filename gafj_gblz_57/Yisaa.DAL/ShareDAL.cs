using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    /// <summary>
    /// 共享
    /// </summary>
   public class ShareDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

       /// <summary>
       /// 根据id查询共享信息（返回一条数据）
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public DT_Share SelectShareById(int id)
        {

           return ef.SelectByElement<DT_Share>(a=>a.Id==id).FirstOrDefault();
        
        }

        /// <summary>
        /// 根据id查询共享信息 (返回多条)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DT_Share> SelSharesById(int id)
        {

            return ef.SelectByElement<DT_Share>(a => a.Id == id);

        }


        #region 共享
       /// <summary>
       /// 查询所有系统内部用户
       /// </summary>
       /// <returns></returns>
        public List<DT_UserLoginRecord> SelInners()
        {
            try
            {
                return ef.SelectByElement<DT_UserLoginRecord>(a => a.IsInner == true);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        
        }
        /// <summary>
        /// 查询所有系统外用户
        /// </summary>
        /// <returns></returns>
        public List<DT_UserLoginRecord> SelForeign()
        {
            try
            {
                return ef.SelectByElement<DT_UserLoginRecord>(a => a.IsInner == false);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 查询所有角色为0的用户
        /// </summary> 查询所有共享状态为“是”的用户
        /// <returns></returns>
        public List<DT_UserLoginRecord> SelRoles()
        {
            try
            {
                return ef.SelectByElement<DT_UserLoginRecord>(a => a.ShareStatus=="是");
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// 添加共享
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int AddShare(DT_Share s)
        {
            return ef.Add(s);
        }

       /// <summary>
       /// 删除共享
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
        public int DelShare(DT_Share s)
        {
            return ef.Remove(s);
        }

        /// <summary>
        /// 修改总表 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdShare(DT_Share s)
        {
            return ef.Update(s);

        }
        /// <summary>
        /// 查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<DT_Share> SelectShare()
        {
            return ef.Select<DT_Share>().ToList();
        }

       /// <summary>
       /// 年份
       /// </summary>
       /// <returns></returns>
        public  List<DT_Total>  SelYears()
        {
             var y= gbe.DT_Total.GroupBy(a => a.YearTable).Select(b => new DT_Total { YearTable = b.Key }).ToList();

             return y;
        }
        
        #endregion

       /// <summary>
       /// 查总表 给年份分组
       /// </summary>
       /// <returns></returns>
        public List<DT_Total> Total()
        {
            return ef.Select<DT_Total>();
        
        }

       /// <summary>
       /// 添加共享人
       /// </summary>
       /// <param name="sp"></param>
       /// <returns></returns>
        public int AddSharePeople(DT_SharePeople sp)
        {
            return ef.Add(sp);

        
        }
        /// <summary>
        /// 查询所有共享人
        /// </summary>
        /// <returns></returns>
        public List<DT_SharePeople> SelSharePeople()
        {
            return ef.Select<DT_SharePeople>();

        }


        /// <summary>
        /// 添加被共享人
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int AddBeShared(DT_BeShared bs)
        {
            return ef.Add(bs);


        }
       /// <summary>
       /// 删除被共享人
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
        public int DelBeShared(DT_BeShared s)
        {
          return ef.Remove(s);
        
        }
       /// <summary>
       /// 查询被共享人id
       /// </summary>
       /// <returns></returns>
        public DT_BeShared SelBeSharedId(int bid)
        {
            try
            {
                return gbe.DT_BeShared.Where(a => a.BeSharedId == bid).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        
        }

       /// <summary>
       /// 查询所有被共享人
       /// </summary>
       /// <returns></returns>
        public List<DT_BeShared> SelBeShared()
        {
           return ef.Select<DT_BeShared>();
        
        }

       /// <summary>
       /// 修改外部共享人的roleid
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
        public int UpdShareRoleId(DT_UserLoginRecord u)
        {
            //List<DT_UserLoginRecord> l = gbe.DT_UserLoginRecord.Where(a=>a.IsInner == false).ToList();

          return  ef.Update(u);
        
        }

       /// <summary>
       /// 查询一条记录
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public DT_UserLoginRecord QueryUserByid(int id)
        {
           return ef.SelectByElement<DT_UserLoginRecord>(a => a.Id == id).FirstOrDefault();
        
        }


       /// <summary>
       /// 根据共享人id查询记录
       /// </summary>
       /// <param name="sid"></param>
       /// <returns></returns>
        public List<DT_Share> SelShares(int sid)
        {
            try
            {
                return gbe.DT_Share.Where(a => a.ShareId == sid).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        
        }

        /// <summary>
        /// 根据添加时间获取最新的共享记录
        /// </summary>
        /// <returns></returns>
        public DT_Share GetLastRecord()
        {
            try
            {
                return gbe.DT_Share.OrderByDescending(a => a.CreateTime).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //--根据传进来的shareid查询到BeShareId的集合
        public List<int?> GetBeShareIds(int sid)
        {
            try
            {
                return gbe.DT_Share.Where(a => a.ShareId == sid).OrderByDescending(a => a.CreateTime).Select(a => a.BeSharedId).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
         
        }
        //--根据传进来的shareid查询到最新一条记录
        public DT_Share GetOneShare(int sid)
        {
            try
            {
                return gbe.DT_Share.Where(a => a.ShareId == sid).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }
 
       
    }
}
