using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class UserBLL
    {
       UserDAL udal = new UserDAL();

       #region 登录
       /// <summary>
       /// 登录
       /// </summary>
       /// <param name="tel"></param>
       /// <param name="pwd"></param>
       /// <returns></returns>
       public DT_UserLoginRecord Login(string tel, string pwd)
       {
           return udal.Login(tel, pwd);

       }
       #endregion

       #region 其他
       /// <summary>
       /// 根据uid获取头像
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public string GetImg(int uid)
       {
           return udal.GetImg(uid);
       }


       /// <summary>
       /// 获取基本表一信息
       /// </summary>
       /// <returns></returns>
       public List<int> GetTableId()
       {
           return udal.GetTableId();

       }

       /// <summary>
       /// 根据登录id查询最近一条UserInfoId
       /// </summary>
       /// <param name="uid"></param>
       /// <returns></returns>
       public int SelIdByUserid(int uid)
       {
           int userid = udal.SelIdByUserid(uid);

           return userid;
       }

       /// <summary>
       /// 根据登录id查询最近一条FamilyId
       /// </summary>
       /// <param name="uid"></param>
       /// <returns></returns>
       public int SelFaidByUserid(int uid)
       {
           int userid = udal.SelFaidByUserid(uid); 

           return userid;
       }    
      
       /// <summary>
       /// 根据登录id查询FamilyId是否为空
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int? FamidIsNull(int uid)
       {
           try
           {

               int? id = udal.FamidIsNull(uid);
               if (id == null)
               {
                   return null;
               }
               else
               {
                   return id;
               }
           }
           catch (Exception)
           {

               throw;
           }
       }

       /// <summary>
       /// 根据id查询UserInfoId是否为空
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int? IsNull(int uid)
       { 

           try
           {
               int? id = udal.IsNull(uid);
               if (id == null)
               {
                   return null;
               }
               else
               {
                   return id;
               }
           }
           catch (Exception)
           {

               throw;
           }

       }

       /// <summary>
       /// 查询用户表的id 
       /// </summary>
       /// <returns></returns>
       public int SelectUid()
       {
           return udal.SelectUid();

       }

       /// <summary>
       /// 查询状态  此处要注意 年份
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public string SelStatus(int uid)
       {
           return udal.SelStatus(uid);

       }
       /// <summary>
       /// 是否科级干部
       /// </summary>
       /// <returns></returns>
       public bool? IsCadre(int id)
       {

           return udal.IsCadre(id);
       }

       /// <summary>
       /// 是否科级干部
       /// </summary>
       /// <returns></returns>
       public List<bool?> IsCadre2(int id)
       {

           return udal.IsCadre2(id);
       }

       #endregion

       #region 总表
       /// <summary>
       /// 添加总表
       /// </summary>
       /// <param name="t"></param>
       /// <returns></returns>
       public int AddTotal(DT_Total t)
       {
           return udal.AddTotal(t);
       }

       /// <summary>
       /// 修改总表 
       /// </summary>
       /// <param name="t"></param>
       /// <returns></returns>
       public int UpdTotal(DT_Total t)
       {
           return udal.UpdTotal(t);

       }

       /// <summary>
       /// 根据id查询总表id(返回一条数据)
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public DT_Total QueryToById(int id)
       {
           return udal.QueryToById(id);
       }
       #endregion
     
       #region 基本信息表1
       /// <summary>
       /// 添加基本信息表1
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int AddUserInfo(DT_UserInfo u)
       {
           return udal.AddUserInfo(u);

       }

       /// <summary>
       /// 修改基本信息表1
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int UpdateUserInfo(DT_UserInfo u)
       {
           return udal.UpdateUserInfo(u);

       }
       /// <summary>
       /// 根据Id查询基本信息表1
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public List<DT_UserInfo> SelectUInfoByid(int id)
       {
           try
           {
               return udal.SelectUInfoByid(id);
           }
           catch (Exception)
           {

               throw;
           }

       }

       /// <summary>
       /// 根据UserId查询基本信息表1
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public List<DT_UserInfo> SelectUserInfoByid(int uid)
       {
           return udal.SelectUserInfoByid(uid).ToList(); 
                
       }


       /// <summary>
       /// 根据id查询基本信息表1(一条数据)
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public DT_UserInfo SelUserinfoById(int uid)
       {
           return udal.SelUserinfoById(uid);


       }

       /// <summary>
       /// 根据id查询家庭成员表
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public List<DT_Family> SelectFamByid(int id)
       {
           try
           {
               return udal.SelectFamByid(id);
           }
           catch (Exception)
           {

               throw;
           }

       }

       /// <summary>
       /// 查询基本信息表1
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public List<DT_UserInfo> SelectUserInfo()
       {
           return udal.SelectUserInfo();
       }

       #endregion

       #region 家庭成员分表 
       /// <summary>
       /// 修改家庭成员的所有FamilyTotalId
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>int uid
       public DT_Family UpdFaIds(DT_Family fa)
       {
           try
           {
               
               return udal.UpdFaIds(fa);
           }
           catch (Exception)
           {

               throw;
           }


       }


       /// <summary>
       /// 查询一条家庭成员
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public DT_Family SelFaById(int id)
       {
           return udal.SelFaById(id);

       }
       
       /// <summary>
       /// 查询家庭成员表
       /// </summary>
       /// <param name="f"></param>
       /// <returns></returns>
       public List<DT_Family> SelFamily(int uid)
       {
           return udal.SelFamily(uid);

       }
       
       
       /// <summary>
       /// 添加基本信息表2
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int AddFamily(DT_Family f)
       {
           return udal.AddFamily(f);  
       }
       /// <summary>
       /// 修改基本信息表2
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int UpdateFamily(DT_Family f)
       {
           return udal.UpdateFamily(f);
       }

       /// <summary>
       /// 删除基本信息表2
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int DelFamily(DT_Family f)
       {
           return udal.DelFamily(f);
       }
       #endregion

       #region 基本信息表2（家庭成员总表）

       /// <summary>
       /// 查询家庭成员总表
       /// </summary>
       /// <returns></returns>
       public List<DT_FamilyTotal> SelFamilyTotal()
       {
           return udal.SelFamilyTotal();

       }

       /// <summary>
       /// 根据uid查询家庭成员总表
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public DT_FamilyTotal SelectFaTotalByUid(int uid)
       {
           try
           {
               return udal.SelectFaTotalByUid(uid);
           }
           catch (Exception)
           {

               throw;
           }

       }


       /// <summary>
       /// 根据uid查询家庭成员总表
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public List<DT_FamilyTotal> SelectFaByUid(int uid)
       {
           try
           {
               return udal.SelectFaByUid(uid);
           }
           catch (Exception)
           {

               throw;
           }

       }


       /// <summary>
       /// 根据Id查询家庭成员总表
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public List<DT_FamilyTotal> SelectFamilyByid(int id)
       {
           try
           {
               return udal.SelectFamilyByid(id);
           }
           catch (Exception)
           {

               throw;
           }

       }


       /// <summary>
       /// 查询一条家庭成员
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public DT_FamilyTotal SelFaTotalById(int id)
       {
           return udal.SelFaTotalById(id);

       }

       /// <summary>
       /// 添加家庭成员总表
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int AddFamilyTotal(DT_FamilyTotal ft)
       {
           return udal.AddFamilyTotal(ft);
       }
       /// <summary>
       /// 修改家庭成员总表
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public int UpdateFamilyTotal(DT_FamilyTotal ft)
       {
           return udal.UpdateFamilyTotal(ft);
       }
       #endregion

       #region 获取最近一次登录时间

       public DateTime GetLastLoginTime(int id)
       {
           DateTime time = DateTime.Now;
           try
           {
               time = udal.GetLastLoginTime(id);
           }
           catch
           {


           }
           return time;

       }
       #endregion

       #region 获取最后登录IP
       public string GetLastLoginIp(int id)
       {
           string ip = "本机";

           try
           {
               ip = udal.GetLastLoginIp(id);

           }
           catch
           {


           }
           return ip;

       }

       #endregion

       #region 登录记录
       /// <summary>
       /// 添加登录记录
       /// </summary>
       /// <param name="id"></param>
       /// <param name="ip"></param>
       /// <param name="remark"></param>
       /// <returns></returns>
       //public int UpdUserLoginRecord(int id, string ip, string remark)
       //{

       //    try
       //    {
           
       //        return udal.UpdUserLoginRecord(id,ip,remark);

       //    }
       //    catch
       //    {
       //        return 0;
       //    }
       //}

       public int UpdUserLoginRecord(DT_UserLoginRecord u)
       {

           try
           {

               return udal.UpdUserLoginRecord(u);

           }
           catch
           {
               return 0;
           }
       }

       /// <summary>
       /// 根据id查询用户登录表的一条记录
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public DT_UserLoginRecord QueryOneUser(int id)
       {

           return udal.QueryOneUser(id);

       }


       /// <summary>
       /// 获取某一用户的登录记录
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public List<DT_UserLoginRecord> GetOneLogionRecord(int id, int page)
       {
           List<DT_UserLoginRecord> dtuser = udal.GetOneLogionRecord(id,page);

           return dtuser;

       }

       /// <summary>
       /// 得到登录记录的总条数
       /// </summary>
       /// <returns></returns>
       public int GetLogionRecordCount()
       {
           int count = udal.GetLogionRecordCount();

           return count;

       }
       #endregion


  
       /// <summary>
       /// 根据本人登录id查询其单位id
       /// </summary>
       /// <param name="uid"></param>
       /// <returns></returns>
       public int? SelUnitidByUid(int uid)
       {
           try
           {
               return udal.SelUnitidByUid(uid);
           }
           catch (Exception)
           {

               throw;
           }

       }

       /// <summary>
       /// 查询家庭总表id
       /// </summary>
       /// <returns></returns>
       public int? SelFamilyIds(int uid)
       {
           return udal.SelFamilyIds(uid);

       }

    }
}
