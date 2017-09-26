﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class ShareBLL
    {
       ShareDAL sdal = new ShareDAL();

       /// <summary>
       /// 根据id查询共享信息（一条数据）
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public DT_Share SelectShareById(int id)
       {

           return sdal.SelectShareById(id);

       }
       /// <summary>
       /// 根据id查询共享信息 (返回多条)
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public List<DT_Share> SelSharesById(int id)
       {

           return sdal.SelSharesById(id);

       }


        #region 共享
       /// <summary>
       /// 查询所有系统内部用户
       /// </summary>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelInners()
       {
           return sdal.SelInners();

       }
       /// <summary>
       /// 查询所有系统外用户
       /// </summary>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelForeign()
       {
           try
           {
               return sdal.SelForeign();
           }
           catch (Exception)
           {

               throw;
           }

       }
       /// <summary>
       /// 查询所有角色为0的用户
       /// </summary>
       /// <returns></returns>
       public List<DT_UserLoginRecord> SelRoles()
       {
           try
           {
               return sdal.SelRoles();
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
            return sdal.AddShare(s);
        }

        /// <summary>
        /// 删除共享
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int DelShare(DT_Share s)
        {
            return sdal.DelShare(s);
        }

        /// <summary>
        /// 修改总表 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdShare(DT_Share s)
        {
            return sdal.UpdShare(s);

        }
        /// <summary>
        /// 查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<DT_Share> SelectShare()
        {
            return sdal.SelectShare();
        }

        /// <summary>
        /// 年份
        /// </summary>
        /// <returns></returns>
        public List<DT_Total> SelYears()
        {
            return sdal.SelYears();

        }


        #endregion

        /// <summary>
        /// 查总表 给年份分组
        /// </summary>
        /// <returns></returns>
        public List<DT_Total> Total()
        {
            return sdal.Total();

        }

        /// <summary>
        /// 添加共享人
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int AddSharePeople(DT_SharePeople sp)
        {
            return sdal.AddSharePeople(sp);


        }
        /// <summary>
        /// 查询所有共享人
        /// </summary>
        /// <returns></returns>
        public List<DT_SharePeople> SelSharePeople()
        {
            return sdal.SelSharePeople();

        }

        /// <summary>
        /// 添加被共享人
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int AddBeShared(DT_BeShared bs)
        {
            return sdal.AddBeShared(bs);


        }
        /// <summary>
        /// 删除被共享人
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int DelBeShared(DT_BeShared s)
        {
            return sdal.DelBeShared(s);

        }
        /// <summary>
        /// 查询被共享人id
        /// </summary>
        /// <returns></returns>
        public DT_BeShared SelBeSharedId(int bid)
        {
            return sdal.SelBeSharedId(bid);

        }
        /// <summary>
        /// 查询所有被共享人
        /// </summary>
        /// <returns></returns>
        public List<DT_BeShared> SelBeShared()
        {
            return sdal.SelBeShared();

        }

        /// <summary>
        /// 修改外部共享人的roleid
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdShareRoleId(DT_UserLoginRecord u)
        {
            return sdal.UpdShareRoleId(u);

        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_UserLoginRecord QueryUserByid(int id)
        {
            return sdal.QueryUserByid(id);

        }

        /// <summary>
        /// 根据共享人id查询记录
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public List<DT_Share> SelShares(int sid)
        {
            return sdal.SelShares(sid);

        }

        /// <summary>
        /// 根据添加时间获取最新的共享记录
        /// </summary>
        /// <returns></returns>
        public DT_Share GetLastRecord()
        {
            try
            {
                return sdal.GetLastRecord();
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
                return sdal.GetBeShareIds(sid);
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
                return sdal.GetOneShare(sid);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
