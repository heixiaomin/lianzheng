using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    public class EFhelper<M> where M : DbContext, new()
    {

        //单列模式
        private M m;
        public EFhelper() //构建构造函数来实例继承了DbContext的类
        {
            m = new M();
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Select<T>() where T : class
        {
            try
            {
                return m.Set<T>().ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"> </param>
        /// <returns></returns>
        public List<T> SelectByElement<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return m.Set<T>().Where(predicate).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_t"></param>
        /// <returns></returns>
        public int Add<T>(T _t) where T : class
        {
            try
            {
                m.Set<T>().Add(_t);
                return m.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_t"></param>
        /// <returns></returns>
        public int Update<T>(T _t) where T : class
        {
            try
            {
                m.Entry<T>(_t).State = System.Data.EntityState.Modified;
                return m.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_t"></param>
        /// <returns></returns>
        public int Remove<T>(T _t) where T : class
        {
            try
            {
                m.Entry<T>(_t).State = System.Data.EntityState.Deleted;
                return m.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }

           
        }

        /// <summary>
        /// 查询总条数
        /// </summary>      
        public int GetCount<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return m.Set<T>().Where(predicate).Count();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">查询对象</typeparam>
        /// <typeparam name="TKey">条件类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize"> 每页条数</param>
        /// <param name="orderType">排序方式，1：升序，2：降序</param>
        /// <returns>数据列表</returns>
        public List<T> GetListByPager<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize, int orderType) where T : class
        {
            if (orderType == 1)
            {
                return m.Set<T>().Where(predicate).OrderBy(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return m.Set<T>().Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }


       

    }
}
