using FarshadTools;
using Hamrahan.Models;
using Hamrahan.Models.course;
using HamrahanTemplate.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Contract
{
   public interface ICourseRepository:IRepository<Course>
    {
        /// <summary>
        /// یافتن دوره آموزشی با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<Course> FindById(long? id);
        /// <summary>
        /// متد برای صفحه بندی موارد دریافتی
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Pagination<Course> FindAllByPagination(CoursePaginationParameters parameters);

        /// <summary>
        /// SoftDelete متد 
        /// </summary>
        bool SoftDelete(Course entity);


    }
}
