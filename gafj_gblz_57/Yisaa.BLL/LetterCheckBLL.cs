using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yisaa.DAL;

namespace Yisaa.BLL
{
   public class LetterCheckBLL
    {
       LetterCheckDAL lcdal = new LetterCheckDAL();

        #region 信访核查
        /// <summary>
        /// 查询所有信访核查
        /// </summary>
        /// <returns></returns>
        public List<DT_PetitionLetter> SelectLetterChk()
        {
            return lcdal.SelectLetterChk();

        }

        /// <summary>
        /// 添加信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddLetterChk(DT_PetitionLetter u)
        {
            return lcdal.AddLetterChk(u);
        }

        /// <summary>
        /// 修改信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdLetterChk(DT_PetitionLetter u)
        {
            return lcdal.UpdLetterChk(u);

        }
        /// <summary>
        /// 删除信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelLetterChk(DT_PetitionLetter u)
        {
            return lcdal.DelLetterChk(u);

        }

        /// <summary>
        /// 根据id查询信访核查(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_PetitionLetter QueryById(int id)
        {
            return lcdal.QueryById(id);
        }

        /// <summary>
        /// 根据登录id查询最近一条LetterChkid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int SelLetterChkidByUserid(int uid)
        {
            try
            {
                int userid = lcdal.SelLetterChkidByUserid(uid);

                return userid;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据登录id查询 LetterChkid是否为空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int? LetterChkIdIsNull(int uid)
        {
            try
            {

                int? id = lcdal.LetterChkIdIsNull(uid);

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
        /// 根据UserId查询信访核查表
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_PetitionLetter> SelectLetterChkByUid(int uid)
        {
            try
            {
                return lcdal.SelectLetterChkByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 根据UserId查询信访核查表（返回一条数据）
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DT_PetitionLetter SelectOneChkByUid(int uid)
        {
            try
            {
                return lcdal.SelectOneChkByUid(uid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 根据Id查询信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<DT_PetitionLetter> SelectLetterByid(int id)
        {
            try
            {
                return lcdal.SelectLetterByid(id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
