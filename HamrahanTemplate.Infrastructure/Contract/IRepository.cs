using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Contract
{
    /// <summary>
    /// کلاس پایه برای متد های مستقل 
    /// </summary>
    public interface IRepository<T> where T :class
    {
        /// <summary>
        /// دریافت همه ی ردیف ها
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();


        /// <summary>
        /// predicate متد فیلتر بر اساس 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
         Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter);

        /// <summary>
        /// دریافت جدید ترین آیتم ها
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="numberOfTakeItems"></param>
        /// <returns></returns>
        public IEnumerable<T> GetLatestItems(Expression<Func<T, object>> filter, int numberOfTakeItems);

        /// <summary>
        /// متد فیلتر با استفاده از کوئری
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> Find(string query, params object[] parameters);
        /// <summary>
        /// متد اضافه کردن موجودیت
        /// </summary>
        /// <param name="entity"></param>
        Task Insert(T entity);
        /// <summary>
        /// متد آپدیت موجودیت
        /// </summary>
        /// <param name="entity"></param>
        Task Update(T entity);
        /// <summary>
        /// (HardDelete) متد پاک کردن کامل
        /// </summary>
        /// <param name="entity"></param>

        Task<bool> HardDelete(T entity);

        
         
    }
}
