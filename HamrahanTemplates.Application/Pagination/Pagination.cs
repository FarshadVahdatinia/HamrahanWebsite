using System;
using System.Collections.Generic;
using System.Linq;

namespace HamrahanTemplate.Application.Pagination
{
    public class Pagination<T> : List<T>
    {

        public Pagination(IQueryable<T> source, int pageNumber, int pageSize)
        {
            TotalCount = source.Count();
            CurrentPage = pageNumber;
            PageSize = pageSize;
            SetRange(source);


        }

        /// <summary>
        /// شماره صفحه جاری
        /// </summary>
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        /// <summary>
        /// تعداد کل آیتم های کوئری
        /// </summary>
        public int TotalCount { get; set; }

        private void SetRange(IQueryable<T> source)
        {
            var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(TotalCount / (decimal)PageSize);
            AddRange(items);
        }



    }

}
