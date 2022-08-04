using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Contract
{
    public interface IPersonRepository:IRepository<Person>
    {

        /// <summary>
        /// یافتن یوزر با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Person> FindById(string? id);
        /// <summary>
        /// یافتن یوزر بر اساس ایمیل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Person> FindByEmail(string? id);
        /// <summary>
        /// متد برای صفحه بندی موارد دریافتی
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        
         Pagination<Person> FindAllByPagination(PersonPaginationParameters parameters);
        Task<bool> IsExists(string id);
        Task<bool> IsExistsByEmail(string email);
         string Gender(bool gender);
        /// <summary>
        /// متد  آپدیت جهت Apiput
        /// </summary>
        /// <param name="user"></param>
        public Task UpdatePerson( ApiUpdateDTO dto);
    }

}
