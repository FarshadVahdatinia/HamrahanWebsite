using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Application.Pagination
{
    public class CoursePaginationParameters
    {
        const int maxPageSize = 10;
        /// <summary>
        /// شماره صفحه
        /// </summary>
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 2;

        /// <summary>
        /// تعداد در هر صفحه
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize || value < 1 ? maxPageSize : value; }
        }

    }
}
