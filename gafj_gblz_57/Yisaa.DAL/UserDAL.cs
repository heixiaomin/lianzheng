using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    public class UserDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="telphone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DT_UserLoginRecord Login(string telphone, string pwd)
        {
            try
            {

                DT_UserLoginRecord user = gbe.DT_UserLoginRecord.Where(a => a.Telphone == telphone && a.Password == pwd).FirstOrDefault();

                return user;
            }
            catch (Exception)
            {

                throw;
            }

        }

       

        #endregion
   
        #region 其他
        /// <summary>
        /// 根据uid获取头像
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetImg(int uid)
        {
            string img = gbe.DT_UserInfo.Where(a => a.UserId == uid).OrderByDescending(a=>a.Id).Select(a => a.Photo).FirstOrDefault();

            return img;
        }
        /// <summary>
        /// 获取基本表一信息
        /// </summary>
        /// <returns></returns>
        public List<int> GetTableId()
        {
            return gbe.DT_UserInfo.Select(a => a.Id).ToList();

        }

        /// <summary>
        /// 根据登录id查询最近一条UserInfoId
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelIdByUserid(int uid)
        {
            int userid = gbe.DT_UserInfo.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

            return userid;
        }

        /// <summary>
        /// 根据登录id查询最近一条FamilyId
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelFaidByUserid(int uid)
        {
            int userid = gbe.DT_FamilyTotal.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

            return userid;
        }

        /// <summary>
        /// 是否科级干部
        /// </summary>
        /// <returns></returns>
        public bool? IsCadre(int id)
        {
            try
            {
                bool? user = gbe.DT_UserLoginRecord.Where(a => a.Id == id).Select(a => a.IsCadre).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 是否科级干部2
        /// </summary>
        /// <returns></returns>
        public List<bool?> IsCadre2(int id)
        {
            try
            {
                List<bool?> user = gbe.DT_UserLoginRecord.Where(a => a.Id == id).Select(a => a.IsCadre).ToList();

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DT_Total UserIsNull(int id)
        {
            try
            {
                return gbe.DT_Total.Where(a => a.UserInfoId == id && a.YearTable == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
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
                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.FamilyId).FirstOrDefault();

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
        /// 根据登录id查询UserInfoId是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? IsNull(int uid)
        {
            try
            {
                //Where(a => a.Id == id).
                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.UserInfoId).FirstOrDefault();

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
            return gbe.DT_UserInfo.Select(a => a.Id).FirstOrDefault();

        }
        /// <summary>
        /// 根据登录的userid查询该表的所有id
        /// </summary>
        /// <returns></returns>
        public List<int> SelectIdByUid(int uid)
        {
            return gbe.DT_UserInfo.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).Select(a => a.Id).ToList();

        }

        /// <summary>
        /// 修改总表的一个状态
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        //public int UpdTotalStatus(int uid)
        //{
        //    return gbe.DT_UserInfo.Where(a=>a.UserId==uid).OrderByDescending(a=>a.FillTime)

        //}
        /// <summary>
        /// 根据id查询总表id(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_Total QueryToById(int id)
        {
            //a.Id
            return ef.SelectByElement<DT_Total>(a => a.UserId == id && a.YearTable == DateTime.Now.Year).FirstOrDefault();
        }
        /// <summary>
        /// 查询状态  此处要注意 年份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelStatus(int uid)
        {
            return gbe.DT_Total.Where(a => a.UserId == uid&&a.YearTable==DateTime.Now.Year).Select(a => a.Status).FirstOrDefault();
            
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
            return ef.Add(t);
        }
        
        /// <summary>
        /// 修改总表 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdTotal(DT_Total t)
        {
            return ef.Update(t);

        }
        /// <summary>
        /// 查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<DT_Total> SelectTotal(DT_Total t)
        {
            return ef.Select<DT_Total>().ToList();
        }

        /// <summary>
        /// 根据id查询总表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DT_Total SelectOneTotal(int id)
        {
            return ef.SelectByElement<DT_Total>(a => a.UserInfoId == id && a.YearTable == DateTime.Now.Year).FirstOrDefault();
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
            try
            {
                return ef.Add(u);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 修改基本信息表1
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateUserInfo(DT_UserInfo u)
        {
            try
            {
                return ef.Update(u);
            }
            catch (Exception)
            {

                throw;
            }

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
                return ef.SelectByElement<DT_UserInfo>(a => a.Id == id && a.YearTable == DateTime.Now.Year).ToList();
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
            try
            {
                return ef.SelectByElement<DT_UserInfo>(a => a.UserId == uid&&a.YearTable==DateTime.Now.Year).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 根据id查询基本信息表1(一条数据)
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_UserInfo SelUserinfoById(int uid)
        {
            //a.Id
            return ef.SelectByElement<DT_UserInfo>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();        
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
                return ef.SelectByElement<DT_Family>(a => a.Id == id).ToList();
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
            try
            {
                return ef.Select<DT_UserInfo>().ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region 家庭成员分表
      /// <summary> 
        /// 修改家庭成员的所有FamilyTotalId 
      /// </summary>
      /// <param name="id"></param> 
      /// <returns></returns>       int id
        public DT_Family UpdFaIds(DT_Family fa)
        {
            try
            {
              //List<DT_Family> flist= gbe.DT_Family.Where(a => a.UserId == uid).ToList();
              
              DT_Family f = gbe.DT_Family.Where(a=>a.UserId==fa.UserId).FirstOrDefault();
              
                return f;
             
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
            return ef.SelectByElement<DT_Family>(a => a.Id == id).FirstOrDefault();

        }


        /// <summary>
        /// 查询家庭成员表
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public List<DT_Family> SelFamily(int uid)
        {
            return ef.SelectByElement<DT_Family>(a=>a.UserId==uid&&a.YearTable==DateTime.Now.Year).ToList();

        }

        /// <summary>
        /// 添加基本信息表2
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddFamily(DT_Family f)
        {
            return ef.Add(f);
        }
        /// <summary>
        /// 修改基本信息表2
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateFamily(DT_Family f)
        {
            return ef.Update(f);
        }

        /// <summary>
        /// 删除基本信息表2
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelFamily(DT_Family f)
        {
            return ef.Remove(f);
        }



        #endregion

        #region 基本信息表2（家庭成员总表）

        /// <summary>
        /// 查询家庭成员总表
        /// </summary>
        /// <returns></returns>
        public List<DT_FamilyTotal> SelFamilyTotal()
        {
            return ef.Select<DT_FamilyTotal>();
        
        }

        /// <summary>
        /// 根据uid查询家庭成员总表集合
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_FamilyTotal> SelectFaByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_FamilyTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
        public  DT_FamilyTotal SelectFaTotalByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_FamilyTotal>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
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
                return ef.SelectByElement<DT_FamilyTotal>(a => a.Id == id).ToList();
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
            return ef.SelectByElement<DT_FamilyTotal>(a => a.Id == id).FirstOrDefault();

        }

        /// <summary>
        /// 添加家庭成员总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddFamilyTotal(DT_FamilyTotal ft)
        {
            return ef.Add(ft);
        }
        /// <summary>
        /// 修改家庭成员总表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateFamilyTotal(DT_FamilyTotal ft)
        {
            return ef.Update(ft);
        }
        #endregion

        #region 获取最近一次登录时间

        public DateTime GetLastLoginTime(int id)
        {
            DateTime time = DateTime.Now;
            try
            {
                time = (DateTime)gbe.DT_UserLoginRecord.Where(a => a.Id == id).OrderByDescending(a => a.LoginTime).Skip(1).Select(a => a.LoginTime).First();
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
                ip = gbe.DT_UserLoginRecord.Where(a => a.Id == id).OrderByDescending(a => a.LoginTime).Skip(1).Select(a => a.LoginIp).First();

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
        //        DT_UserLoginRecord r = new DT_UserLoginRecord();
        //        r.Id = id;
        //        r.LoginIp = ip;
        //        r.LoginTime = DateTime.Now;
        //        r.Remark = remark;

        //        return ef.Update(r);

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
               
                return ef.Update(u);

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
            try
            {
                return gbe.DT_UserLoginRecord.Where(a=>a.Id==id).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        
        }

        /// <summary>
        /// 获取某一用户的登录记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DT_UserLoginRecord> GetOneLogionRecord(int id, int page)
        {
            try
            {
                List<DT_UserLoginRecord> dtuser = gbe.DT_UserLoginRecord.Where(a => a.Id == id).OrderByDescending(a => a.LoginTime).Skip((page - 1) * 8).Take(8).ToList();

                return dtuser;
            }
            catch (Exception)
            {
                
                throw;
            }
           

        }

        /// <summary>
        /// 得到登录记录的总条数
        /// </summary>
        /// <returns></returns>
        public int GetLogionRecordCount()
        {
            try
            {
                int count = gbe.DT_UserLoginRecord.Count();

                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
           

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
                return gbe.DT_UserLoginRecord.Where(a => a.Id == uid).Select(a => a.WorkUnitId).FirstOrDefault(); 
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
          return gbe.DT_FamilyTotal.Where(a=>a.UserId==uid).OrderByDescending(a=>a.FillTime).Select(a => a.Id).FirstOrDefault();
        
        }

    }
}
