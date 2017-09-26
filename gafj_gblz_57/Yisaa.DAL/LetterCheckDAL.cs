using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class LetterCheckDAL
    {
        db_gblzEntities gbe = new db_gblzEntities();
        EFhelper<db_gblzEntities> ef = new EFhelper<db_gblzEntities>();

        #region 信访核查
        /// <summary>
        /// 查询所有信访核查
        /// </summary>
        /// <returns></returns>
        public List<DT_PetitionLetter> SelectLetterChk()
        {
            return ef.Select<DT_PetitionLetter>();

        }

        /// <summary>
        /// 添加信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns> 
        public int AddLetterChk(DT_PetitionLetter u)
        {
            return ef.Add(u);
        }

        /// <summary>
        /// 修改信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdLetterChk(DT_PetitionLetter u)
        {
            return ef.Update(u);

        }
        /// <summary>
        /// 删除信访核查
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int DelLetterChk(DT_PetitionLetter u)
        {
            return ef.Remove(u);

        }

        /// <summary>
        /// 根据id查询信访核查(返回一条数据)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DT_PetitionLetter QueryById(int id)
        {
            return ef.SelectByElement<DT_PetitionLetter>(a => a.Id == id).FirstOrDefault();
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
                int userid = gbe.DT_PetitionLetter.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.FillTime).Select(a => a.Id).FirstOrDefault();

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

                int? id = gbe.DT_Total.Where(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).OrderByDescending(a => a.AddTime).Select(a => a.PetitionLetterId).FirstOrDefault();

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
                return ef.SelectByElement<DT_PetitionLetter>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).ToList();
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
        public  DT_PetitionLetter SelectOneChkByUid(int uid)
        {
            try
            {
                return ef.SelectByElement<DT_PetitionLetter>(a => a.UserId == uid && a.YearTable == DateTime.Now.Year).FirstOrDefault();
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
                return ef.SelectByElement<DT_PetitionLetter>(a => a.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
